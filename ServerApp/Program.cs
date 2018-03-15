﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Server;

namespace ServerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceHost = new ServiceHost(typeof(VelibInfos));
            Console.WriteLine("Launchig service");
            serviceHost.Open();
            Console.WriteLine("Service running");
            while (true)
            {
                if (Console.ReadLine().Contains("exit"))
                {
                    Console.WriteLine("Closing service");
                    serviceHost.Close();
                    break;
                }
            }
                

        }
    }
}
