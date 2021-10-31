using System.Threading.Tasks;
using System.Collections.Generic;
using LocationApi;

namespace Library
{
    /// <summary>
    /// Busqueda por palabras clave. Recorre la lista de todas las publicaciones y devuelve una lista con las coincidencias.
    /// </summary>
    public class BusquedaZona
    {
        public List<Publicacion> Buscar(string tipoZona ,string ubicacion)
        {
            /*
            LocationApiClient client = new LocationApiClient();
            Location location = await client.GetLocation(ubicacion);
            */
            List<Publicacion> result = new List<Publicacion>();
            
            if (tipoZona == "1")
            {
                foreach (Publicacion publicacion in RegistroPublicaciones.Activas)
                {
                    if (publicacion.Ubicacion.Locality == ubicacion)
                    {
                        result.Add(publicacion);
                    }
                }
            }
            else if (tipoZona == "2")
            {
                foreach (Publicacion publicacion in RegistroPublicaciones.Activas)
                {
                    if (publicacion.Ubicacion.Locality == ubicacion)
                    {
                        result.Add(publicacion);
                    }
                }
            }
            

            return result;
        }
    }
}