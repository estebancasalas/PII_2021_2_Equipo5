using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Clase que tiene un registro de las publicaciones activas, eliminadas y 
    /// pausadas. Tiene la responsabilidad de conocer el estados de las publicaciones.
    /// Se definen los métodos para encapsular la clase y poder modificar los datos
    /// sin tener que compartir la información de las listas, cumpliendo con el
    /// patrón Expert.
    /// </summary>
    public class RegistroPublicaciones
    {
        /// <summary>
        /// Lista con las publicaciones activas.
        /// </summary>
        /// <returns></returns>
        public static List<Publicacion> Activas {get; set;} = new List<Publicacion>();
        /// <summary>
        /// Lista con las publicaciones que fueron eliminadas.
        /// </summary>
        /// <returns></returns>
        public static List<Publicacion> Eliminadas = new List<Publicacion>();
        /// <summary>
        /// Lista con las publicaciones pausadas.
        /// </summary>
        /// <returns></returns>
        public static List<Publicacion> Pausadas = new List<Publicacion>();

        /// <summary>
        /// Método para agregar una nueva publicación a la lista de 
        /// publicaciones activas.
        /// </summary>
        /// <param name="publi">Publicación a añadir</param>
        public static void AñadirNuevaPublicacion(Publicacion publi)
        {
            RegistroPublicaciones.Activas.Add(publi);
        }
        /// <summary>
        /// Método para pausar una publicación. Agrega dicha publicación a
        /// la lista de publicaciones pausadas y la remueve de la lista de 
        /// publicaciones activas.
        /// </summary>
        /// <param name="publi">Publicación a pausar</param>
        public static void PausarPublicacion(Publicacion publi)
        {
            foreach (Publicacion publicaciones in Activas)
            {
                if (publicaciones.Equals(publi))
                {
                    RegistroPublicaciones.Pausadas.Add(publicaciones);
                    RegistroPublicaciones.Activas.RemoveAt(Activas.IndexOf(publicaciones));
                }
            }
        }
        /// <summary>
        /// Método para eliminar una publicación. Se agrega la misma a la lista de
        /// publicaciones eliminadas y se remueve de la lista de publicaciones activas
        /// y publicaciones pausadas.
        /// </summary>
        /// <param name="publi">Publicación a eliminar</param>
        public static void EliminarPublicacion(Publicacion publi)
        {
            foreach (Publicacion publicaciones in Activas)
            {
                if (publicaciones.Equals(publi))
                {
                    RegistroPublicaciones.Eliminadas.Add(publicaciones);
                    RegistroPublicaciones.Activas.RemoveAt(Activas.IndexOf(publicaciones));
                }
            }

            foreach (Publicacion publicaciones in Pausadas)
            {
                if (publicaciones.Equals(publi))
                {
                    RegistroPublicaciones.Eliminadas.Add(publicaciones);
                    RegistroPublicaciones.Pausadas.RemoveAt(Pausadas.IndexOf(publicaciones));
                }
            }
        }
    }
}