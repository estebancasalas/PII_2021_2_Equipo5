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
        public override void Handle(Mensaje mensaje)
        {
            if (mensaje.Text.ToLower() == "/finalizar")
            {
                Output.PrintLine("Gracias por usar nuestro bot, esperamos que te haya ayudado.");
                this.Next2.Handle(mensaje); //Next2 = NullHandler
            }
            else
            {
                this.GetNext().Handle(mensaje);  //Que vuelva al primer handler
            }
        }
        /// <summary>
        /// Constructor de la clase. 
        /// </summary>
        /// <param name="handler">Dado que tiene dos handlers siguientes, uno de ellos se pasa como parámetro</param>
        public FinalizarHandler(IHandler handler)
        {
            this.SetNext(handler);
            this.Next2 = new NullHandler();
        }
    }
}