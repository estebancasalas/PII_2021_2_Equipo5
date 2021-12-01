// -----------------------------------------------------------------------
// <copyright file="ListaAdministradores.cs" company="Universidad Católica del Uruguay">
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
    /// Clase que modela un contenedor de los administrdores registradas.
    /// Tiene la responsabilidad de conocer todos los administradores, buscar un adminstrador a partir de su Id retornando
    /// un valor booleano que indica si lo encontró.
    /// Depende de la Clase Administrador.
    /// Implementa IJsonConvertible para depender de una abstracción y no directamente de los metodos Json.Serialization. (DIP).
    /// </summary>
    public class ListaAdministradores : IJsonConvertible
    {
        /// <summary>
        /// Método que crea una instancia de esta clase y convierte su atributo Administradores en un string
        /// en formato json.
        /// </summary>
        /// <returns>String en formato json.</returns>
        public string ConvertToJson()
        {
            return JsonSerializer.Serialize(Singleton<List<Administrador>>.Instance);
        }

        /// <summary>
        /// Método que crea una instancia de esta clase y, a partir de un string en formato json, carga los administrdores al
        /// atributo Administradores del objeto.
        /// </summary>
        /// <param name="json">String en formato json.</param>
        public void LoadFromJson(string json)
        {
            List<Administrador> listaAdms = new List<Administrador>();
            listaAdms = JsonSerializer.Deserialize<List<Administrador>>(json);
            this.Administradores = listaAdms;
        }

        /// <summary>
        /// Obtiene o establece los Administradores registrados en el bot.
        /// Utiliza el patrón de diseño Singleton para que el atributo sea único y global.
        /// No es readonly para facilitar el testing.
        /// </summary>
        /// <returns>Lista con los administradores.</returns>
        [JsonInclude]
        public List<Administrador> Administradores { get; set; } = Singleton<List<Administrador>>.Instance;

        /// <summary>
        /// Se crea el método Add para añadir un Administrador a la Lista evitando duplicados.
        /// Se pone en esta clase para cumplir el patrón Expert ya que es la que conoce todos los administradores.
        /// </summary>
        /// <param name="administrador">Administrador que se desea añadir.</param>
        public void Add(Administrador administrador)
        {
            if (!this.Administradores.Contains(administrador))
            {
                this.Administradores.Add(administrador);
            }
        }

        /// <summary>
        /// Método que verifica si el Id esta registrado como administrador.
        /// </summary>
        /// <param name="id">Id a verificar.</param>
        /// <returns>Devuelve true si el id está en la lista, false en otro caso.</returns>
        public bool Verificar(long id)
        {
            Administrador administrador = null;
            administrador = this.Administradores.Find(x => x.Id == id);

            return administrador != null;
        }
    }
}