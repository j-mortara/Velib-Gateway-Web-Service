using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleClient.VelibServiceReference;

namespace ConsoleClient
{
    class Program
    {
        private static VelibInfosClient velibInfosClient = new VelibInfosClient();

        static void Main(string[] args)
        {
            Dictionary<string, Action<List<string>>> actions = new Dictionary<string, Action<List<string>>>
            {
                {"help", _ => PrintHelp()},
                {"list-contracts", _ => ListContracts()},
                {"list-stations", l => ListStations(l[1])},
                {"get-station", l => GetStationInformation(l[1], l[2], 5)}
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
                "list-contracts - display the list of contracts \n" +
                "list-stations <contract> - display the list of stations in the contract <contract> \n" +
                "get-station <contract> <station> - display the number of available bikes at the station <station> in the contract <contract>"
            );
        }

        private static void ListContracts()
        {
            velibInfosClient.GetContracts().ToList().ForEach(Console.WriteLine);
        }

        private static void ListStations(string contract)
        {
            velibInfosClient.GetStations(contract).ToList().ForEach(Console.WriteLine);
        }

        private static void GetStationInformation(string contract, string station, int timelapse)
        {
            Console.WriteLine(velibInfosClient.GetAvailableBikes(contract, station, timelapse));
        }
    }
}