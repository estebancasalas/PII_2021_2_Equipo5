using System;
using System.Collections.Generic;
using LocationApi;

namespace Library
{
    /// <summary>
    /// Busqueda por palabras clave. Recorre la lista de todas las publicaciones y devuelve una lista con las coincidencias.
    /// </summary>
    public class BusquedaZona
    {
        public List<Publicacion> Buscar(string tipo ,string ubicacion)
        {
            LocationApiClient client = new LocationApiClient();
            Location location = await client.GetLocation(ubicacion);
            if (tipo == "1")
            {

            }
            

            return result;
        }
    }
}