// -----------------------------------------------------------------------
// <copyright file="RegistroPublicaciones.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Library
{
    /// <summary>
    /// Clase que tiene un registro de las publicaciones activas, eliminadas y pausadas. Tiene la responsabilidad de conocer el estados de las publicaciones.
    /// Se definen los métodos para encapsular la clase y poder modificar los datos
    /// sin tener que compartir la información de las listas, cumpliendo con el
    /// patrón Expert.
    /// </summary>
    public class RegistroPublicaciones : IJsonConvertible
    {
        /// <summary>
        /// Lista con las publicaciones activas.
        /// Utiliza el patrón de diseño Singleton para que el atributo sea único y global.
        /// </summary>
        /// <returns></returns>
        public List<Publicacion> Activas { get; set; } = Singleton<List<Publicacion>>.Instance;

        /// <summary>
        /// Lista con las publicaciones que fueron eliminadas.
        /// Utiliza el patrón de diseño Singleton para que el atributo sea único y global.
        /// </summary>
        /// <returns></returns>
        public List<Publicacion> Eliminadas = Singleton<List<Publicacion>>.Instance;

        /// <summary>
        /// Lista con las publicaciones pausadas.
        /// Utiliza el patrón de diseño Singleton para que el atributo sea único y global.
        /// </summary>
        /// <returns></returns>
        public List<Publicacion> Pausadas = Singleton<List<Publicacion>>.Instance;

        /// <summary>
        /// Método para agregar una nueva publicación a la lista de
        /// publicaciones activas.
        /// </summary>
        /// <param name="publi">Publicación a añadir.</param>
        public void Add(Publicacion publi)
        {
            this.Activas.Add(publi);
        }

        /// <summary>
        /// Método para pausar una publicación. Agrega dicha publicación a
        /// la lista de publicaciones pausadas y la remueve de la lista de
        /// publicaciones activas.
        /// </summary>
        /// <param name="publi">Publicación a pausar.</param>
        public void PausarPublicacion(Publicacion publi)
        {
            foreach (Publicacion publicaciones in Activas)
            {
                if (publicaciones.Equals(publi))
                {
                    this.Pausadas.Add(publicaciones);
                    this.Activas.RemoveAt(Activas.IndexOf(publicaciones));
                }
            }
        }

        /// <summary>
        /// Método para eliminar una publicación. Se agrega la misma a la lista de
        /// publicaciones eliminadas y se remueve de la lista de publicaciones activas
        /// y publicaciones pausadas.
        /// </summary>
        /// <param name="publi">Publicación a eliminar.</param>
        public void EliminarPublicacion(Publicacion publi)
        {
            foreach (Publicacion publicaciones in Activas)
            {
                if (publicaciones.Equals(publi))
                {
                    this.Eliminadas.Add(publicaciones);
                    this.Activas.RemoveAt(Activas.IndexOf(publicaciones));
                }
            }

            foreach (Publicacion publicaciones in Pausadas)
            {
                if (publicaciones.Equals(publi))
                {
                    this.Eliminadas.Add(publicaciones);
                    this.Pausadas.RemoveAt(Pausadas.IndexOf(publicaciones));
                }
            }
        }

        /// <summary>
        /// El CovertToJson es el método por el cual se guardan los datos dentro de un archivo
        /// json.
        /// </summary>
        /// <returns></returns>
        public string ConvertToJson()
        {
            return JsonSerializer.Serialize(Singleton<List<Publicacion>>.Instance);
        }

        /// <summary>
        /// LoadFromJson se encarga de cargar los datos guardados creando los objetos
        /// a partir de el archivo json.
        /// </summary>
        /// <param name="json"></param>
        public void LoadFromJson(string json)
        {
            List<Publicacion> listaPubl = new List<Publicacion>();
            listaPubl = JsonSerializer.Deserialize<List<Publicacion>>(json);
            this.Activas = listaPubl;
        }

        // Solo una lista general a convertir o las 3 listas - Activas -Pausadas -¿¿Eliminadas???? Para que guardar algo eliminado no tiene sentido.
    }
}