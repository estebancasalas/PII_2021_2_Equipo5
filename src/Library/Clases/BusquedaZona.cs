using System.Threading.Tasks;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Busqueda por zona. Recorre la lista de todas las publicaciones y devuelve una lista con las coincidencias en zona.
    /// Se decide crear esta clase para cumplir SRP ya que, esta se encarga solo de realizar la búsqueda por zona.
    /// Esta clase colabora con BuscarPublicacionHandler.
    /// </summary>
    public class BusquedaZona
    {
        /// <summary>
        /// Busqueda por zona. Recorre la lista de todas las publicaciones y devuelve una lista con las coincidencias.
        /// </summary>
        public List<Publicacion> Buscar(string tipoZona ,string ubicacion)
        {
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
    //Implemetar API
}