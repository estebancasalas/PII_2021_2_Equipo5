using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Library
{
    /// <summary>
    /// ListaDeUsuario es quien se encarga de tener la lista con todos los 
    /// usuarios registrados, siendo los usuarios las empresas y emprendedores.  
    /// Se implementa esta lista con un tipo genérico para expandir los usos en otras clases.
    /// </summary>
    public class ListaDeUsuario : IJsonConvertible
    {
        /// <summary>
        /// Lista que contiene a todos los ususarios.
        /// Utiliza el patrón de diseño Singleton para que el atributo sea único y global.
        /// </summary>
        /// <returns></returns>
        public List<IUsuario> ListaUsuarios = Singleton<List<IUsuario>>.Instance; 
        /// <summary>
        /// Método que verifica si un id está registrado como usuario.
        /// </summary>
        /// <param name="id">Id que se verifica</param>
        /// <returns></returns>
        public bool EstaRegistrado(int id)
        {
            IUsuario usuario = this.ListaUsuarios.Find(x => x.Id == id);
            return usuario != null;
        }
        public int Buscar(int id)
        {
            IUsuario usuario = this.ListaUsuarios.Find(x => x.Id == id);
            return this.ListaUsuarios.IndexOf(usuario);
        }
        /// <summary>
        /// El CovertToJson es el método por el cual se guardan los datos dentro de un archivo
        /// json.
        /// </summary>
        /// <returns></returns>
        public string ConvertToJson()
        {
            return JsonSerializer.Serialize(Singleton<List<int>>.Instance);
        }
        /// <summary>
        /// LoadFromJson se encarga de cargar los datos guardados creando los objetos 
        /// a partir de el archivo json. 
        /// </summary>
        /// <param name="json"></param>
        public void LoadFromJson(string json)
        {
            List<IUsuario> listaUsers = new List<IUsuario>();
            listaUsers = JsonSerializer.Deserialize<List<IUsuario>>(json);
            this.ListaUsuarios = listaUsers;
        }
        /// <summary>
        /// Se crea el método Add para añadir un IdUsuario a la ListaDeUsuario
        /// ya existente. 
        /// Se pone en esta clase para cumplir el patrón Expert ya que es la que conoce
        /// los id de todos los usuarios.
        /// </summary>
        /// <param name="usuario">Usuario que se va a agregar a la lista</param>
        public void Add(IUsuario usuario)
        {
            this.ListaUsuarios.Add(usuario);
        }
    }
    // Checkear si cuando se registran se agregan idSSS.
}