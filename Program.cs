// See https://aka.ms/new-console-template for more information
using TravelRepublic.FlightCodingTest;
using LebelTestApp;
using LebelTestApp.Models;
using System.Text.Json;

var filterThis = new GlobalFilter();
var globalFilters = new FilterStrategyBuilder().GetGlobalDataFilter();
var flights = new FlightBuilder()
    .GetFlights()
    .Where(flight => filterThis.Apply(flight, globalFilters));
var display = JsonSerializer.Serialize(flights) + Environment.NewLine +
    "=====================================================================";
Console.WriteLine(display);


/// <summary>
/// Alternative, Quick and dirty
/// </summary>
var dates = new FlightBuilder().GetFlights();
var datesDepartBeforeCurrentTime = dates.Where(x => x.Segments.Any(s => s.DepartureDate < DateTime.UtcNow));
var datesArrivalBeforeDepart = dates.Where(x => x.Segments.Any(s => s.DepartureDate > s.ArrivalDate));
foreach (var (flightDate, flightSegs) in
from flight in dates
let segs = flight.Segments
select (flight, segs))
{
    for (int j = 0; j < flightSegs.Count - 1; j++)
    {
        flightDate.GapTime += flightSegs[j + 1].DepartureDate.Subtract(flightSegs[j].ArrivalDate);
    }
}
dates.Where(x => x.Segments.Count > 1 && x.GapTime > TimeSpan.FromHours(2));
/// <summary>
/// All together quick n' dirty
/// </summary>
///
//var sampleTogether = dates
//    .Where(x => x.Segments.Any(s => s.DepartureDate < DateTime.UtcNow))
//    .Where(x => x.Segments.Any(s => s.DepartureDate > s.ArrivalDate))
//    .Where(x => x.Segments.Count > 1 && x.GapTime > TimeSpan.FromHours(2));
var displayQuick = JsonSerializer.Serialize(dates);
Console.WriteLine(displayQuick);
Console.ReadKey();