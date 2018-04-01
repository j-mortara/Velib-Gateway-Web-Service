using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;
using ConsoleClient.VelibServiceReference;

namespace ConsoleClient
{
    class Program
    {
        private static VelibInfosClient velibInfosClient = new VelibInfosClient();

        private static int cacheDuration = 5;

        static void Main(string[] args)
        {
            Dictionary<string, Action<List<string>>> actions = new Dictionary<string, Action<List<string>>>
            {
                {"help", _ => PrintHelp()},
                {"list-contracts", _ => ListContracts()},
                {"list-contracts-async", _ => ListContractsAsync()},
                {"list-stations", l => ListStations(l[1])},
                {"list-stations-async", l => ListStationsAsync(l[1])},
                {"get-station", l => GetStationInformation(l[1], l[2], cacheDuration)},
                {"get-station-async", l => GetStationInformationAsync(l[1], l[2], cacheDuration)},
                {"set-cache-duration", l => cacheDuration = Convert.ToInt32(l[1])},
                {"print-cache-duration", _ => Console.WriteLine(cacheDuration)}
            };

            Console.WriteLine("Type \"help\" for the list of commands.");

            while (true)
            {
                Console.Write("> ");
                var command = Console.ReadLine();
                if (command == "exit") break;
                var split = command.Split(' ');
                command = split[0];
                if (actions.ContainsKey(command)) actions[command].Invoke(split.ToList());
                else Console.WriteLine("Unknown command : " + command);
            }
        }

        private static void PrintHelp()
        {
            Console.WriteLine(
                "List of possible commands : \n" +
                "exit - closes the client \n" +
                "help - displays this message \n" +
                "list-contracts(-async) - display the list of contracts (asynchronously) \n" +
                "list-stations(-async) <contract> - display the list of stations in the contract <contract> (asynchronously) \n" +
                "get-station(-async) <contract> <station> - display the number of available bikes at the station <station> in the contract <contract> (asynchronously) \n" +
                "print-cache-duration - display the actual cache duration in seconds \n" +
                "set-cache-duration <value> - set the cache duration"
            );
        }

        private static void ListContracts()
        {
            velibInfosClient.GetContracts().ToList().ForEach(Console.WriteLine);
        }

        private static async void ListContractsAsync()
        {
            (await velibInfosClient.GetContractsAsync()).ToList().ForEach(Console.WriteLine);
        }

        private static void ListStations(string contract)
        {
            velibInfosClient.GetStations(contract).ToList().ForEach(Console.WriteLine);
        }

        private static async void ListStationsAsync(string contract)
        {
            (await velibInfosClient.GetStationsAsync(contract)).ToList().ForEach(Console.WriteLine);
        }

        private static void GetStationInformation(string contract, string station, int timelapse)
        {
            Console.WriteLine("Nb of available bikes : " + velibInfosClient.GetAvailableBikes(contract, station, timelapse));
        }

        private static async void GetStationInformationAsync(string contract, string station, int timelapse)
        {
            Console.WriteLine("Nb of available bikes : " + await velibInfosClient.GetAvailableBikesAsync(contract, station, timelapse));
        }
    }
}