using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Busqueda por palabras clave. Recorre la lista de todas las publicaciones y devuelve una lista con las coincidencias.
    /// </summary>
    public class BusquedaCategoria
    {
        public List<Publicacion> Buscar(List<string> categorias)
        {
            List<Publicacion> result = new List<Publicacion>();

            foreach (Publicacion publicacion in RegistroPublicaciones) //Donde estan gaurdadas las publicaciones?
            {
                bool found = false;
                int keyWordsPos = 0;
                while (!found && keyWordsPos < categorias.Count)
                {
                    if (publicacion.Categoria.Contains(categorias[keyWordsPos]))  //Categorias?? es de la publicacion o esta dentro de DatosMateriales
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