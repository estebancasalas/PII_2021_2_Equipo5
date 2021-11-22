using System;
using System.Collections.Generic;

namespace Library
{

    /// <summary>
    /// Busqueda por categoría. Recorre la lista de todas las publicaciones y devuelve una lista con las coincidencias 
    /// en categoría.
    /// Se decide crear esta clase para cumplir SRP ya que, esta se encarga solo de realizar la búsqueda por categoría.
    /// Esta clase colabora con BuscarPublicacionHandler y BuscarPublicacion.
    /// </summary>
    public class BusquedaCategoria : AbstractBuscar
    {
        /// <summary>
        /// Toma como parámetro una categoría y recorre la lista de publicaciones buscando coincidencias.
        /// </summary>
        /// <param name="categoria">Categoria del material que se quiere buscar.</param>
        /// <returns>Lista de coincidencias.</returns>
        public static List<Publicacion> Buscar(string categoria)
        {
            List<Publicacion> result = new List<Publicacion>();
            List<Publicacion> lista = Singleton<RegistroPublicaciones>.Instance.Activas;

            foreach (Publicacion publicacion in lista)
            {
                if (publicacion.Material.Categoria.Contains(categoria))
                {
                    result.Add(publicacion);
                }
            }
            return result;
        }
    }
}