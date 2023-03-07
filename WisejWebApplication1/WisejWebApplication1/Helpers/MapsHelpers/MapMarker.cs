using Wisej.Web.Ext.GoogleMaps;

namespace WisejWebApplication1.Helpers.MapsHelpers
{
    public class MapMarker
    {
        public static MapMarker<string> Create(string id, string position, string label = null)
        {
            return new MapMarker<string>(id, position)
            {
                Label = string.IsNullOrWhiteSpace(label) ? string.Empty : label
            };
        }
        public static MapMarker<LatLng> Create(string id, LatLng position, string label = null)
        {
            return new MapMarker<LatLng>(id, position)
            {
                Label = string.IsNullOrWhiteSpace(label) ? string.Empty : label
            };
        }

    }

    public class MapMarker<T>
    {
        public string Id { get; set; }
        public T Position { get; set; }
        public string Label { get; set; }

        public MapMarker(string id, T position)
        {
            Id = id;
            Position = position;
        }
    }

}