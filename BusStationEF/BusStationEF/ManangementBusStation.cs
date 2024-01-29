using BusStationEF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Type = BusStationEF.Models.Type;

namespace BusStationEF
{
    public static class ManangementBusStation
    {
        private static EFDataContext _context = new EFDataContext();
        public static void AddBus(int busType, string name)
        {
            switch (busType)
            {
                case 1:
                    {
                        var isExist = _context.Buses.Any(item => item.Name == name);
                        if (isExist)
                        {
                            throw new Exception("name should be unique");
                        }
                        var VipBus = new Bus(name, Type.Vip);
                        _context.Buses.Add(VipBus);
                        _context.SaveChanges();

                        break;
                    }
                case 2:
                    {
                        var isExist = _context.Buses.Any(item => item.Name == name);
                        if (isExist)
                        {
                            throw new Exception("name should be unique");
                        }
                        var NormalBus = new Bus(name, Type.Normal);
                        _context.Buses.Add(NormalBus);
                        _context.SaveChanges();

                        break;
                    }
                default:
                    {
                        throw new Exception("not valid type");
                       
                    }
            }
        }
        public static void ShowVipBuses()
        {
            var vipBuses = _context.Buses.Where(item => item.Type == Type.Vip);
            foreach (var bus in vipBuses)
            {
                Console.WriteLine($"ID: {bus.Id} --> Name this vip bus is {bus.Name}");
            }
        }
        public static void ShowNormalBuses()
        {
            var NormalBuses = _context.Buses.Where(item => item.Type == Type.Normal);
            foreach (var bus in NormalBuses)
            {
                Console.WriteLine($"ID: {bus.Id} --> Name this Normal bus is {bus.Name}");
            }
        }
        public static void AddJourneyToBus(int busId, string origin, string destination, decimal price)
        {
            var bus = _context.Buses.Find(busId);
            var journey = new Journey(origin, destination, price);
            if (bus == null )
            {
                throw new Exception("bus not found");
            }
            bus.AddJorneySeat(journey);
            _context.SaveChanges();
         }
        public static void ShowJourneys()
        {
           foreach(var journeySeat in _context.JourneySeats.Include(b=>b.Bus).Include(j=>j.Journey))
            {
                Console.WriteLine($"{journeySeat.Id} {journeySeat.Bus.Name} ({journeySeat.Bus.Type}) From {journeySeat.Journey.Origin} To {journeySeat.Journey.Destination} Costs {journeySeat.Journey.Price}" );
              
            }
        }
        public static void ShowJourneyDetail(int journeyId)
        {
            var journeySeat=_context.JourneySeats.Include(_=>_.Seats).FirstOrDefault(_=>_.Id==journeyId);
          
            if (journeySeat==null)
            {
                throw new Exception("this journey is not existed");
            }
            if (journeySeat.Bus.Type == Type.Normal)
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
            }
            if (journeySeat.Bus.Type == Type.Vip)
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
            }
            
        }
        public static void ReserveTicket(int journeyId, int seatNumber)
        {
           
            var journeySeat = _context.JourneySeats.Include(_=>_.JorneyReport).Include(_ => _.Seats).FirstOrDefault(_ => _.Id == journeyId);

            if (journeySeat == null)
            {
                throw new Exception("this journey is not existed");
            }

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
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("this seat already has a passenger");

            }

        }
        public static void SellTicket(int journeyId, int seatNumber)
        {
            var journeySeat = _context.JourneySeats.Include(_ => _.JorneyReport).Include(_ => _.Seats).FirstOrDefault(_ => _.Id == journeyId);

            if (journeySeat == null)
            {
                throw new Exception("this journey is not existed");
            }

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
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("this seat already has a passenger");

            }

        }

        public static void CancealTicket(int journeyId, int seatNumber)
        {
            var journeySeat = _context.JourneySeats.Include(_ => _.JorneyReport).Include(_ => _.Seats).FirstOrDefault(_ => _.Id == journeyId);

            if (journeySeat == null)
            {
                throw new Exception("this journey is not existed");
            }
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
                _context.SaveChanges();
            }
            if (seat.Condition == "rr")
            {
                journeySeat.SetJorneyReportReserveCount(-1);
                journeySeat.SetJorneyReportTotalReserveCost();
                journeySeat.SetCancealReserveCount();
                journeySeat.SetJorneyReportTotalCancealReserveCost();
                seat.Condition = seat.Number.ToString("D2");
                _context.SaveChanges();
            }



        }
        public static void ShowJourneyReport(int journeyId)
        {
            var journeySeat = _context.JourneySeats.Include(_ => _.JorneyReport).Include(_ => _.Seats).FirstOrDefault(_ => _.Id == journeyId);

            if (journeySeat == null)
            {
                throw new Exception("this journey is not existed");
            }
           

            journeySeat.ShowJourneyReport();


        }
    }
}
