using System.ServiceModel;

namespace EventsLib
{
    [ServiceContract(CallbackContract = typeof(IVelibServiceEvents))]
    public interface IVelibService
    {
        [OperationContract]
        void SubscribeStationChange(string stationName);
    }
}