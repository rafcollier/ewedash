using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EweDash.Models
{
    public class OCTranspoModel
    {
        public NextTripModel GetNextTripsForStopResult { get; set; }
    }

    public class NextTripModel
    {
        public string StopLabel { get; set; }
        public RouteModel Route { get; set; }
    }

    public class RouteModel
    {
        public List<RouteDirectionObjects> RouteDirection { get; set;}
    }

    public class RouteDirectionObjects
    {
        public string RouteNo { get; set; }
        public string RouteLabel { get; set; }
        public TripsModel Trips { get; set; }

    }

    public class TripsModel
    {
        public List<TripObjects> Trip { get; set; }

    }

    public class TripObjects
    {

        public string TripStartTime { get; set; }

    }
}
