using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Server
{
    [ServiceContract]
    public interface IVelibInfos
    {
        [OperationContract]
        Task<int> GetAvailableBikes(string contract, string stationName);

        [OperationContract]
        Task<List<string>> GetContracts();

        [OperationContract]
        Task<List<string>> GetStations(string contract);

    }
}
