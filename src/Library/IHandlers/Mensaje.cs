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
        /// Initializes a new instance of the <see cref="Mensaje"/> class.
        /// El metodo permite crear un mensaje con una cierta Id y un cierto mensaje.
        /// </summary>
        /// <param name="id">Id del usuario que escribe el mensaje.</param>
        /// <param name="text">Lo que escribe el usuario.</param>
        public Mensaje(int id, string text)
        {
            this.Id = id;
            this.Text = text;
        }

        /// <summary>
        /// Gets or sets se guarda una Id en forma de un entero.
        /// </summary>
        /// <value>Guarda Id en un entero.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets string que guarda un mensaje en forma de texto.
        /// </summary>
        /// <value>Guarda mensaje en texto.</value>
        public string Text { get; set; }
    }
}