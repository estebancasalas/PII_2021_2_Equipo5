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
                VerificadorUsuario verificador = new VerificadorUsuario();
                if (!verificador.EstaRegistrado(mensaje.Id))
                {
                    mensaje.Text = Input.GetInput("Qué tipo de usuario desea crear? Ingrese /empresa o /emprendedor");
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