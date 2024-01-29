using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStationEF.Models
{
    public class Bus
    {
        public Bus(string name, Type type)
        {
            Name = name;
            Type = type;
            JourneySeats = new();

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public Type Type { get; set; }
        public List<JourneySeat> JourneySeats { get; set; }
        public void AddJorneySeat(Journey jorney)
        {
            JourneySeat currentJourneySeat = new JourneySeat();
            currentJourneySeat.AddJourneySeat(this, jorney); 
            JourneySeats.Add(currentJourneySeat);
           
        }
    }

    public enum Type
    {
        Vip = 1,
        Normal = 2

    }
}
