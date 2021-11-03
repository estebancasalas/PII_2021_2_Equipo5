using System;
using System.Text;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Este handler te dirrecciona a la clase BuscarPublicación, implementa AbstractHandler porque 
    /// interactúa con el usuario.
    /// </summary>
    public class BuscarPublicacionHandler : AbstractHandler
    {
        /// <summary>
        /// Método para buscar en la lista de publicaciones.
        /// </summary>
        /// <param name="mensaje">Mensaje recibido como parámetro. Contiene Id y el texto a evaluar.</param>
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