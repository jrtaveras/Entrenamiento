using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using Wisej.Web.Ext.GoogleMaps;

namespace WisejWebApplication1.Helpers.MapsHelpers
{
    public class LatLngHelpers
    {
        public static bool TryParse(string value, out LatLng latLng)
        {
            Regex regex = new Regex(@"^((\-?|\+?)?\d+(\.\d+)?)\s*,\s*((\-?|\+?)?\d+(\.\d+)?)$");
            Match match = regex.Match(value);

            latLng = new LatLng() { Lat = -1, Lng = -1 };
            try
            {
                if (match.Success)
                {
                    string[] coords = match.Value.Split(',');
                    latLng.Lat = double.Parse(coords[0]);
                    latLng.Lng = double.Parse(coords[1]);
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

    }
}