using System;
using System.Collections.Generic;

namespace Server
{
    // Class representing a station.
    // Only the contract (i.e. the city where the station is located) and the name of the station are represented
    // in this class, as those two information are enough to identify a station.
    class Station : IEquatable<Station>
    {

        private string contract;
        private string name;
        public int nbAvailableBikes;
        private DateTime timestamp;

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

        // Two stations are equals if they have the same name and are attached to the same contract.
        // Indeed, there can't be two stations with the same name in the same city.
        public override bool Equals(object obj)
        {
            return Equals(obj as Station);
        }

        public bool Equals(Station other)
        {
            return other != null &&
                   contract == other.contract &&
                   name == other.name;
        }

        public override int GetHashCode()
        {
            var hashCode = 1971805048;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(contract);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(name);
            return hashCode;
        }

    }
}
