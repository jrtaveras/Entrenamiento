using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wisej.Web.Ext.GoogleMaps;
using WisejWebApplication1.DTOS;
using WisejWebApplication1.DTOS.GoogleRoutes;
using WisejWebApplication1.DTOS.GoogleRoutes.JsonObjects;
using WisejWebApplication1.DTOS.GrassHopperApi.JsonObjects;

namespace WisejWebApplication1.Helpers.MapsHelpers
{
    public static class LatLngExtentions
    {
        public static string ToGoogleMapString(this GoogleMapDirectionNortheast northeast)
        {
            return $"{northeast.Lat},{northeast.Lng}";
        }
        public static string ToGoogleMapString(this LatLng latLng)
        {
            return $"{latLng.Lat},{latLng.Lng}";
        }

        public static GoogleMapRouteLocation ToMapLocation(this LatLng latLng)
        {
            return new GoogleMapRouteLocation(new GoogleMapRouteMapCoors(latLng.Lat, latLng.Lng));
        }
        public static GraphhopperAddress ToGrassHooperAddress(this LatLng latLng)
        {
            return new GraphhopperAddress(latLng.Lat, latLng.Lng) 
            {
                LocationId = Guid.NewGuid().ToString()
            };
        }
        
        public static LatLng ToLatLng(this GraphhopperAddress address)
        {
            return new LatLng() { Lat = address.Lat, Lng = address.Lon };
        }
        public static LatLng ToLatLng(this GoogleMapRouteLocationCoords location)
        {
            return new LatLng() 
            { 
                Lat = location.LatLng.Latitude,
                Lng = location.LatLng.Longitude
            };
        }

        public static LatLng ToLatLng(this GoogleMapDirectionNortheast location)
        {
            return new LatLng() { Lat = location.Lat, Lng = location.Lng };
        }

    }

}