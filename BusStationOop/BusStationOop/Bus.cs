using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStationOop
{
    public abstract class Bus
    {
        protected Bus(string name)
        {
            JorneySeats = new();
            Name = name;
        }
        public string Name { get; set; }
        public List<JorneySeat> JorneySeats { get; set; }
        public virtual void ShowJourneySeat(JorneySeat journeySeat)
        {

        }
    }
    public class NormalBus : Bus
    {
        public NormalBus(string name) : base(name)
        {

        }
        public void AddNormalJorneySeat(Journey jorney,int id)
        {
            JorneySeats.Add(new JorneySeat(1, jorney,id));
        }
        public override void ShowJourneySeat(JorneySeat journeySeat)
        {
            int itemsInRow = 4;
            int itemsInCurrentRow = 0;
            int row = 1;
            foreach (var seat in journeySeat.Seats)
            {
                Console.Write($"{seat.Condition} ");
                itemsInCurrentRow++;

                if (itemsInCurrentRow % itemsInRow == 0)
                {
                    Console.WriteLine();
                    row++;
                }
                if (row == 6 || row == 7)
                {
                    itemsInRow = 2;
                }
                if (row == 8)
                {
                    itemsInRow = 4;
                }
            }


            base.ShowJourneySeat(journeySeat);
        }
    }
    public class VipBus : Bus
    {
        public VipBus(string name) : base(name)
        {

        }
        public void AddVipJorneySeat(Journey jorney,int id)
        {
            JorneySeats.Add(new JorneySeat(2, jorney,id));
        }
        public override void ShowJourneySeat(JorneySeat journeySeat)
        {
            int itemsInRow = 3;
            int itemsInCurrentRow = 0;
            int row = 1;
            foreach (var seat in journeySeat.Seats)
            {
                Console.Write($"{seat.Condition} ");
                itemsInCurrentRow++;

                if (itemsInCurrentRow % itemsInRow == 0)
                {
                    Console.WriteLine();
                    row++;
                }
                if (row == 6 || row == 7 || row == 8)
                {
                    itemsInRow = 1;
                }
                if (row == 9)
                {
                    itemsInRow = 3;
                }
            }
            base.ShowJourneySeat(journeySeat);
        }
    }
}
