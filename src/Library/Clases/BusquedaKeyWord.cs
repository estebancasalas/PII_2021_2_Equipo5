
using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Busqueda por palabras clave. Recorre la lista de todas las publicaciones y devuelve una lista con las coincidencias.
    /// </summary>
    public class BusquedaKeyWord
    {
        public List<Publicacion> Buscar(List<string> palabras)
        {
            List<Publicacion> result = new List<Publicacion>();

            foreach (Publicacion publicacion in RegistroPublicaciones.Activas) //Donde estan gaurdadas las publicaciones?
            {
                bool found = false;
                int keyWordsPos = 0;
                while (!found && keyWordsPos < palabras.Count)
                {
                    if (publicacion.PalabrasClave.Contains(palabras[keyWordsPos]))  //PalabrasClave private
                    {
                        result.Add(publicacion);
                        keyWordsPos++ ;
                        found = true;
                    }
                }
            }

            return result;
        }
        //Arreglar errores.
    }
}