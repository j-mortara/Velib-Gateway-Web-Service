using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Server
{
    public class VelibInfos : IVelibInfos
    {
        private static string API_KEY = Server.Properties.Resources.api_key;

        public async Task<int> GetAvailableBikes(string contract, string stationName)
        {
            JArray stationsArray = await GetArray("https://api.jcdecaux.com/vls/v1/stations?contract=" + contract + "&apiKey=" + API_KEY);
            JObject station = (JObject)stationsArray.Children().Where(child => ((string)child["name"]).Contains(stationName)).First();
            return (int)station["available_bikes"];
        }

        public async Task<List<string>> GetContracts()
        {
            return (await GetArray("https://api.jcdecaux.com/vls/v1/contracts?apiKey=" + API_KEY))
                .Children()
                .Select(child => (string)child["name"])
                .ToList();
        }

        public async Task<List<string>> GetStations(string contract)
        {
            return (await GetArray("https://api.jcdecaux.com/vls/v1/stations?contract=" + contract + "&apiKey=" + API_KEY))
                .Children()
                .Select(child => (string)child["name"])
                .ToList();
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
