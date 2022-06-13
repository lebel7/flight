using TravelRepublic.FlightCodingTest;

namespace LebelTestApp.Models
{
    public interface IFilterStrategy
    {
        bool IsValid(Flight flight);
    }
}
