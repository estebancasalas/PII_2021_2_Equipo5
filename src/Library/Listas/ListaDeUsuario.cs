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
    /// ListaDeUsuario es quien se encarga de tener la lista con todos los usuarios registrados, siendo los usuarios las empresas y
    /// emprendedores.
    /// Depende de las Clases concretas List y Usuario porque necesita ser deserializada desde formato json.
    /// Se implementa esta lista con un tipo genérico para expandir los usos en otras clases.
    /// </summary>
    public class ListaDeUsuario : IJsonConvertible
    {
        /// <summary>
        /// Lista que contiene a todos los ususarios.
        /// Depende de List y Usuario debido a que debe ser deserializada.
        /// Utiliza el patrón de diseño Singleton para que el atributo sea único y global.
        /// </summary>
        /// <returns></returns>
        [JsonInclude]
        public List<Usuario> ListaUsuarios = Singleton<List<Usuario>>.Instance; 

        /// <summary>
        /// Método que verifica si un id está registrado como usuario.
        /// </summary>
        /// <param name="id">Id que se verifica.</param>
        /// <returns></returns>
        public bool EstaRegistrado(long id)
        {
            IUsuario usuario = this.ListaUsuarios.Find(x => x.Id == id);
            return usuario != null;
        }

        public int Buscar(long id)
        {
            Usuario usuario = this.ListaUsuarios.Find(x => x.Id == id);
            return this.ListaUsuarios.IndexOf(usuario);
        }

        /// <summary>
        /// El CovertToJson es el método por el cual se guardan los datos dentro de un archivo
        /// json.
        /// </summary>
        /// <returns></returns>
        public string ConvertToJson()
        {
            return JsonSerializer.Serialize(Singleton<List<Usuario>>.Instance);
        }

        /// <summary>
        /// LoadFromJson se encarga de cargar los datos guardados creando los objetos
        /// a partir de el archivo json.
        /// </summary>
        /// <param name="json"></param>
        public void LoadFromJson(string json)
        {
            List<Usuario> listaUsers = new List<Usuario>();
            listaUsers = JsonSerializer.Deserialize<List<Usuario>>(json);
            this.ListaUsuarios = listaUsers;
        }

        /// <summary>
        /// Se crea el método Add para añadir un IdUsuario a la ListaDeUsuario
        /// ya existente.
        /// Se pone en esta clase para cumplir el patrón Expert ya que es la que conoce
        /// los id de todos los usuarios.
        /// </summary>
        /// <param name="usuario">Usuario que se va a agregar a la lista</param>
        public void Add(Usuario usuario)
        {
            if (!this.ListaUsuarios.Contains(usuario))
            {
                this.ListaUsuarios.Add(usuario);
            }
        }
    }

    // Checkear si cuando se registran se agregan idSSS.
}