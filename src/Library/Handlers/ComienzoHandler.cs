using System;
using System.Text;

namespace Library
{
    /// <summary>
    /// Primer Handler de la Chain of Responsibility. Implementa AbstractHandler porque interactúa
    /// con el usuario.
    /// </summary>
    public class ComienzoHandler : AbstractHandler
    {
        /// <summary>
        /// Método que verifica el mensaje. Actúa si el mensaje es "/start" y sino lo envía
        /// al siguiente Handler.
        /// </summary>
        /// <param name="mensaje">Mensaje recibido como parámetro. Contiene Id y el texto a evaluar.</param>
        public override void Handle (Mensaje mensaje)
        {
            //En vez de start, que se fije si no tiene / y si es la primera vez que escribe el usuario
            
            if (mensaje.Text == "/start")
            {
                Input.GetInput("Bienvenido al Bot de materiales reciclables, te ayudaré a encontrar el material que quieras para tu emprendimiento, para eso escribe /comandos y veras todas tus opciones");
            }
            else
            {
                this.Next.Handle(mensaje);
            }
        }
    }
}