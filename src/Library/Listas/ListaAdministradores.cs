// -----------------------------------------------------------------------
// <copyright file="ListaAdministradores.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Library
{
    /// <summary>
    /// ListaAdministradores es quien se encarga de tener la lista con todos los
    /// Administradores registrados.
    /// Se cumple principio SRP ya que libra al administrador de tener que crearse a él mismo
    /// y al mismo tiempo conocer todos los Administradores registrados.
    /// </summary>
    public class ListaAdministradores : IJsonConvertible
    {
        /// <summary>
        /// El CovertToJson es el método por el cual se guardan los datos dentro de un archivo
        /// json.
        /// </summary>
        /// <returns></returns>
        public string ConvertToJson()
        {
            return JsonSerializer.Serialize(Singleton<List<Administrador>>.Instance);
        }

        /// <summary>
        /// LoadFromJson se encarga de cargar los datos guardados creando los objetos
        /// a partir de el archivo json.
        /// </summary>
        /// <param name="json"></param>
        public void LoadFromJson(string json)
        {
            List<Administrador> listaAdms = new List<Administrador>();
            listaAdms = JsonSerializer.Deserialize<List<Administrador>>(json);
            this.Administradores = listaAdms;
        }

        /// <summary>
        /// Lista que contiene todos los administradores registrados.
        /// Utiliza el patrón de diseño Singleton para que el atributo sea único y global.
        /// </summary>
        /// <returns></returns>
        public List<Administrador> Administradores = Singleton<List<Administrador>>.Instance;

        /// <summary>
        /// Se crea el método Add para añadir un Administrador a la ListaAdministradores
        /// ya existente.
        /// Se pone en esta clase para cumplir el patrón Expert ya que es la que conoce
        /// a todos los Administradores.
        /// </summary>
        /// <param name="administrador"></param>
        public void Add(Administrador administrador)
        {
            this.Administradores.Add(administrador);
        }

        public bool Verificar(long id)
        {
            
            Administrador administrador = null; 
            
            administrador = this.Administradores.Find(x=> x.Id == id);

            return administrador != null;
        }
    }
}