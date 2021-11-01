using System;
using LocationApi;
using System.Threading.Tasks;

namespace Library
{
    public class Ubicacion : IUbicacion
    {
        public async Task <Location> GetUbicacion(string ubicacion)
        {
            LocationApiClient client = new LocationApiClient();
            Location location = await client.GetLocation(ubicacion);
            //string coordenadas = $"Latitud: {location.Latitude}, Longitud: {location.Longitude}";

            return location;
            
        }


    }
}

