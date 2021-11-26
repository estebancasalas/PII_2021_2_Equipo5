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
        /// Almacena la manera que el usuario desea buscar una publicación.
        /// </summary>
        private string tipobusqueda;

        /// <summary>
        /// Lo que desea buscar.
        /// </summary>
        private string busqueda;

        /// <summary>
        /// Método para buscar en la lista de publicaciones.
        /// </summary>
        /// <param name="mensaje">Mensaje recibido como parámetro. Contiene Id y el texto a evaluar.</param>
        
        public List<Publicacion> resultadoBusqueda = new List<Publicacion>();
        public override string Handle(Mensaje mensaje)
        {
            ListaDeUsuario listaUsuario = new ListaDeUsuario();
            int indice = listaUsuario.Buscar(mensaje.Id);
            EstadoUsuario estado = listaUsuario.ListaUsuarios[indice].Estado;
            if (mensaje.Text.ToLower() == "/buscarpublicacion" || estado.Handler == "/buscarpublicacion")
            {
                estado.Handler = "/buscarpublicacion";
                switch (estado.Step)
                {
                    case 0:
                        this.TextResult = new StringBuilder();
                        this.TextResult.Append("¿De qué manera desea de buscar la publicación?\n Si desea buscar por categoria --> /categoria \n Si desea buscar por ciudad --> /ciudad \n Si desea buscar por palabras claves --> /palabrasclave");
                        estado.Step++;
                        break;

                    case 1:
                        this.TextResult = new StringBuilder();
                        this.tipobusqueda = mensaje.Text;
                        if (mensaje.Text.ToLower() == "/categoria")
                        {
                            this.TextResult.Append("Ingrese la categoria:\n     Químicos, Plásticos, Celulósicos, Eléctricos, Textiles");
                        }
                        else if (mensaje.Text.ToLower() == "/ciudad")
                        {
                            this.TextResult.Append("Ingrese la ciudad");
                        }
                        else if (mensaje.Text.ToLower() == "/palabrasclave")
                        {
                            this.TextResult.Append("Ingrese palabras clave");
                        }
                        else
                        {
                            this.TextResult.Append("Usted ingreso una opción invalida. Intente nuevamente.");
                        }

                        estado.Step++;
                        break;

                    case 2:
                        this.TextResult = new StringBuilder();
                        this.busqueda = mensaje.Text;
                        BuscarPublicacion buscarPublicacion = new BuscarPublicacion(this.tipobusqueda, this.busqueda);
                        resultadoBusqueda = buscarPublicacion.EjecutarComando();
                        this.TextResult.Append("¿Desea realizar una compra?\n 1-Si \n 2-No");

                        // hacer metodo mostrar en pantalla y agregarlo aca.
                        estado = new EstadoUsuario();
                        break;

                    case 3:
                        this.TextResult = new StringBuilder();
                        if (mensaje.Text.ToLower() == "1")
                        {
                            this.TextResult.Append("Ingrese el numero de la publicación que desea comprar.");
                            estado.Step++;
                        }

                        else if (mensaje.Text.ToLower() == "2")
                        {
                            estado.Step = 0;
                        }

                        else
                        {
                            this.TextResult.Append("Usted ingreso una opción invalida. Intente nuevamente.");
                        }

                        break;

                    case 4:
                        this.TextResult = new StringBuilder();
                        int indicePublicacion = Int32.Parse(mensaje.Text);
                        Publicacion publicacion = resultadoBusqueda[indicePublicacion];
                        // ComprarHandler compra = new ComprarHandler(); Cambiar ComprarHandler.

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