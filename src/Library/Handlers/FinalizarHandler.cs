// -----------------------------------------------------------------------
// <copyright file="FinalizarHandler.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Text;

namespace Library
{
    /// <summary>
    /// Handler final, para salir de la ejecución del bot. Implementa AbstractHandler porque
    /// interactúa con el usuario.
    /// </summary>
    public class FinalizarHandler : AbstractHandler
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="FinalizarHandler"/> class.
        /// Constructor de la clase.
        /// </summary>
        /// <param name="handler">Dado que tiene dos handlers siguientes, uno de ellos se pasa como parámetro.</param>


        /// <summary>
        /// Método que muestra en pantalla un mensaje, último Handler de la cadena principal.
        /// </summary>
        /// <param name="mensaje">El mensaje contiene el comando para finaliar.</param>
        /// <returns>Retorna la respuesta a la petición del usuario.</returns>
        public override string Handle(Mensaje mensaje)
        {
            if (mensaje.Text.ToLower() == "/finalizar")
            {
                this.TextResult = new StringBuilder();
                this.TextResult.Append("Gracias por usar nuestro bot, esperamos que te haya ayudado.");
                return this.TextResult.ToString();
            }
            else
            {
                return this.GetNext().Handle(mensaje);
            }
        }

    }
}