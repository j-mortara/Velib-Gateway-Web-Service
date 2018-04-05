using System;
using ConsoleEventing.EventService;

namespace ConsoleEventing
{
    public class EventCallback : EventService.IVelibServiceCallback
    {
        public void StationChanged(Station station)
        {
            Console.WriteLine($"LOL station changed {station.name}");
        }
    }
}