using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wisej.Web.Ext.GoogleMaps;
using WisejWebApplication1.Helpers.MapsHelpers;

namespace WisejWebApplication1.DTOS.GoogleMaps.GeoCode
{
    public class GoogleMapGeocodeRequest
    {
        private bool _isAddress;
        private bool _isLatLng;
        private bool _isPlaceId;

        public string Address { get; private set; }
        public LatLng Location { get; private set; }
        public string PlaceId { get; private set; }
        /*public string Bounds { get; private set; }
        public string ComponentRestrictions { get; private set; }
        public string Region { get; private set; }*/

        private GoogleMapGeocodeRequest()
        {

        }

        public static GoogleMapGeocodeRequest CreateWithAddress(string address)
        {
            return new GoogleMapGeocodeRequest()
            {
                Address = address,
                _isAddress = true
            };
        }

        public static GoogleMapGeocodeRequest CreateWithLocation(LatLng latLng)
        {
            return new GoogleMapGeocodeRequest()
            {
                Location = latLng,
                _isLatLng = true,
            };
        }

        public static GoogleMapGeocodeRequest CreateWithPlaceId(string placeId)
        {
            return new GoogleMapGeocodeRequest()
            {
                PlaceId = placeId,
                _isPlaceId = true
            };
        }

        public string ToJSON()
        {
            dynamic obj = new System.Dynamic.ExpandoObject();
            if (_isAddress)
            {
                obj.address = this.Address;
            }
            else if (_isLatLng)
            {
                obj.location = this.Location.ToGoogleMapString();
            }
            else if (_isPlaceId)
            {
                obj.placeId = this.PlaceId;
            }
            else
            {
                throw new InvalidOperationException("Cannot determinate the type of the request types are address|location|placeId");
            }

            return JsonConvert.SerializeObject(obj);
        }
        
    }

}