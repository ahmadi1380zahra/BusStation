
using BusStationOop;

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
    var option = GetInt("attention in the entire project if you enter 0 you come back to the menu \n" +
        "1.add bus\n" +
        "2.add journey to bus \n" +
        "3.show journey \n" +
        "4.Reserve ticket \n" +
        "5.sell ticket\n" +
        "6.canceal ticket\n" +
        "7.report \n" +
        "8.Exit");
    switch (option)
    {
        case 1:
            {
                var busType = GetInt("bus type? 1.normal 2.vip ");
                var busName = GetString("what is the bus name?");
                BusStation.AddBus(busType, busName);
                break;
            }
        case 2:
            {
                var busType = GetInt("bus type for this trip? 1.normal 2.vip ");
                switch (busType)
                {
                    case 1:
                        {
                            BusStation.ShowNormalBuses();
                            var normalBus = GetString("enter the name of normal bus that you choose");
                            var journeyOrigin = GetString("where is the origin?");
                            var journeyDestination = GetString("where is the Destination?");
                            var journeyPrice = GetDecimal("How much does this journey cost?");
                            BusStation.AddJourneyToNormalBus(normalBus, journeyOrigin, journeyDestination, journeyPrice);
                            break;
                        }
                    case 2:
                        {
                            BusStation.ShowVipBuses();
                            var vipBus = GetString("enter the name of vip bus that you choose");
                            var journeyOrigin = GetString("where is the origin?");
                            var journeyDestination = GetString("where is the Destination?");
                            var journeyPrice = GetDecimal("How much does this journey cost?");
                            BusStation.AddJourneyToVipBus(vipBus, journeyOrigin, journeyDestination, journeyPrice);
                            break;
                        }
                    default:
                        {
                            throw new Exception("you did not enter valid bus type");
                        }
                }

                break;
            }
        case 3:
            {
                BusStation.ShowJourney();
                var jorneyId = GetInt("enter the jorney id");
                BusStation.ShowJourneyDetail(jorneyId);
                break;
            }
        case 4:
            {
                BusStation.ShowJourney();
                var jorneyId = GetInt("enter the jorney id");
                BusStation.ShowJourneyDetail(jorneyId);
                var seatNumber = GetInt("enter the seat you want to reserve");
                BusStation.ReserveTicket(jorneyId, seatNumber);
                break;
            }
        case 5:
            {
                BusStation.ShowJourney();
                var jorneyId = GetInt("enter the jorney id");
                BusStation.ShowJourneyDetail(jorneyId);
                var seatNumber = GetInt("enter the seat you want to buy");
                BusStation.SellTicket(jorneyId, seatNumber);
                break;
            }
        case 6:
            {
                BusStation.ShowJourney();
                var jorneyId = GetInt("enter the jorney id");
                BusStation.ShowJourneyDetail(jorneyId);
                var seatNumber = GetInt("enter the seat you want to canceal");
                BusStation.CancealTicket(jorneyId, seatNumber);
                break;
            }
        case 7:
            {
                BusStation.ShowJourney();
                var jorneyId = GetInt("enter the jorney id");
                BusStation.ShowJourneyReport(jorneyId);
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