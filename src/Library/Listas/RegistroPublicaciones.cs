// -----------------------------------------------------------------------
// <copyright file="RegistroPublicaciones.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Library
{
    /// <summary>
    /// Clase que tiene un registro de las publicaciones activas, eliminadas y pausadas. Tiene la responsabilidad de conocer el estados de las publicaciones.
    /// Se definen los métodos para encapsular la clase y poder modificar los datos
    /// sin tener que compartir la información de las listas, cumpliendo con el
    /// patrón Expert.
    /// </summary>
    public class RegistroPublicaciones : IJsonConvertible, IMostrar
    {
        /// <summary>
        /// Lista con las publicaciones activas.
        /// Utiliza el patrón de diseño Singleton para que el atributo sea único y global.
        /// </summary>
        /// <returns>Lista con las publicaciones activas.</returns>
        public List<Publicacion> Activas { get; set; } = Singleton<List<Publicacion>>.Instance;

        /// <summary>
        /// Método para agregar una nueva publicación a la lista de publicaciones activas.
        /// </summary>
        /// <param name="publicacion">Publicación a agregar a la lista de publicaciones activas.</param>
        public void Add(Publicacion publicacion)
        {
            if (!this.Activas.Contains(publicacion))
            {
                this.Activas.Add(publicacion);
            }
        }

        /// <summary>
        /// Método para eliminar una publicación. Se agrega la misma a la lista de publicaciones eliminadas y se remueve de la
        /// lista de publicaciones activas y publicaciones pausadas.
        /// </summary>
        /// <param name="publi">Publicación a eliminar.</param>
        public void EliminarPublicacion(Publicacion publi)
        {
            foreach (Publicacion publicaciones in this.Activas)
            {
                if (publicaciones.Equals(publi))
                {
                    this.Activas.RemoveAt(this.Activas.IndexOf(publicaciones));
                }
            }
        }

        /// <summary>
        /// Método para mostrar la lista pasada como parámetro en pantalla.
        /// </summary>
        /// <param name="lista">Lista que se desea mostrar.</param>
        /// <returns>Devuelve el stringbuilder con los elementos de la lista.<returns>
        public StringBuilder Mostrar(List<IConversorTexto> lista)
        {
            StringBuilder resultado = new StringBuilder();
            if (lista != null)
            {
                foreach (IConversorTexto item in lista)
                {
                    resultado.Append(item.ConvertToString());
                }
            }
            else
            {
                resultado.Append("No se encontraron elementos para mostrar.");
            }

            return resultado;
        }

        /// <summary>
        /// El CovertToJson es el método por el cual se guardan los datos dentro de un archivo json.
        /// </summary>
        /// <returns>Guarda los datos en un archivo json.</returns>
        public string ConvertToJson()
        {
            return JsonSerializer.Serialize(Singleton<List<Publicacion>>.Instance);
        }

        /// <summary>
        /// LoadFromJson se encarga de cargar los datos guardados creando los objetos a partir de el archivo json.
        /// </summary>
        /// <param name="json">Carga los datos de un archivo json.</param>
        public void LoadFromJson(string json)
        {
            List<Publicacion> listaPubl = new List<Publicacion>();
            listaPubl = JsonSerializer.Deserialize<List<Publicacion>>(json);
            this.Activas = listaPubl;
        }
    }
}