using System;
using LocationApi;
using System.Threading.Tasks;

namespace Library
{
    /// <summary>
    /// Esta clase se encarga de generar una ubicación utilizando la API Location.
    /// Utliza la interzaz IUbicacion para facilitar la extensión de varias ubicaciones de 
    /// un mismo cliente.
    /// </summary>
    public class Ubicacion : IUbicacion
    {
        /// <summary>
        /// GetUbicacion es el método que al pasarle una ubicación la convierte en las coordenadas
        /// de la misma. 
        /// </summary>
        /// <param name="ubicacion">Es la dirección que pasa el cliente.</param> 
        /// <returns></returns>
        public async Task <Location> GetUbicacion(string ubicacion)
        {
            LocationApiClient client = new LocationApiClient();
            Location location = await client.GetLocation(ubicacion);

            return location;
            
        }


    }
}

