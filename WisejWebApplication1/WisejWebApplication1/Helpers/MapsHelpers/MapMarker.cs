using Wisej.Web.Ext.GoogleMaps;

namespace WisejWebApplication1.Helpers.MapsHelpers
{
    public class MapMarker
    {
        public string Id { get; set; }
        public string Position { get; set; }
        public string Label { get; set; }

        public MapMarker(string id, string position, string label = null)
        {
            Id = id;
            Position = position;
            Label = string.IsNullOrWhiteSpace(label) ? string.Empty : label;

        }
        public MapMarker(string id, LatLng position, string label = null)
        {
            Id = id;
            Position = position.ToGoogleMapString();
            Label = string.IsNullOrWhiteSpace(label) ? string.Empty : label;
        }

    }

}