using System;
using Wisej.Web.Ext.GoogleMaps;

namespace WisejWebApplication1.Helpers.MapsHelpers
{
    public class MapPolyline
    {
        public LatLng [] Path { get; set; }
        public bool Geodesic { get; set; }
        public string StrokeColor { get; set; }

        private double _strokeOpacity;
        public double StrokeOpacity 
        {
          get => _strokeOpacity;
          set
          {
             if(value < 0 || value > 1)
             {
                throw new InvalidOperationException("The value of strokeOpacity must be between 0-1");
             }
             _strokeOpacity = value;
          }
        }

        public double StrokeWeight { get; set; }
    }

}