using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStationEF.Models
{
    public class Seat
    {

        public Seat(int number)
        {

            Number = number;
            Condition = number.ToString("D2");
        }
        public int Id { get; set; }
        public int Number { get; set; }
        public string Condition { get; set; }
        public int JourneySeatId { get; set; }
        public JourneySeat JourneySeat { get; set; }

    }
}
