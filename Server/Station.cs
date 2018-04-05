using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Server
{
    // Class representing a station.
    // Only the contract (i.e. the city where the station is located) and the name of the station are represented
    // in this class, as those two information are enough to identify a station.
    [DataContract]
    public class Station
    {
        [DataMember] private string contract;
        [DataMember] private string name;
        [DataMember] public int nbAvailableBikes;
        public DateTime timestamp;

        // Number of seconds representing the timelapse we consider data as being up-to-date
        private static readonly int dataUpToDateTimelapse = 5;

        public Station(string contract, string name)
        {
            this.contract = contract;
            this.name = name;
            timestamp = DateTime.Now;
            nbAvailableBikes = 0;
        }

        public bool IsInformationOutdated()
        {
            TimeSpan ts = DateTime.Now - timestamp;
            return ts.TotalSeconds > dataUpToDateTimelapse;
        }

        protected bool Equals(Station other)
        {
            return string.Equals(contract, other.contract) && string.Equals(name, other.name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Station) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((contract != null ? contract.GetHashCode() : 0) * 397) ^
                       (name != null ? name.GetHashCode() : 0);
            }
        }
    }
}