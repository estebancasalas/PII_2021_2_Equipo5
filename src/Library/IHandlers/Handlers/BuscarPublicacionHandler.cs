using System;
using System.Text;
using System.Collections.Generic;

namespace Library
{
    public class BuscarPublicacionHandler : AbstarctHandler
    {
        public override void Handle(Mensaje mensaje)
        {
            base.Handle(mensaje);
            if (mensaje.Text == "/BuscarPublicación")
            {
                BuscarPublicacion buscador = new BuscarPublicacion ();
                List<Publicacion> result = buscador.EjecutarComando();
                //Test pull

            }
            else
            {
                this.Next.Handle(mensaje);
            }

        }
    }
}