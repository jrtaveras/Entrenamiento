using System;
using System.Collections.Generic;
using System.Linq;
using Wisej.Web.Ext.GoogleMaps;

namespace WisejWebApplication1.Helpers.MapsHelpers
{
    public static class DirectionRequest
    {
        public static DirectionRequest<LatLng, LatLng, LatLng> CreateDirection(LatLng origin, LatLng destination, IEnumerable<LatLng> wayPoints, bool optimizeRoutes = false)
        {
            return new DirectionRequest<LatLng, LatLng, LatLng>()
            {
                Origin = origin,
                Destination = destination,
                WayPoints = wayPoints,
                OptimizeRoutes = optimizeRoutes
            };
        }
        public static DirectionRequest<string, string, string> CreateDirection(string origin, string destination, IEnumerable<string> wayPoints, bool optimizeRoutes = false)
        {
            return new DirectionRequest<string, string, string>()
            {
                Origin = origin,
                Destination = destination,
                WayPoints = wayPoints,
                OptimizeRoutes = optimizeRoutes
            };
        }

        public static DirectionRequest<string, string, LatLng> CreateDirection(string origin, string destination, IEnumerable<LatLng> wayPoints, bool optimizeRoutes = false)
        {
            return new DirectionRequest<string, string, LatLng>()
            {
                Origin = origin,
                Destination = destination,
                WayPoints = wayPoints,
                OptimizeRoutes = optimizeRoutes
            };
        }
        public static DirectionRequest<LatLng, string, LatLng> CreateDirection(LatLng origin, string destination, IEnumerable<LatLng> wayPoints, bool optimizeRoutes = false)
        {
            return new DirectionRequest<LatLng, string, LatLng>()
            {
                Origin = origin,
                Destination = destination,
                WayPoints = wayPoints,
                OptimizeRoutes = optimizeRoutes
            };
        }
        public static DirectionRequest<string, LatLng, LatLng> CreateDirection(string origin, LatLng destination, IEnumerable<LatLng> wayPoints, bool optimizeRoutes = false)
        {
            return new DirectionRequest<string, LatLng, LatLng>()
            {
                Origin = origin,
                Destination = destination,
                WayPoints = wayPoints,
                OptimizeRoutes = optimizeRoutes
            };
        }
        public static DirectionRequest<LatLng, LatLng, string> CreateDirection(LatLng origin, LatLng destination, IEnumerable<string> wayPoints, bool optimizeRoutes = false)
        {
            return new DirectionRequest<LatLng, LatLng, string>()
            {
                Origin = origin,
                Destination = destination,
                WayPoints = wayPoints,
                OptimizeRoutes = optimizeRoutes
            };
        }

    }

    public class DirectionRequest<Torigin, Tdestination, TWayPoints>
    {
        public Torigin Origin { get; set; }
        public Tdestination Destination { get; set; }
        public IEnumerable<TWayPoints> WayPoints { get; set; }

        public bool OptimizeRoutes { get; set; }

        public string GetOriginAsString()
        {
            if(Origin is string origin)
            {
                return origin;
            }

            if(Origin is LatLng originCoors)
            {
                return originCoors.ToGoogleMapString();
            }

            throw new InvalidOperationException($"The origin is not a valid type");
        }
        public string GetDestinationAsString()
        {
            if (Destination is string destination)
            {
                return destination;
            }

            if (Origin is LatLng destinationCoors)
            {
                return destinationCoors.ToGoogleMapString();
            }

            throw new InvalidOperationException($"The destination is not a valid type");
        }
        public string GetwayPointsAsString()
        {
            if (WayPoints is IEnumerable<string> wayPoints)
            {
                return string.Join("|", wayPoints);
            }

            if (WayPoints is IEnumerable<LatLng> wayPointsCoords)
            {
                return string.Join("|", wayPointsCoords.Select(l => l.ToGoogleMapString()));
            }

            throw new InvalidOperationException($"The waipoints are not a valid types");
        }

        public DirectionRequest<string, string, string> GetDirectionRequestWithStrings()
        {
            IEnumerable<string> newWayPoints;
            if (WayPoints is IEnumerable<string> wayPoints)
            {
                newWayPoints = wayPoints;
            }
            else if(WayPoints is IEnumerable<LatLng> wayPointsCoords)
            {
                newWayPoints = wayPointsCoords.Select(l => l.ToGoogleMapString());
            }
            else
            {
                throw new InvalidOperationException($"The waipoints are not a valid types");
            }

            return new DirectionRequest<string, string, string>()
            {
                Origin = this.GetOriginAsString(),
                Destination = this.GetDestinationAsString(),
                WayPoints = newWayPoints,
                OptimizeRoutes = this.OptimizeRoutes,
            };
        }
    }

}