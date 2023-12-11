using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wisej.Web.Ext.GoogleMaps;
using WisejWebApplication1.DTOS.GoogleRoutes.JsonObjects;
using WisejWebApplication1.DTOS.GrassHopperApi.JsonObjects;
using WisejWebApplication1.Helpers.MapsHelpers;

namespace WisejWebApplication1.Helpers.CoordsHelper
{
    public static class CoordsFactory
    {
        public static readonly LatLng Origin = new LatLng(){Lat = 18.4286193,Lng = -69.9901347};

        public readonly static LatLng[] Coords = {

            new LatLng() { Lat = 18.486735,  Lng = -69.838716 },  //1  - Pricesmart
            new LatLng() { Lat = 18.487827,  Lng = -69.840277 },  //2  - Parque italia
            new LatLng() { Lat = 18.485623,  Lng = -69.840302 },  //3  - Sirena
            new LatLng() { Lat = 18.4330018, Lng = -69.9804261 }, //4  - Capilla El Pedregal
            new LatLng() { Lat = 18.4358334, Lng = -69.9582849 },  //5  - Sirena independencia
            new LatLng() { Lat = 18.4272729, Lng = -70.0097811 }, //6  - HIT - Puerto Río Haina
            new LatLng() { Lat = 18.4526002, Lng = -69.9725369 }, //7  - Junta central electoral
            new LatLng() { Lat = 18.4598137, Lng = -69.9765106 }, //8  - Catamovil
            new LatLng() { Lat = 18.489347,  Lng = -69.952681 },  //9  - Av. los proceres jardin botanico
            new LatLng() { Lat = 18.4781637, Lng = -69.917023 }, //10 - Olimpico
            new LatLng() { Lat = 18.4795143, Lng = -69.9004269 }, //11 - Barra Payan
            new LatLng() { Lat = 18.4706288, Lng = -69.8855275 }, //12 - Okra restaurant cuidad colonial,
            new LatLng() { Lat = 18.4271231, Lng = -69.9723815 }, //13 - JyCA Auto SRL
            new LatLng() { Lat = 18.4287317, Lng = -69.9690898 }, //14 - Grupo Frío Integral, SRL
            new LatLng() { Lat = 18.4296858, Lng = -69.9696563 }, //15 - Ruiz Villar Mini Market
            new LatLng() { Lat = 18.4322468, Lng = -69.9664783 }, //16 - Gold Gym Independencia
            new LatLng() { Lat = 18.4330308, Lng = -69.9594082 }, //17 - Club Miramar
            new LatLng() { Lat = 18.4593872, Lng = -69.9884425 }, //18 - Centro De Estudios Delin
            new LatLng() { Lat = 18.4622565, Lng = -69.983652 },  //19 - Centro de Atención Primaria Libertador de Herrera
            new LatLng() { Lat = 18.4571146, Lng = -69.9624126 }, //20 - Colegio Serafín de Asís
            new LatLng() { Lat = 18.4670622, Lng = -69.94312 }, //21 - Cultura Cervecera
            new LatLng() { Lat = 18.4779119, Lng = -69.9288724 }, //22 - Radisson Hotel Santo Domingo
            new LatLng() { Lat = 18.4883819, Lng = -69.9263068 }, //23 - Estadio Quisqueya Juan Marichal
            new LatLng() { Lat = 18.4923193, Lng =  -69.911948 }, //24 - Maximo Gomez National Cemetery
            new LatLng() { Lat = 18.480839,  Lng = -69.8894423 }, //25 - Enriquillo Park
            new LatLng() { Lat = 18.4785774, Lng = -69.8681807 }, //26 - Faro a Colón, Santo Domingo Este
            new LatLng() { Lat = 18.4685891, Lng = -69.8409253 }, //27 - Mixer Bar and Lounge
            new LatLng() { Lat = 18.4807191, Lng = -69.8113151 }, //28 - San Miguel industries SDO this (KOLA REAL)
            new LatLng() { Lat = 18.4747771, Lng = -69.7821577}, //29 - La Cueva del Edén
            new LatLng() { Lat = 18.4762166, Lng = -69.7539933 }, //30 - Club of the Directorate General of Customs (DGA)
        };
        
        public static IEnumerable<GoogleMapRouteLocation> GetMapLocations()
        {
            return Coords.Select(c => c.ToMapLocation());
        }

        public static GraphhopperService[] GetGrassHopperServices()
        {
            return Coords.Select(c => {

                string id = Guid.NewGuid().ToString();
                return new GraphhopperService()
                {
                    Id = id,
                    Name = $"Visit {id}",
                    Address = c.ToGrassHooperAddress(),
                };

            })
            .ToArray();
        }
    }

}