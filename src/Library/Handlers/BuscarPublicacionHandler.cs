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
        private string tipobusqueda;
        
        public List<Publicacion> result;

        private string busqueda;


        /// <summary>
        /// Método para buscar en la lista de publicaciones.
        /// </summary>
        /// <param name="mensaje">Mensaje recibido como parámetro. Contiene Id y el texto a evaluar.</param>
        public override string Handle(Mensaje mensaje)
        {
            ListaDeUsuario listaUsuario = new ListaDeUsuario();
            if (mensaje.Text.ToLower() == "/buscarpublicacion")
            {
                int indice = listaUsuario.Buscar(mensaje.Id);
                EstadoUsuario estado = listaUsuario.ListaUsuarios[indice].Estado;
                estado.Handler = this;
                switch (estado.Step)
                {
                    case 0:
                    Console.WriteLine("Que tipo de busqueda desea realizar? /categoria, /ciudad, /palabrasclave");
                    estado.Step++;
                    break;

                    case 1:
                    this.tipobusqueda = mensaje.Text;
                    Console.WriteLine("Que desea buscar?");
                    estado.Step++;
                    break;

                    case 2:
                    this.busqueda = mensaje.Text;
                    BuscarPublicacion buscarPublicacion = new BuscarPublicacion(this.tipobusqueda, this.busqueda);

                    // hacer metodo mostrar en pantalla y agregarlo aca.
                    estado = new EstadoUsuario();
                    break;
                }
            return this.TextResult.ToString();    
            }
            else
            {
                return this.GetNext().Handle(mensaje);
            }
        }
    }
}