
using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Busqueda por palabras clave. Recorre la lista de todas las publicaciones y devuelve una lista con las coincidencias 
    /// en palabras clave.
    /// Se decide crear esta clase para cumplir SRP ya que, esta se encarga solo de realizar la búsqueda por Palabras clave.
    /// Esta clase colabora con BuscarPublicacionHandler y BuscarPublicacion.
    /// </summary>
    public class BusquedaKeyWord :AbstractBuscar
    {
        /// <summary>
        /// Busqueda por palabras clave. Recorre la lista de todas las publicaciones y devuelve una lista con las coincidencias.
        /// </summary>
        /// <param name="palabras">Palabra clave que ayuda a la busqueda.</param>
        /// <returns></returns>
        public List<Publicacion> Buscar(string palabras)
        {
            List<Publicacion> result = Singleton<List<Publicacion>>.Instance;

            foreach (Publicacion publicacion in RegistroPublicaciones.Activas) 
            {
                if (publicacion.PalabrasClave.Contains(palabras))  
                {
                    result.Add(publicacion);
                }
            }
            return result;
        }   
    }
}