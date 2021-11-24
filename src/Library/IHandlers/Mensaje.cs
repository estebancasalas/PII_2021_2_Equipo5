// -----------------------------------------------------------------------
// <copyright file="Mensaje.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace Library
{
    /// <summary>
    /// Clase para usar en otras clases que requieran el envio y la recepción de mensajes.
    /// Es una clase con patron Mediator ya que los mensajes generados están restringidos a un formato especifico.
    /// </summary>
    public class Mensaje
    {
        /// <summary>
        /// Se guarda una Id en forma de un entero.
        /// </summary>
        /// <value></value>
        public long Id{ get; set; }
        /// <summary>
        /// String que guarda un mensaje en forma de texto.
        /// </summary>
        /// <value></value>
        public string Text { get; set; }
        /// <summary>
        /// El metodo permite crear un mensaje con una cierta Id y un cierto mensaje.
        /// </summary>
        /// <param name="id">Id del usuario que escribe el mensaje</param>
        /// <param name="text">Lo que escribe el usuario</param>
        public Mensaje(long id, string text)
        {
            this.Id = id;
            this.Text = text;
        }
    }
}