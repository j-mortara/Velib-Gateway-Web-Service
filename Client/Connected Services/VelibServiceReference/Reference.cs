﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client.VelibServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="VelibServiceReference.IVelibInfos")]
    public interface IVelibInfos {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVelibInfos/GetAvailableBikes", ReplyAction="http://tempuri.org/IVelibInfos/GetAvailableBikesResponse")]
        int GetAvailableBikes(string contract, string stationName, int cacheDuration);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVelibInfos/GetAvailableBikes", ReplyAction="http://tempuri.org/IVelibInfos/GetAvailableBikesResponse")]
        System.Threading.Tasks.Task<int> GetAvailableBikesAsync(string contract, string stationName, int cacheDuration);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVelibInfos/GetContracts", ReplyAction="http://tempuri.org/IVelibInfos/GetContractsResponse")]
        string[] GetContracts();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVelibInfos/GetContracts", ReplyAction="http://tempuri.org/IVelibInfos/GetContractsResponse")]
        System.Threading.Tasks.Task<string[]> GetContractsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVelibInfos/GetStations", ReplyAction="http://tempuri.org/IVelibInfos/GetStationsResponse")]
        string[] GetStations(string contract);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVelibInfos/GetStations", ReplyAction="http://tempuri.org/IVelibInfos/GetStationsResponse")]
        System.Threading.Tasks.Task<string[]> GetStationsAsync(string contract);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IVelibInfosChannel : Client.VelibServiceReference.IVelibInfos, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class VelibInfosClient : System.ServiceModel.ClientBase<Client.VelibServiceReference.IVelibInfos>, Client.VelibServiceReference.IVelibInfos {
        
        public VelibInfosClient() {
        }
        
        public VelibInfosClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public VelibInfosClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public VelibInfosClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public VelibInfosClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int GetAvailableBikes(string contract, string stationName, int cacheDuration) {
            return base.Channel.GetAvailableBikes(contract, stationName, cacheDuration);
        }
        
        public System.Threading.Tasks.Task<int> GetAvailableBikesAsync(string contract, string stationName, int cacheDuration) {
            return base.Channel.GetAvailableBikesAsync(contract, stationName, cacheDuration);
        }
        
        public string[] GetContracts() {
            return base.Channel.GetContracts();
        }
        
        public System.Threading.Tasks.Task<string[]> GetContractsAsync() {
            return base.Channel.GetContractsAsync();
        }
        
        public string[] GetStations(string contract) {
            return base.Channel.GetStations(contract);
        }
        
        public System.Threading.Tasks.Task<string[]> GetStationsAsync(string contract) {
            return base.Channel.GetStationsAsync(contract);
        }
    }
}
