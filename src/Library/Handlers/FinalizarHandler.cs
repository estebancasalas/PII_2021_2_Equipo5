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
        private NullHandler Next2;

        /// <summary>
        /// Método que muestra en pantalla un mensaje, último Handler de la cadena principal.
        /// </summary>
        /// <param name="mensaje">El mensaje contiene el comando para finaliar.</param>
        public override string Handle(Mensaje mensaje)
        {
            if (mensaje.Text.ToLower() == "/finalizar")
            {
                Output.PrintLine("Gracias por usar nuestro bot, esperamos que te haya ayudado.");
                this.Next2.Handle(mensaje); // Next2 = NullHandler
            }
            else
            {
                this.GetNext().Handle(mensaje);  // Que vuelva al primer handler
            }
            return this.TextResult.ToString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FinalizarHandler"/> class.
        /// Constructor de la clase.
        /// </summary>
        /// <param name="handler">Dado que tiene dos handlers siguientes, uno de ellos se pasa como parámetro.</param>
        public FinalizarHandler(IHandler handler)
        {
            this.SetNext(handler);
            this.Next2 = new NullHandler();
        }
    }
}