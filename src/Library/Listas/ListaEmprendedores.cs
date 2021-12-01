// -----------------------------------------------------------------------
// <copyright file="ListaEmprendedores.cs" company="Universidad Católica del Uruguay">
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
    /// Clase que modela un contenedor de los emprendedores registrados.
    /// Tiene la responsabilidad de conocer todos los emprendedores, buscar una emprendedor a partir de un Id retornando
    /// un objeto de tipo emprendedor.
    /// Depende de la Clase Emprendedor.
    /// Implementa IJsonConvertible para depender de una abstracción y no directamente de los metodos de Json.Serialization. (DIP).
    /// </summary>
    public class ListaEmprendedores : IJsonConvertible
    {
        /// <summary>
        /// Método que crea una instancia de esta clase y convierte su atributo Emprendedores en un string
        /// en formato json.
        /// </summary>
        /// <returns>String en formato json.</returns>
        public string ConvertToJson()
        {
            return JsonSerializer.Serialize(Singleton<List<Emprendedor>>.Instance);
        }

        /// <summary>
        /// Método que crea una instancia de esta clase y, a partir de un string en formato json, carga los Emprendedores al
        /// atributo Emprendedores del objeto.
        /// </summary>
        /// <param name="json">String en formato json.</param>
        public void LoadFromJson(string json)
        {
            List<Emprendedor> listaEmprs = new List<Emprendedor>();
            listaEmprs = JsonSerializer.Deserialize<List<Emprendedor>>(json);
            this.Emprendedores = listaEmprs;
        }

        /// <summary>
        /// Lista que contiene todos los emprendedores registrados.
        /// Utiliza el patrón de diseño Singleton para que el atributo sea único y global.
        /// No es readonly para facilitar el testing.
        /// </summary>
        /// <returns>Lista con los emprendedores registrados.</returns>
        [JsonInclude]
        public List<Emprendedor> Emprendedores = Singleton<List<Emprendedor>>.Instance;

        /// <summary>
        /// Se crea el método Add para añadir un Emprendedor a la ListaEmprendedores
        /// ya existente.
        /// Se pone en esta clase para cumplir el patrón Expert ya que es la que conoce
        /// a todos los Emprendedores.
        /// </summary>
        /// <param name="emprendedor">Emprendedor que se desea agregar a la lista.</param>
        public void Add(Emprendedor emprendedor)
        {
            if (!this.Emprendedores.Contains(emprendedor))
            {
                this.Emprendedores.Add(emprendedor);
            }
        }

        /// <summary>
        /// Método que sirve para buscar un emprendedor por su id. Se incluye en esta clase ya que es la
        /// que conoce la información de todos los emprendedores (patrón Expert).
        /// </summary>
        /// <param name="id">Id del emprendedor a buscar.</param>
        /// <returns>Devuelve el emprendedor correspondiente al id.</returns>

        public Emprendedor Buscar(long id)
        {
            return this.Emprendedores.Find(x => x.Id == id);
        }
    }
}