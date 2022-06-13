using TravelRepublic.FlightCodingTest;

namespace LebelTestApp.Models;

public class MaxTimeSpentStationary : IFilterStrategy
{
    private readonly TimeSpan _maxWaitingTime;

    public MaxTimeSpentStationary(TimeSpan maxWaitingTime)
    {
        _maxWaitingTime = maxWaitingTime;
    }

    public bool IsValid(Flight flight)
    {
        if (flight.Segments.Count() == 1) return false;

        var segGap = new TimeSpan();

        for (var index = 0; index < (flight.Segments.Count() - 1); index++)
        {
            var segmentGap = flight.Segments[index + 1].DepartureDate.Subtract(flight.Segments[index].ArrivalDate);
            segGap += segmentGap;
        }

        if (segGap > _maxWaitingTime) return true;

        return false;
    }
}
