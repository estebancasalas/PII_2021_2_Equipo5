// -----------------------------------------------------------------------
// <copyright file="BuscarPublicacionHandler.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

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
        public List<Publicacion> Result;

        /// <summary>
        /// Método para buscar en la lista de publicaciones.
        /// </summary>
        /// <param name="mensaje">Mensaje recibido como parámetro. Contiene Id y el texto a evaluar.</param>
        public override void Handle(Mensaje mensaje)
        {
            if (mensaje.Text.ToLower() == "/buscarpublicacion")
            {

                string tipobusqueda = this.Input.GetInput("Que tipo de busqueda desea realizar? /categoria, /ciudad, /palabrasclave");
                string busqueda = this.Input.GetInput("Que desea buscar?");
                BuscarPublicacion buscador = new BuscarPublicacion(tipobusqueda, busqueda);
                this.Result = buscador.EjecutarComando();

            }

            this.GetNext().Handle(mensaje);
        }
    }
}