using System.ServiceModel;
using Server;

namespace EventsLib
{
    [ServiceContract]
    public interface IVelibServiceEvents
    {
        [OperationContract(IsOneWay = true)]
        void StationChanged(Station station);
    }
}