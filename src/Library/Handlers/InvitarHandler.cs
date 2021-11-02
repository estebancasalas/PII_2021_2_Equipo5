using System;
using System.Text;

namespace Library
{
    /// <summary>
    /// Handler para invitar a una empresa a registrarse. Implementa IHandler porque la interacción no es
    /// con el usuario, sino que es entre Handlers. (no debe implementar AbstractHandler?)
    /// </summary>

    public class InvitarHandler :IHandler
    {
        /// <summary>
        /// Contiene el siguiente Handler al cual le manda mensaje.
        /// </summary>
        /// <value></value>
        public IHandler Next {get; set;}
        /// <summary>
        /// Método para invitar a un usuario. Pide el nombre de un usuario y crea una invitación 
        /// para el mismo?
        /// </summary>
        /// <param name="mensaje"></param>
        public void Handle(Mensaje mensaje)
        {
            /*if (mensaje.Text.Contains("/"))
            {}
            else
            {4
                this.Next.Handle(mensaje);
            }*/

            Console.WriteLine("Invitar a: ");
            string invitado = Console.ReadLine();
        }
    }
}