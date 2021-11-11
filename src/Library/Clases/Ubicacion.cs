using System;
using Ucu.Poo.Locations.Client;
using System.Threading.Tasks;

namespace Library
{
    
    /// <summary>
    /// Esta clase se encarga de generar una ubicación utilizando la API Location. Utliza la interzaz IUbicacion para facilitar la extensión de varias ubicaciones de un mismo cliente.
    /// </summary>
    public class Ubicacion: IUbicacion
    {
        
        /// <summary>
        /// GetUbicacion es el método que al pasarle una ubicación la convierte en un objeto de tipo Location. 
        /// </summary>
        /// <param name="ubicacion">Es la dirección que pasa el cliente.</param>
        /// <returns></returns>
        public Location GetUbicacion(string ubicacion)
        {
            LocationApiClient client = new LocationApiClient();
            Location location = client.GetLocation(ubicacion);
            return location;
        }
    }
}

