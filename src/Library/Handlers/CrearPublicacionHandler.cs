using System;
using System.Text;
using System.Collections.Generic;

namespace Library
{
    public class CrearPublicacionHandler : AbstarctHandler
    {
        public override void Handle(Mensaje mensaje)
        {
            base.Handle(mensaje);
            if (mensaje.Text == "/CrearPublicación")
            {
                CrearPublicacion publicacioncreada = new CrearPublicacion ();
            }
            else
            {
                this.Next.Handle(mensaje);
            }

        }
    }
}