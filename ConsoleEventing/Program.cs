using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEventing
{
    class Program
    {
        static void Main(string[] args)
        {
            var instanceContext = new InstanceContext(new EventCallback());
            var velibServiceClient = new Event.VelibServiceClient(instanceContext);
            velibServiceClient.SubscribeStationChanged("00029", "Nancy", 1);
            Console.ReadLine();
        }
    }
}