using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Server
{
    public class VelibInfos : IVelibInfos
    {
        private static string API_KEY = Server.Properties.Resources.api_key;

        // List containing the previously queried stations (i.e. the cache)
        private static List<Station> stations = new List<Station>();

        public async Task<int> GetAvailableBikes(string contract, string stationName, int cacheDuration)
        {
            Console.WriteLine("Fetching available bikes");
            Station selectedStation = new Station(contract, stationName);
            Station stationInList = stations.Find(s => s.Equals(selectedStation));
            // If the station has never been queried or its information is outdated, an update is needed.
            // Otherwise, there is no need to fetch the information. This limits the number of calls to the API.
            if (stationInList == null || (DateTime.Now - stationInList.timestamp).TotalSeconds > cacheDuration)
            {
                Console.WriteLine(stationInList == null ? "Station never queried, adding to cache." : "Outdated information, updating information.");
                // Gets the actual value from the server
                JArray stationsArray = await GetArray("https://api.jcdecaux.com/vls/v1/stations?contract=" + contract + "&apiKey=" + API_KEY);
                JObject station = (JObject)stationsArray.Children().Where(child => ((string)child["name"]).Contains(stationName)).First();
                selectedStation.nbAvailableBikes = (int)station["available_bikes"];
                // Removes the already present object representing the station if it exists in the cache.
                stations.Remove(stationInList);
                // Adds the newly created object.
                stations.Add(selectedStation);
            }
            else
            {
                Console.WriteLine("Getting value from cache.");
            }
            return stations.Find(s => s.Equals(selectedStation)).nbAvailableBikes;
        }

        public async Task<List<string>> GetContracts()
        {
            Console.WriteLine("Fetching contracts");
            var contracts = (await GetArray("https://api.jcdecaux.com/vls/v1/contracts?apiKey=" + API_KEY))
                .Children()
                .Select(child => (string)child["name"])
                .ToList();
            contracts.Sort();
            return contracts;
        }

        public async Task<List<string>> GetStations(string contract)
        {
            Console.WriteLine("Fetching stations");
            var stations = (await GetArray("https://api.jcdecaux.com/vls/v1/stations?contract=" + contract + "&apiKey=" + API_KEY))
                .Children()
                .Select(child => (string)child["name"])
                .ToList();
            stations.Sort();
            return stations;
        }

        private async Task<JArray> GetArray(string requestUrl)
        {
            // Create a request for the URL. 
            WebRequest request = WebRequest.Create(requestUrl);
            // If required by the server, set the credentials.
            // request.Credentials = CredentialCache.DefaultCredentials;
            // Get the response.
            WebResponse response = await request.GetResponseAsync();
            // Display the status.
            // Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            return JArray.Parse(responseFromServer);
        }
    }
}
