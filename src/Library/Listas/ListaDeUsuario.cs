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
        /// </summary>
        /// <returns></returns>
        public List<int> IdUsuarios = Singleton<List<int>>.Instance; 

        public bool EstaRegistrado(int id)
        {
            return IdUsuarios.Contains(id);
        }

        public string ConvertToJson()
        {
            return JsonSerializer.Serialize(this);
        }
        public void LoadFromJson(string json)
        {
            ListaDeUsuario listaUsers = new ListaDeUsuario();
            listaUsers = JsonSerializer.Deserialize<ListaDeUsuario>(json);
            this.IdUsuarios = listaUsers.IdUsuarios;
        }
        /// <summary>
        /// Se crea el método Add para añadir un IdUsuario a la ListaDeUsuario
        /// ya existente. 
        /// Se pone en esta clase para cumplir el patrón Expert ya que es la que conoce
        /// los id de todos los usuarios.
        /// </summary>
        /// <param name="Id"></param>
        public void Add(int Id)
        {
            this.IdUsuarios.Add(Id);
        }
    }
    // Checkear si cuando se registran se agregan idSSS.
}