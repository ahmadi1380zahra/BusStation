using BusStationEF;

while (true)
{
    try
    {
        Run();
    }
    catch (Exception exception)
    {
        Console.WriteLine(exception.Message);
    }
}
static void Run()
{
    var option = GetInt("attention in the entire project if you enter 0 you come back to the menu \n " +
        "1.add bus\n 2.add journey \n " +
        "3.show journys \n 4.Reserve ticket \n " +
        "5.sell ticket \n 6.canceal ticket \n" +
        "7.show Report\n 8.Exit");
    switch (option)
    {
        case 1:
            {
                var busType = GetInt("bus type? 1.vip  2.normal ");
                var busName = GetString("what is the bus name?");
                ManangementBusStation.AddBus(busType, busName);
                break;
            }
        case 2:
            {
                var busType = GetInt("Bus type for this journey? 1.vip  2.normal ");
                switch (busType)
                {
                    case 1:
                        {
                            ManangementBusStation.ShowVipBuses();

                            break;
                        }
                    case 2:
                        {
                            ManangementBusStation.ShowNormalBuses();

                            break;
                        }

                }
                var busId = GetInt("Enter bus id ");
                var journeyOrigin = GetString("where is the origin?");
                var journeyDestination = GetString("where is the Destination?");
                var journeyPrice = GetDecimal("How much does this journey cost?");
                ManangementBusStation.AddJourneyToBus(busId, journeyOrigin, journeyDestination, journeyPrice);

                break;
            }
        case 3:
            {
                ManangementBusStation.ShowJourneys();
                var journeySeatId = GetInt("Enter journeyId for more detail");
                ManangementBusStation.ShowJourneyDetail(journeySeatId);

                break;
            }
        case 4:
            {
                ManangementBusStation.ShowJourneys();
                var journeySeatId = GetInt("Enter journeyId for more detail");
                ManangementBusStation.ShowJourneyDetail(journeySeatId);
                var seatNumber = GetInt("enter the seat you want to reserve");
                ManangementBusStation.ReserveTicket(journeySeatId, seatNumber);
                break;
            }

        case 5:
            {

                ManangementBusStation.ShowJourneys();
                var journeySeatId = GetInt("Enter journeyId for more detail");
                ManangementBusStation.ShowJourneyDetail(journeySeatId);
                var seatNumber = GetInt("enter the seat you want to buy");
                ManangementBusStation.SellTicket(journeySeatId, seatNumber);

                break;
            }
        case 6:
            {
                ManangementBusStation.ShowJourneys();
                var journeySeatId = GetInt("Enter journeyId for more detail");
                ManangementBusStation.ShowJourneyDetail(journeySeatId);
                var seatNumber = GetInt("enter the seat you want to canceal");
                ManangementBusStation.CancealTicket(journeySeatId, seatNumber);
                
                break;
            }
        case 7:
            {
                ManangementBusStation.ShowJourneys();
                var journeySeatId = GetInt("Enter journeyId for more detail");
                ManangementBusStation.ShowJourneyReport(journeySeatId);
                break;
            }
        case 8:
            {
                Environment.Exit(0);
                break;
            }
    }
}
static string GetString(string message)
{
    Console.WriteLine(message);
    string value = Console.ReadLine()!;
    if (value == "0")
    {
        throw new Exception("back to menue");
    }
    return value;
}

static int GetInt(string message)
{
    Console.WriteLine(message);
    int value = int.Parse(Console.ReadLine()!);
    if (value == 0)
    {
        throw new Exception("back to menue");
    }
    return value;
}
static decimal GetDecimal(string message)
{
    Console.WriteLine(message);
    decimal value = decimal.Parse(Console.ReadLine()!);
    if (value == 0)
    {
        throw new Exception("back to menue");
    }
    return value;
}
