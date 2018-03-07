using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace Server
{
    public class VelibInfos : IVelibInfos
    {
        private static string API_KEY = "340822148337f9e2d1fa9c0b9952fc4962bcfaca";

        public int GetAvailableBikes(string contract, string stationName)
        {
            JArray stationsArray = GetArray("https://api.jcdecaux.com/vls/v1/stations?contract=" + contract + "&apiKey=" + API_KEY);
            JObject station = (JObject)stationsArray.Children().Where(child => ((string)child["name"]).Contains(stationName)).First();
            return (int)station["available_bikes"];
        }

        public List<string> GetContracts()
        {
            return GetArray("https://api.jcdecaux.com/vls/v1/contracts?apiKey=" + API_KEY)
                .Children()
                .Select(child => (string)child["name"])
                .ToList();
        }

        public List<string> GetStations(string contract)
        {
            return GetArray("https://api.jcdecaux.com/vls/v1/stations?contract=" + contract + "&apiKey=" + API_KEY)
                .Children()
                .Select(child => (string)child["name"])
                .ToList();
        }

        private JArray GetArray(string requestUrl)
        {
            // Create a request for the URL. 
            WebRequest request = WebRequest.Create(requestUrl);
            // If required by the server, set the credentials.
            // request.Credentials = CredentialCache.DefaultCredentials;
            // Get the response.
            WebResponse response = request.GetResponse();
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
