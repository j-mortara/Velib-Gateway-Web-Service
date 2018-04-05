using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.ServiceModel;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Server;

namespace EventsLib
{
    [ServiceBehavior]
    public class VelibService : IVelibService
    {
        public static Action<Station> StationChanged = delegate { };

        public void SubscribeStationChange(string stationName)
        {
            var subscriber = OperationContext.Current.GetCallbackChannel<IVelibServiceEvents>();
            StationChanged += subscriber.StationChanged;
        }
    }
}