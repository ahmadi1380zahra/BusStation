using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStationEF.Models
{
    public class JorneyReport
    {
        public int JorneyReportId { get; set; }
        public decimal TotalReserveCount { get; set; }
        public decimal TotalSoldCount { get; set; }
        public decimal TotalCancealReserveCount { get; set; }
        public decimal TotalCancealSoldCount { get; set; }
        public decimal TotalReserveCost { get; set; }
        public decimal TotalSoldCost { get; set; }
        public decimal TotalCancealSoldCost { get; set; }
        public decimal TotalCancealReseveCost { get; set; }
        public JourneySeat JourneySeat { get; set; }
    }
}
