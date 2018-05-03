using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Server;

namespace EventsLib
{
    [ServiceBehavior]
    public class VelibService : IVelibService
    {
        static List<Timer> timers = new List<Timer>();

        public void SubscribeStationChanged(string stationName, string cityName, int timeInSeconds)
        {
            Console.WriteLine("LOLOLOL");
            var subscriber = OperationContext.Current.GetCallbackChannel<IVelibServiceEvents>();
            timers.Add(new Timer(_ => Callback(subscriber, stationName, cityName), subscriber, 0,
                timeInSeconds * 1000));
        }

        private void Callback(IVelibServiceEvents subscriber, string stationName, string cityName)
        {
            Console.WriteLine("OPOPO");

            WebRequest webRequest =
                WebRequest.Create(
                    $"https://api.jcdecaux.com/vls/v1/stations?contract={cityName}&apiKey={VelibInfos.API_KEY}");
            webRequest.Credentials = CredentialCache.DefaultCredentials;

            var response = webRequest.GetResponse();

            Stream dataStream = response.GetResponseStream();

            StreamReader reader = new StreamReader(dataStream);

            string responseFromServer = reader.ReadToEnd();

            List<Station> stations = JsonConvert.DeserializeObject<List<Station>>(responseFromServer);
            reader.Close();
            response.Close();
            subscriber.StationChanged(stations.Find(station => station.name == stationName));
            Console.WriteLine("LOLOLOLOLOLOL");
        }
    }
}