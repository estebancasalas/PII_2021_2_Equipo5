using System;
using System.Text;

namespace Library
{
/// <summary>
/// Handler para invitar usuarios.
/// </summary>
    public class InvitarHandler :IHandler
    {
        public IHandler Next {get; set;}
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