using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BusStationOop
{
    public class Seat
    {
        public Seat(int number)
        {

            Number = number;
            Condition = number.ToString("D2");
        }
        public int Number { get; set; }
        public string Condition { get; set; }
       
    }
}
