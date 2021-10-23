
using System;

namespace ConsoleApplication
{
    /// <summary>
    /// Busqueda por palabras clave. Recorre la lista de todas las publicaciones y devuelve una lista con las coincidencias.
    /// </summary>
    public class BusquedaKeyWord : Busqueda
    {
        public static List<Publicacion> Buscar(string tipoDeBusqueda, string input)
        {
            List<Publicacion> result = new List<Publicacion>();
            
            //Pedir las palabras clave

            List<string> keyWords = new List<string>();

            foreach (Publicacion publicacion in RegistroPublicaciones)
            {
                bool found = false;
                int keyWordsPos = 0;
                while (!found && keyWordsPos < keyWords.Count)
                {
                    if (publicacion.PalabrasClave.Contains(keyWords[keyWordsPos]))
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