using System;
using System.Text;

namespace Library
{
    public class CrearUsuarioHandler : AbstractHandler
    {
        public IHandler Next2; //Esto agregue yo.

        public CrearUsuarioHandler(AbstractHandler next, IHandler next2) //Esto agregue yo
        {
            this.Next = next;
            this.Next2 = next2;
        }
        public override void Handle (Mensaje mensaje)
        {
            
            
            if (mensaje.Text == "/CrearUsuario")
            {
                //Crear clase que verifica si el usuario ya esta registrado
                Output.PrintLine("Qué tipo de usuario desea crear? Una empresa o un emprendedor?");
                mensaje.Text = GetInput; //Falta agregar esto
                if (nosestaregistrado)
                {
                    this.Next.Handle(mensaje); //Este deberia ser el handler de crear empresa o emprendedor
                }
            }
            else
            {
                Output.PrintLine("Usted ya esta registrado");
                this.Next2.Handle(mensaje);
            }
        }
    }
}