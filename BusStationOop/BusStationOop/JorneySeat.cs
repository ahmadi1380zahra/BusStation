using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStationOop
{
    public class JorneySeat
    {
        private JorneyReport _JorneyReport;
        public JorneySeat(int busType, Journey journey, int id)
        {
            Id = id;
            Journey = journey;
            Seats = new();
            if (busType == 1)
            {
                for (int i = 1; i <= 44; i++)
                {
                    Seats.Add(new Seat(i));
                }
            }
            if (busType == 2)
            {
                for (int i = 1; i <= 30; i++)
                {
                    Seats.Add(new Seat(i));
                }
            }
            _JorneyReport = new JorneyReport();
        }
        public int Id { get; set; }
        public List<Seat> Seats { get; set; }
        public Journey Journey { get; set; }
        public void SetJorneyReportReserveCount(int count)
        {
            _JorneyReport.TotalReserveCount = _JorneyReport.TotalReserveCount + count;
        }
        public void SetJorneyReportTotalReserveCost()
        {
            _JorneyReport.TotalReserveCost = _JorneyReport.TotalReserveCount * ((Journey.Price * 30) / 100);

        }
        public void SetCancealReserveCount()
        {
            ++_JorneyReport.TotalCancealReserveCount;
        }
        public void SetJorneyReportTotalCancealReserveCost()
        {
            var reservePrice =  ((Journey.Price * 30) / 100);
            _JorneyReport.TotalCancealReseveCost= _JorneyReport.TotalCancealReserveCount * ((reservePrice * 20) / 100);
        }
        public void SetJorneyReportSoldCount(int count)
        {
            _JorneyReport.TotalSoldCount = _JorneyReport.TotalSoldCount+count;
        }
        public void SetJorneyReportTotalsoldCost()
        {
            _JorneyReport.TotalSoldCost = _JorneyReport.TotalSoldCount * Journey.Price ;

        }

        public void SetCancealSoldCount()
        {
           ++ _JorneyReport.TotalCancealSoldCount;
        }
        public void TotalCancealSoldCost()
        {
            _JorneyReport.TotalCancealSoldCost = _JorneyReport.TotalCancealSoldCount * ((Journey.Price * 10) / 100);

        }
     
        public void ShowJourneyReport()
        {
            Console.WriteLine($"this journey income was --> {_JorneyReport.TotalSoldCost+
                _JorneyReport.TotalReserveCost+
                _JorneyReport.TotalCancealReseveCost+
                _JorneyReport.TotalCancealSoldCost} \n"+
                $"empty seats --> {Seats.Count(item=>item.Condition !="rr" && item.Condition!="bb")} \n"+
                $"reserve canceal count --> {_JorneyReport.TotalCancealReserveCount} \n"+
                $"sold canceal count --> {_JorneyReport.TotalCancealSoldCount}");
        }
    }
}
