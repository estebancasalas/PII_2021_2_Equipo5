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
        /// Método que muestra en pantalla un mensaje, último Handler de la cadena principal.
        /// </summary>
        /// <param name="mensaje">El mensaje contiene el comando para finaliar.</param>
        public override void Handle (Mensaje mensaje)
        {
                   
            if (mensaje.Text == "/Finalizar")
            {
                Output.PrintLine("Gracias por usar nuestro bot, esperamos que te haya ayudado.");
            }
            else
            {
                this.Next.Handle(mensaje);
            }
        }
    }
}