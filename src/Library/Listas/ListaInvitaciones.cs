// -----------------------------------------------------------------------
// <copyright file="ListaInvitaciones.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Library
{
    /// <summary>
    /// ListaInvitaciones es quien se encarga de tener la lista con todas las
    /// invitaciones que fueron hechas.
    /// Se cumple principio SRP ya que libra al administrador de conocer todas las
    /// invitaciones.
    /// </summary>
    public class ListaInvitaciones : IJsonConvertible
    {
        /// <summary>
        /// Lista que contiene todas las invtiaciones.
        /// Utiliza el patrón de diseño Singleton para que el atributo sea único y global.
        /// </summary>
        /// <returns>Lista con todas las invitaciones.</returns>
        public List <string> Invitaciones = Singleton<List<string>>.Instance;

        /// <summary>
        /// Método que verifica si una invitación es válida. Se incluye en esta clase porque es la que
        /// conoce todas las invitaciones (patrón Expert).
        /// </summary>
        /// <param name="invitacion">Invitación a verificar.</param>
        /// <returns>Devuelve true si la invitación está registrada, false si no.</returns>
        public bool VerificarInvitacion(string invitacion)
        {
            return Invitaciones.Contains(invitacion);
        }

        /// <summary>
        /// El CovertToJson es el método por el cual se guardan los datos dentro de un archivo
        /// json.
        /// </summary>
        /// <returns>Guarda los datos en un archivo json.</returns>
        public string ConvertToJson()
        {
            return JsonSerializer.Serialize(Singleton<List<string>>.Instance);
        }

        /// <summary>
        /// LoadFromJson se encarga de cargar los datos guardados creando los objetos
        /// a partir de el archivo json.
        /// </summary>
        /// <param name="json">Carga los datos de un archivo json.</param>
        public void LoadFromJson(string json)
        {
            List<string> listaInvs = new List<string>();
            listaInvs = JsonSerializer.Deserialize<List<string>>(json);
            this.Invitaciones = listaInvs;
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
            if (!this.Invitaciones.Contains(invitacion))
            {
                this.Invitaciones.Add(invitacion);
            }
        }
    }
}