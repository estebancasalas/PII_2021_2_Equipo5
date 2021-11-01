using System;
using System.Text;

namespace Library
{
    public class CrearUsuarioHandler : AbstarctHandler
    {
        public override void Handle (Mensaje mensaje)
        {
            
            
            if (mensaje.Text == "/CrearUsuario")
            {
                Output.PrintLine("Qué tipo de usuario desea crear? Una empresa o un emprendedor?");
                if (mensaje.Text == "empresa")
                {
                    //this.Next.Handle(Empresa);
                }
                if (mensaje.Text == "emprendedor")
                {
                    // ...
                }
            }
            else
            {
                this.Next.Handle(mensaje);
            }
        }
    }
}