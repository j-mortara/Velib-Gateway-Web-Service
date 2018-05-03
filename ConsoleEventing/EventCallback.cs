using System;
using ConsoleEventing.Event;

namespace ConsoleEventing
{
    public class EventCallback : Event.IVelibServiceCallback
    {
        public void StationChanged(Station station)
        {
            Console.WriteLine($"station changed {station.name}");
        }
    }
}