using System;
using System.Text;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Este handler te dirrecciona a la clase BuscarPublicación, implemnta AbstractHandler 
    /// </summary>
    public class BuscarPublicacionHandler : AbstractHandler
    {
        public override void Handle(Mensaje mensaje)
        {
            base.Handle(mensaje);
            if (mensaje.Text == "/BuscarPublicación")
            {
                BuscarPublicacion buscador = new BuscarPublicacion ();
                List<Publicacion> result = buscador.EjecutarComando();

            }
            else
            {
                this.Next.Handle(mensaje);
            }

        }
    }
}