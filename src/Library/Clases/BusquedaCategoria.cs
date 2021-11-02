using System;
using System.Collections.Generic;

namespace Library
{

    /// <summary>
    /// Busqueda por categoría. Recorre la lista de todas las publicaciones y devuelve una lista con las coincidencias en categoría.
    /// Se decide crear esta clase para cumplir SRP ya que, esta se encarga solo de realizar la búsqueda por categoría.
    /// Esta clase colabora con BuscarPublicacionHandler.
    /// </summary>
    public class BusquedaCategoria
    {
        /// <summary>
        /// Toma como parámetro una lista de categorías y recorre la lista de publicaciones buscando coincidencias.
        /// </summary>
        /// <param name="categorias"></param>Lista de categorías, son pedidas por el handler al usuario.
        /// <returns></returns>
        public List<Publicacion> Buscar(List<string> categorias)
        {
            List<Publicacion> result = new List<Publicacion>();

            foreach (Publicacion publicacion in RegistroPublicaciones.Activas) //Donde estan gaurdadas las publicaciones?
            {
                bool found = false;
                int keyWordsPos = 0;
                while (!found && keyWordsPos < categorias.Count)
                {

                    if (publicacion.Material.Categoria.Contains(categorias[keyWordsPos]))  //Categorias?? es de la publicacion o esta dentro de DatosMateriales

                    {
                        result.Add(publicacion);
                        keyWordsPos++ ;
                        found = true;
                    }
                }
            }

            return result;
        }
    }
}