using TravelRepublic.FlightCodingTest;

namespace LebelTestApp.Models;

public class DepartBeforeCurrentDateTime : IFilterStrategy
{
    public bool IsValid(Flight flight) => flight.Segments.Any(s => s.DepartureDate < DateTime.UtcNow);
}
