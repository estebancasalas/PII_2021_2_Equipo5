// -----------------------------------------------------------------------
// <copyright file="ListaDeUsuario.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Library
{
    /// <summary>
    /// Clase que modela un contenedor de los usuarios que han interactuado con el bot.
    /// Tiene la responsabilidad de conocer todos los usuario, verificar si un Id tiene un objeto Usuario asociado,
    /// y tambien realizar la misma busqueda pero retornando el indice del usuario dentro de la lista.
    /// Depende de la Clase Usuario.
    /// Implementa IJsonConvertible para depender de una abstracción y no directamente de los metodos de Json.Serialization. (DIP).
    /// </summary>
    public class ListaDeUsuario : IJsonConvertible
    {
        /// <summary>
        /// Obtiene o establece la lista que contiene los usuarios que han interactuado con el bot.
        /// Utiliza el patrón de diseño Singleton para que el atributo sea único y global.
        /// No es readonly para facilitar el testing.
        /// </summary>
        /// <returns>Lista que contiene a todos los usuarios.</returns>
        [JsonInclude]
        public List<Usuario> ListaUsuarios = Singleton<List<Usuario>>.Instance;

        /// <summary>
        /// Método que verifica si un id está registrado como usuario.
        /// </summary>
        /// <param name="id">Id que se verifica.</param>
        /// <returns>Devuelve true si el id está en la lista, false en otros casos.</returns>
        public bool EstaRegistrado(long id)
        {
            IUsuario usuario = this.ListaUsuarios.Find(x => x.Id == id);
            return usuario != null;
        }

        /// <summary>
        /// Método que devuelve la posición del usuario en la lista.
        /// </summary>
        /// <param name="id">Id del usuario que se quiere buscar.</param>
        /// <returns>Índice del usuario en la lista.</returns>
        public int Buscar(long id)
        {
            Usuario usuario = this.ListaUsuarios.Find(x => x.Id == id);
            return this.ListaUsuarios.IndexOf(usuario);
        }

        /// <summary>
        /// Método que crea una instancia de esta clase y convierte su atributo ListaUsuarios en un string
        /// en formato json.
        /// </summary>
        /// <returns>String en formato json.</returns>
        public string ConvertToJson()
        {
            return JsonSerializer.Serialize(Singleton<List<Usuario>>.Instance);
        }

        /// <summary>
        /// Método que crea una instancia de esta clase y, a partir de un string en formato json, carga los Usuarios al
        /// atributo ListaUsuarios del objeto.
        /// </summary>
        /// <param name="json">String en formato json.</param>
        public void LoadFromJson(string json)
        {
            List<Usuario> listaUsers = new List<Usuario>();
            listaUsers = JsonSerializer.Deserialize<List<Usuario>>(json);
            this.ListaUsuarios = listaUsers;
        }

        /// <summary>
        /// Se crea el método Add para añadir un Usuario a la Lista evitando duplicados.
        /// Se pone en esta clase para cumplir el patrón Expert ya que es la que conoce
        /// a todos los Usuarios.
        /// </summary>
        /// <param name="usuario">Usuario que se va a agregar a la lista.</param>
        public void Add(Usuario usuario)
        {
            if (!this.ListaUsuarios.Contains(usuario))
            {
                this.ListaUsuarios.Add(usuario);
            }
        }
    }
}