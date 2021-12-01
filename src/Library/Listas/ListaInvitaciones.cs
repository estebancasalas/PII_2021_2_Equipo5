// -----------------------------------------------------------------------
// <copyright file="ListaInvitaciones.cs" company="Universidad Católica del Uruguay">
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
    /// Clase que modela un contenedor de las Invitaciones Válidas.
    /// Tiene la responsabilidad de conocer todas las invitaciones, y verificar que un invitación dada es válida.
    /// Implementa IJsonConvertible para depender de una abstracción y no directamente de los metodos de Json.Serialization. (DIP).
    /// </summary>
    public class ListaInvitaciones : IJsonConvertible
    {
        /// <summary>
        /// Lista que contiene todas las invtiaciones.
        /// Utiliza el patrón de diseño Singleton para que el atributo sea único y global.
        /// </summary>
        /// <returns>Lista con todas las invitaciones.</returns>
        [JsonInclude]
        public List<string> invitaciones = Singleton<List<string>>.Instance;

        /// <summary>
        /// Método que verifica si una invitación es válida. Se incluye en esta clase porque es la que
        /// conoce todas las invitaciones (patrón Expert).
        /// </summary>
        /// <param name="invitacion">Invitación a verificar.</param>
        /// <returns>Devuelve true si la invitación está registrada, false si no.</returns>
        public bool VerificarInvitacion(string invitacion)
        {
            return this.invitaciones.Contains(invitacion);
        }

        /// <summary>
        /// Método que crea una instancia de esta clase y convierte su atributo invitaciones en un string
        /// en formato json.
        /// </summary>
        /// <returns>String en formato json.</returns>
        public string ConvertToJson()
        {
            return JsonSerializer.Serialize(Singleton<List<string>>.Instance);
        }

        /// <summary>
        /// Método que crea una instancia de esta clase y, a partir de un string en formato json, carga las invitaciones al
        /// atributo Invitaciones del objeto.
        /// </summary>
        /// <param name="json">String en formato json</param>
        public void LoadFromJson(string json)
        {
            List<string> listaInvs = new List<string>();
            listaInvs = JsonSerializer.Deserialize<List<string>>(json);
            this.invitaciones = listaInvs;
        }

        /// <summary>
        /// Se crea el método Add para añadir las Invitaciones a la ListaInvitaciones
        /// ya existente.
        /// Se pone en esta clase para cumplir el patrón Expert ya que es la que conoce
        /// todas las invitaciones que existen.
        /// </summary>
        /// <param name="invitacion">Invitación que se desea agregar a la lista.</param>
        public void Add(string invitacion)
        {
            if (!this.invitaciones.Contains(invitacion))
            {
                this.invitaciones.Add(invitacion);
            }
        }
    }
}