using TravelRepublic.FlightCodingTest;

namespace LebelTestApp.Models;

public class ArrivalBeforeDepartureDate : IFilterStrategy
{
    public bool IsValid(Flight flight) => flight.Segments.Any(s => s.DepartureDate > s.ArrivalDate);
}
