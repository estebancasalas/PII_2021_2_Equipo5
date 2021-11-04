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
        /// Atributo donde se guarda el resultado.
        /// </summary>
        public List<Publicacion> result;
        /// <summary>
        /// Método para buscar en la lista de publicaciones.
        /// </summary>
        /// <param name="mensaje">Mensaje recibido como parámetro. Contiene Id y el texto a evaluar.</param>
        public override void Handle(Mensaje mensaje)
        {
            if (mensaje.Text.ToLower() == "/buscarpublicacion")
            {
                string tipobusqueda = Input.GetInput("Que tipo de busqueda desea realizar? /categoria, /ciudad, /departamento, /palabrasclave");
                string busqueda = Input.GetInput("Que desea buscar?");
                BuscarPublicacion buscador = new BuscarPublicacion (tipobusqueda, busqueda);
                List<Publicacion> result = buscador.EjecutarComando();

            }
            else
            {
                this.Next.Handle(mensaje);
            }

        }
    }
}