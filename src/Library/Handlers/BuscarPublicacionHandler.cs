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
<<<<<<< HEAD
        public List<Publicacion> Result;
=======

        /// <summary>
        /// Lo que desea buscar.
        /// </summary>
>>>>>>> c0a91c3e23b0195b833453bf8bef99a55f9e7621
        private string busqueda;
        private string cantidadComprada;
        private Publicacion publicacion;

        /// <summary>
        /// Método para buscar en la lista de publicaciones.
        /// </summary>
        /// <param name="mensaje">Mensaje recibido como parámetro. Contiene Id y el texto a evaluar.</param>
        public override string Handle(Mensaje mensaje)
        {
            ListaDeUsuario listaUsuario = new ListaDeUsuario();
            int indice = listaUsuario.Buscar(id: mensaje.Id);
            EstadoUsuario estado = listaUsuario.ListaUsuarios[indice].Estado;

            if (mensaje.Text.ToLower() == "/buscarpublicacion" || estado.Handler == "/buscarpublicacion")
            {
                List<Publicacion> resultadoBusqueda = new List<Publicacion>();
                estado.Handler = "/buscarpublicacion";

                switch (estado.Step)
                {
                    case 0:
                        this.TextResult = new StringBuilder();
                        this.TextResult.Append("¿De que manera desea de buscar la publicación?\n Si desea buscar por categoria --> /categoria \n Si desea buscar por ciudad --> /ciudad \n Si desea buscar por palabras claves --> /palabrasclave");
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
                        this.publicacion = resultadoBusqueda[indicePublicacion];
                        // ComprarHandler compra = new ComprarHandler(); Cambiar ComprarHandler.
                        Console.WriteLine("Ingrese la cantidad que desee comprar: ");
                        estado.Step++;
                        break;

                    case 5:
                        this.cantidadComprada = mensaje.Text;
                        double cantidad = Convert.ToDouble(mensaje.Text);
                        ListaEmprendedores listaEmprendedores = new ListaEmprendedores();
                        Emprendedor emprendedor = listaEmprendedores.Buscar(mensaje.Id);
                        Transaccion transaccion = new Transaccion(this.publicacion.Vendedor, emprendedor, this.publicacion.Titulo, cantidad);
                        List<Transaccion> lista = Singleton<ListaTransacciones>.Instance.Transacciones;
                        lista.Add(transaccion);
                        break;
                }
<<<<<<< HEAD

=======
>>>>>>> c0a91c3e23b0195b833453bf8bef99a55f9e7621
                return this.TextResult.ToString();
            }
            else
            {
                return this.GetNext().Handle(mensaje);
            }
        }
    }
}