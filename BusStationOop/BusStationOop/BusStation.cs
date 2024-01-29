using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStationOop
{
    public static class BusStation
    {
        private static List<Bus> _buses = new();
        private static int _id = 0;
        public static void AddBus(int busType, string name)
        {
            switch (busType)
            {
                case 1:
                    {
                        var IsExist = _buses.Any(item => item.Name == name);
                        if (IsExist)
                        {
                            throw new Exception("bus name should be unique");
                        }
                        var normalBus = new NormalBus(name);
                        _buses.Add(normalBus);
                        break;
                    }
                case 2:
                    {
                        var IsExist = _buses.Any(item => item.Name == name);
                        if (IsExist)
                        {
                            throw new Exception("bus name should be unique");
                        }
                        var vipBus = new VipBus(name);
                        _buses.Add(vipBus);
                        break;
                    }

            }
        }
        public static void ShowNormalBuses()
        {
            var normalBuses = _buses.Where(item => item is NormalBus);
            Console.WriteLine("-------- Normal Bus List --------");
            foreach (var normalBus in normalBuses)
            {
                Console.WriteLine($"{normalBus.Name}");
            }
        }
        public static void ShowVipBuses()
        {
            var vipBuses = _buses.Where(item => item is VipBus);
            Console.WriteLine("-------- Vip Bus List --------");
            foreach (var vipBus in vipBuses)
            {
                Console.WriteLine($"{vipBus.Name}");
            }
        }
        public static void AddJourneyToNormalBus(string busName, string origin, string destination, decimal price)
        {
            var bus = _buses.Find(item => item.Name == busName);
            var journey = new Journey(origin, destination, price);
            if (bus == null || bus is not NormalBus)
            {
                throw new Exception("bus not found or its not normal type");
            }
            var normalBus = bus as NormalBus;
            normalBus.AddNormalJorneySeat(journey, ++_id);
        }
        public static void AddJourneyToVipBus(string busName, string origin, string destination, decimal price)
        {
            var bus = _buses.Find(item => item.Name == busName);
            var journey = new Journey(origin, destination, price);
            if (bus == null || bus is not VipBus)
            {
                throw new Exception("bus not found or its not vip type");
            }
            var vipBus = bus as VipBus;
            vipBus.AddVipJorneySeat(journey, ++_id);
        }
        public static void ShowJourney()
        {
            foreach (var bus in _buses)
            {
                if (bus.JorneySeats.Count > 0)
                {

                    foreach (var jorney in bus.JorneySeats)
                    {
                        Console.Write($"{jorney.Id} -> {bus.Name} -- {(bus is NormalBus ? "Type : normal " : "Type : vip")} -- ");
                        Console.WriteLine($"{jorney.Journey.Origin} To" +
                            $" {jorney.Journey.Destination} " +
                            $"Costs {jorney.Journey.Price}");
                    }
                }
            }
        }
        public static void ShowJourneyDetail(int journeyId)
        {
            var buss = _buses.Find(bus => bus.JorneySeats.Any(journey => journey.Id == journeyId));
            if (buss == null)
            {
                throw new Exception("this journey id is not existed");
            }
            var journeySeat = buss.JorneySeats.Find(journey => journey.Id == journeyId);
            buss.ShowJourneySeat(journeySeat);

        }

        public static void ReserveTicket(int journeyId, int seatNumber)
        {
            var buss = _buses.Find(bus => bus.JorneySeats.Any(journey => journey.Id == journeyId));
            if (buss == null)
            {
                throw new Exception("this journey id is not existed");
            }
            var journeySeat = buss.JorneySeats.Find(journey => journey.Id == journeyId);
            var seat = journeySeat.Seats.Find(seat => seat.Number == seatNumber);
            if (seat is null)
            {
                throw new Exception("this seat number is not existed");
            }
            if (seat.Condition != "rr" && seat.Condition != "bb")
            {
                journeySeat.SetJorneyReportReserveCount(+1);
                journeySeat.SetJorneyReportTotalReserveCost();
                seat.Condition = "rr";
            }
            else
            {
                throw new Exception("this seat already has a passenger");

            }

        }
        public static void SellTicket(int journeyId, int seatNumber)
        {
            var buss = _buses.Find(bus => bus.JorneySeats.Any(journey => journey.Id == journeyId));
            if (buss == null)
            {
                throw new Exception("this journey id is not existed");
            }
            var journeySeat = buss.JorneySeats.Find(journey => journey.Id == journeyId);
            var seat = journeySeat.Seats.Find(seat => seat.Number == seatNumber);
            if (seat is null)
            {
                throw new Exception("this seat number is not existed");
            }
            if (seat.Condition != "rr" && seat.Condition != "bb")
            {
                journeySeat.SetJorneyReportSoldCount(+1);
                journeySeat.SetJorneyReportTotalsoldCost();
                seat.Condition = "bb";
            }
            else
            {
                throw new Exception("this seat already has a passenger");

            }

        }
        public static void CancealTicket(int journeyId, int seatNumber)
        {
            var buss = _buses.Find(bus => bus.JorneySeats.Any(journey => journey.Id == journeyId));
            if (buss == null)
            {
                throw new Exception("this journey id is not existed");
            }
            var journeySeat = buss.JorneySeats.Find(journey => journey.Id == journeyId);
            var seat = journeySeat.Seats.Find(seat => seat.Number == seatNumber);
            if (seat is null)
            {
                throw new Exception("this seat number is not existed");
            }
            if (seat.Condition != "rr" && seat.Condition != "bb")
            {
                throw new Exception("this seat  doesn't have any  passenger");

            }
            if (seat.Condition == "bb")
            {
                journeySeat.SetJorneyReportSoldCount(-1);
                journeySeat.SetJorneyReportTotalsoldCost();
                journeySeat.SetCancealSoldCount();
                journeySeat.TotalCancealSoldCost();
                seat.Condition = seat.Number.ToString("D2");
            }
            if (seat.Condition == "rr")
            {
                journeySeat.SetJorneyReportReserveCount(-1);
                journeySeat.SetJorneyReportTotalReserveCost();
                journeySeat.SetCancealReserveCount();
                journeySeat.SetJorneyReportTotalCancealReserveCost();
                seat.Condition = seat.Number.ToString("D2");
            }



        }
        public static void ShowJourneyReport(int journeyId)
        {
            var buss = _buses.Find(bus => bus.JorneySeats.Any(journey => journey.Id == journeyId));
            if (buss == null)
            {
                throw new Exception("this journey id is not existed");
            }
            var journeySeat = buss.JorneySeats.Find(journey => journey.Id == journeyId);

            journeySeat.ShowJourneyReport();


        }
    }
}
