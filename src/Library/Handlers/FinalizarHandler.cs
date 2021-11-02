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
        /// Método
        /// </summary>
        /// <param name="mensaje"></param>
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