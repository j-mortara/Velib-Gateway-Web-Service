using System.Collections.Generic;
using System.ServiceModel;

namespace Server
{
    [ServiceContract]
    public interface IVelibInfos
    {
        [OperationContract]
        int GetAvailableBikes(string contract, string stationName);

        [OperationContract]
        List<string> GetContracts();

        [OperationContract]
        List<string> GetStations(string contract);

    }
}
