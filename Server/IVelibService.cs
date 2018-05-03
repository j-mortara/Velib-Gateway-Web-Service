using System.ServiceModel;

namespace EventsLib
{
    [ServiceContract(CallbackContract = typeof(IVelibServiceEvents))]
    public interface IVelibService
    {
        [OperationContract]
        void SubscribeStationChanged(string stationName, string cityName, int timeInSeconds);
    }
}