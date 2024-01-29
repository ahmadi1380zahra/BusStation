using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStationEF.Models
{
    public class JourneySeat
    {
        public void AddJourneySeat(Bus bus, Journey journey)
        {
            JorneyReport = new();
            Journey = journey;
            Seats = new();
            if (bus.Type == Type.Vip)
            {
                for (int i = 1; i <= 30; i++)
                {
                    Seats.Add(new Seat(i));
                }
            }
            if (bus.Type == Type.Normal)
            {
                for (int i = 1; i <= 44; i++)
                {
                    Seats.Add(new Seat(i));
                }
            }
        }
        public void SetJorneyReportReserveCount(int count)
        {
            JorneyReport.TotalReserveCount = JorneyReport.TotalReserveCount + count;
        }
        public void SetJorneyReportTotalCancealReserveCost()
        {
            var reservePrice = ((Journey.Price * 30) / 100);
            JorneyReport.TotalCancealReseveCost = JorneyReport.TotalCancealReserveCount * ((reservePrice * 20) / 100);
        }
        public void SetCancealReserveCount()
        {
            ++JorneyReport.TotalCancealReserveCount;
        }
        public void SetJorneyReportTotalReserveCost()
        {
            JorneyReport.TotalReserveCost = JorneyReport.TotalReserveCount * ((Journey.Price * 30) / 100);

        }
        public void SetJorneyReportSoldCount(int count)
        {
            JorneyReport.TotalSoldCount = JorneyReport.TotalSoldCount + count;
        }
        public void SetJorneyReportTotalsoldCost()
        {
            JorneyReport.TotalSoldCost = JorneyReport.TotalSoldCount * Journey.Price;

        }
        public void SetCancealSoldCount()
        {
            ++JorneyReport.TotalCancealSoldCount;
        }
        public void TotalCancealSoldCost()
        {
            JorneyReport.TotalCancealSoldCost = JorneyReport.TotalCancealSoldCount * ((Journey.Price * 10) / 100);

        }
        public void ShowJourneyReport()
        {
            Console.WriteLine($"this journey income was --> {JorneyReport.TotalSoldCost +
                JorneyReport.TotalReserveCost +
                JorneyReport.TotalCancealReseveCost +
                JorneyReport.TotalCancealSoldCost} \n" +
                $"empty seats --> {Seats.Count(item => item.Condition != "rr" && item.Condition != "bb")} \n" +
                $"reserve canceal count --> {JorneyReport.TotalCancealReserveCount} \n" +
                $"sold canceal count --> {JorneyReport.TotalCancealSoldCount}");
        }
        public int Id { get; set; }
        //public int SeatId { get; set; }
        public List<Seat> Seats { get; set; }
        public int JourneyId { get; set; }
        public Journey Journey { get; set; }
        public int BusId { get; set; }
        public Bus Bus { get; set; }
        public int JorneyReportId { get; set; }
        public JorneyReport JorneyReport { get;  set; }    
    }
}
