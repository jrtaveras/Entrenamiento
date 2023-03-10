using System.Collections.Generic;
using System.Linq;
using Wisej.Web.Ext.GoogleMaps;
using WisejWebApplication1.Helpers.MapsHelpers;

namespace WisejWebApplication1.DTOS.GoogleMaps.Direction
{

    public class GoogleMapsDirectionRequest
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public IEnumerable<string> WayPoints { get; set; } = new string[] { };
        public bool OptimizeRoutes { get; set; }

        public GoogleMapsDirectionRequest()
        {

        }

        public GoogleMapsDirectionRequest(string origin, string destination, IEnumerable<string> wayPoints, bool optimizeRoutes = false)
        {
            Origin = origin;
            Destination = destination;
            WayPoints = wayPoints;

            OptimizeRoutes = optimizeRoutes;
        }

        public GoogleMapsDirectionRequest(LatLng origin, LatLng destination, IEnumerable<LatLng> wayPoints, bool optimizeRoutes = false)
        {
            Origin = origin.ToGoogleMapString();
            Destination = destination.ToGoogleMapString();
            WayPoints = GetwayPoints(wayPoints);

            OptimizeRoutes = optimizeRoutes;
        }


        public GoogleMapsDirectionRequest(string origin, string destination, IEnumerable<LatLng> wayPoints, bool optimizeRoutes = false)
        {
            Origin = origin;
            Destination = destination;
            WayPoints = GetwayPoints(wayPoints);

            OptimizeRoutes = optimizeRoutes;
        }

        public GoogleMapsDirectionRequest(LatLng origin, string destination, IEnumerable<LatLng> wayPoints, bool optimizeRoutes = false)
        {
            Origin = origin.ToGoogleMapString();
            Destination = destination;
            WayPoints = GetwayPoints(wayPoints);

            OptimizeRoutes = optimizeRoutes;
        }

        public GoogleMapsDirectionRequest(string origin, LatLng destination, IEnumerable<LatLng> wayPoints, bool optimizeRoutes = false)
        {
            Origin = origin;
            Destination = destination.ToGoogleMapString();
            WayPoints = GetwayPoints(wayPoints);

            OptimizeRoutes = optimizeRoutes;
        }

        public GoogleMapsDirectionRequest(LatLng origin, LatLng destination, IEnumerable<string> wayPoints, bool optimizeRoutes = false)
        {
            Origin = origin.ToGoogleMapString();
            Destination = destination.ToGoogleMapString();
            WayPoints = wayPoints;

            OptimizeRoutes = optimizeRoutes;
        }


        private IEnumerable<string> GetwayPoints(IEnumerable<LatLng> waypoints)
        {
            return waypoints.Select(l => l.ToGoogleMapString()).ToList();
        }

        public string GetwayPointsAsString()
        {
            return string.Join("|", WayPoints);
        }


    }

}