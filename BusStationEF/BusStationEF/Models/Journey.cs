using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStationEF.Models
{
    public class Journey
    {
        public Journey(string origin, string destination, decimal price)
        {
            Origin = origin;
            Destination = destination;
            Price = price;
        }
        public int Id { get; set; }
        public string Origin { get; set; }

        public string Destination { get; set; }

        public decimal Price { get; set; }
        public JourneySeat JourneySeat { get; set; }
    }
}
