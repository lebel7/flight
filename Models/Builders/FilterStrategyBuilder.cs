using LebelTestApp.Models;

namespace LebelTestApp;

public class FilterStrategyBuilder
{
    public FilterStrategyBuilder()
    {

    }

    public IList<IFilterStrategy> GetGlobalDataFilter()
    {
        return new List<IFilterStrategy>()
        {
            //new DepartBeforeCurrentDateTime(),
            new ArrivalBeforeDepartureDate(),
            //new MaxTimeSpentStationary(TimeSpan.FromHours(2))
        };
    }
}
