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
        private string tipoBusqueda;

        /// <summary>
        /// Lo que desea buscar.
        /// </summary>
        public string busqueda;

        /// <summary>
        /// Lista que contiene todas las publicaciones encontradas.
        /// </summary>

        public List<Publicacion> resultadoBusqueda = new List<Publicacion>();

        /// <summary>
        /// Atributo que se utiliza para mostrar las publicaciones encontradas al usuario.
        /// </summary>
        public Publicacion publicacionComprar;  //public para test

        /// <summary>
        /// Obtiene o establece, se define la property para los tests.
        /// </summary>
        /// <value>Lo que ingresa el usuario.</value>
        public string TipoBusqueda
        {
            get { return this.tipoBusqueda; }
            set { this.tipoBusqueda = value; }
        }

        /// <summary>
        /// Método Handle. Busca una publicación e interactúa con el usuario.
        /// </summary>
        /// <param name="mensaje">Mensaje que recibe del usuario.</param>
        /// <returns>Los mensajes que le envía al usuario por pantalla.</returns>
        public override string Handle(Mensaje mensaje)
        {
            ListaDeUsuario listaUsuario = new ListaDeUsuario();
            int indice = listaUsuario.Buscar(id: mensaje.Id);
            EstadoUsuario estado = listaUsuario.ListaUsuarios[indice].Estado;
            if (mensaje.Text.ToLower() == "/buscarpublicacion" || estado.Handler == "/buscarpublicacion")
            {
                estado.Handler = "/buscarpublicacion";
                switch (estado.Step)
                {
                    case 0:
                        this.TextResult = new StringBuilder();
                        this.TextResult.Append("¿De qué manera desea de buscar la publicación?\n Si desea buscar por categoría --> /categoria \n Si desea buscar por ciudad --> /ciudad \n Si desea buscar por palabras claves --> /palabrasclave");
                        estado.Step++;
                        break;

                    case 1:
                        this.TextResult = new StringBuilder();

                        try 
                        {
                            List<string> lista = new List<string>() {"/categoria", "/ciudad", "/palabrasclave"};
                            if (!lista.Contains(mensaje.Text))
                            {
                                throw 
                            }
                        }

                        this.tipoBusqueda = mensaje.Text;
                        if (mensaje.Text.ToLower() == "/categoria")
                        {
                            this.TextResult.Append("Ingrese la categoría:\n  /quimicos, /plasticos, /celulosicos, /electricos, /textiles, /metalicos, /MetalicosFerrosos, /Solventes, /Vidrio, /ResiduosOrganicos, /Otros");
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
                            this.TextResult.Append("La opción que ingresó no es válida, por favor vuelva a intentarlo.");
                        }

                        estado.Step++;
                        break;

                    case 2:
                        this.TextResult = new StringBuilder();
                        this.busqueda = mensaje.Text;
                        BuscarPublicacion buscarPublicacion = new BuscarPublicacion(this.tipoBusqueda, this.busqueda);
                        this.resultadoBusqueda = buscarPublicacion.EjecutarComando();
                        if (resultadoBusqueda.Count != 0)
                        {
                            IMostrar conversor = new RegistroPublicaciones();
                            List<IConversorTexto> listaTexto = new List<IConversorTexto>();
                            foreach (Publicacion publicacion in this.resultadoBusqueda)
                            {
                                listaTexto.Add(publicacion);
                            }
                            this.TextResult.Append($"{conversor.Mostrar(listaTexto)}\n");
                            this.TextResult.Append("¿Desea realizar una compra?\n 1-Si \n 2-No");
                            estado.Step++;
                        }
                        else
                        {
                            this.TextResult.Append("No se encontraron publicaciones que coincidan con esos parámetros. Vuelva a escribir /buscarpublicacion para realizar otra búsqueda.");
                            estado.Step = 0;
                            estado.Handler = String.Empty;
                        }


                        break;

                    case 3:
                        this.TextResult = new StringBuilder();
                        if (mensaje.Text.ToLower() == "1")
                        {
                            this.TextResult.Append("Ingrese el número de la publicación que desea comprar.");
                            estado.Step++;
                        }
                        else if (mensaje.Text.ToLower() == "2")
                        {
                            this.TextResult.Append("Gracias por buscar en nuestro bot. Si desea realizar otra busqueda vuelva a escribir /buscarpublicacion.");
                            estado.Step = 0;
                        }
                        else
                        {
                            this.TextResult.Append("Usted ingresó una opción no válida. Intente nuevamente.");
                        }

                        break;

                    case 4:
                        this.TextResult = new StringBuilder();
                        int indicePublicacion = Int32.Parse(mensaje.Text) - 1;
                        this.publicacionComprar = this.resultadoBusqueda[indicePublicacion];
                        this.TextResult.Append("Ingrese la cantidad que desea compar\n(En la unidad especificada en la publicación.)");
                        estado.Step++;
                        break;

                    case 5:
                        this.TextResult = new StringBuilder();
                        float cantidad = float.Parse(mensaje.Text);
                        ListaEmprendedores listaEmprendedores = Singleton<ListaEmprendedores>.Instance;
                        Emprendedor comprador = listaEmprendedores.Buscar(mensaje.Id);
                        Transaccion transaccion = new Transaccion(this.publicacionComprar.Vendedor, comprador, this.publicacionComprar.Material, cantidad);
                        ListaTransacciones listaTransacciones = Singleton<ListaTransacciones>.Instance;
                        listaTransacciones.Add(transaccion);

                        this.TextResult.Append($"La compra ha sido registrada con éxito, por favor proceda a comunicarse con la empresa para finalizar la compra.\nContacto: {publicacionComprar.Vendedor.Contacto}");
                        estado.Step = 0;
                        estado.Handler = string.Empty;
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