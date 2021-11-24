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
                List<Publicacion> resultadoBusqueda = new List<Publicacion>();
                int indice = listaUsuario.Buscar(mensaje.Id);
                EstadoUsuario estado = listaUsuario.ListaUsuarios[indice].Estado;
                estado.Handler = this;
                switch (estado.Step)
                {
                    case 0:
                        Console.WriteLine("¿De que manera desea de buscar la publicación?\n Si desea buscar por categoria --> /categoria \n Si desea buscar por ciudad --> /ciudad \n Si desea buscar por palabras claves --> /palabrasclave");
                        estado.Step++;
                        break;

                    case 1:
                        this.tipobusqueda = mensaje.Text;
                        if (mensaje.Text.ToLower() == "/categoria")
                        {
                            Console.WriteLine("Ingrese la categoria");
                        }
                        else if (mensaje.Text.ToLower() == "/ciudad")
                        {
                            Console.WriteLine("Ingrese la ciudad");
                        }
                        else if (mensaje.Text.ToLower() == "/palabrasclave")
                        {
                            Console.WriteLine("Ingrese palabras clave");
                        }
                        else
                        {
                            Console.WriteLine("Usted ingreso una opción invalida. Intente nuevamente.");
                        }

                        estado.Step++;
                        break;

                    case 2:
                        this.busqueda = mensaje.Text;
                        BuscarPublicacion buscarPublicacion = new BuscarPublicacion(this.tipobusqueda, this.busqueda);
                        resultadoBusqueda = buscarPublicacion.EjecutarComando();
                        Console.WriteLine("¿Desea realizar una compra?\n 1-Si \n 2-No");

                        // hacer metodo mostrar en pantalla y agregarlo aca.
                        estado = new EstadoUsuario();
                        break;

                    case 3:
                        if (mensaje.Text.ToLower() == "1")
                        {
                            Console.WriteLine("Ingrese el numero de la publicación que desea comprar.");
                            estado.Step++;
                        }
                        else if (mensaje.Text.ToLower() == "2")
                        {
                            estado.Step = 0;
                        }
                        else
                        {
                            Console.WriteLine("Usted ingreso una opción invalida. Intente nuevamente.");
                        }

                        break;

                    case 4:
                        int indicePublicacion = Int32.Parse(mensaje.Text);
                        Publicacion publicacion = resultadoBusqueda[indicePublicacion];
                        // ComprarHandler compra = new ComprarHandler(); Cambiar ComprarHandler.
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