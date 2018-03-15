using System;
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
            Console.WriteLine("J'ouvre");
            serviceHost.Open();
            Console.ReadLine();
            Console.WriteLine("Je ferme");
            serviceHost.Close();
        }
    }
}
