using TravelRepublic.FlightCodingTest;

namespace LebelTestApp.Models
{
    public class GlobalFilter
    {
        public bool Apply(Flight flight, IList<IFilterStrategy> chosenFilterStrategy)
        {
            foreach (var filter in chosenFilterStrategy)
                if (!filter.IsValid(flight)) return false;

            return true;
        }
    }
}
