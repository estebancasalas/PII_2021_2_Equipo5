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
        
        /// <summary>
        /// Atributo que guarda lo que desea buscar el usuario. Público para los tests.
        /// </summary>
        public string busqueda;

        /// <summary>
        /// Atributo que guarda la cantidad que desea buscar el usuario. Público para los tests.
        /// </summary>
        public float cantidad;

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
            int indice = listaUsuario.Buscar(mensaje.Id);
            EstadoUsuario estado = listaUsuario.ListaUsuarios[indice].Estado;
            if (mensaje.Text.ToLower() == "/buscarpublicacion" || estado.Handler == "/buscarpublicacion")
            {
                this.TextResult = new StringBuilder();
                estado.Handler = "/buscarpublicacion";
                switch (estado.Step)
                {
                    case 0:
                        this.TextResult.Append("¿De qué manera desea de buscar la publicación?\n Si desea buscar por categoría --> /categoria \n Si desea buscar por ciudad --> /ciudad \n Si desea buscar por palabras claves --> /palabrasclave");
                        estado.Step++;
                        break;

                    case 1:
                        List<string> lista = new List<string>() { "/categoria", "/ciudad", "/palabrasclave" };

                        if (!lista.Contains(mensaje.Text))
                        {
                            throw new OpcionInvalidaException("El tipo de búsqueda que ingresó no es válido, por favor intente nuevamente.");
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

                        estado.Step++;
                        break;

                    case 2:
                        if (this.tipoBusqueda == "/categoria" && !Material.PosiblesCategorias.Contains(mensaje.Text.ToLower()))
                        {
                            throw new OpcionInvalidaException("Lo siento, la categoría ingresada no es válida. Por favor vuelva a intentarlo.");
                        }

                        this.busqueda = mensaje.Text;
                        BuscarPublicacion buscarPublicacion = new BuscarPublicacion(this.tipoBusqueda, this.busqueda);
                        this.resultadoBusqueda = buscarPublicacion.EjecutarComando();
                        if (this.resultadoBusqueda.Count != 0)
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
                        if (mensaje.Text != "1" && mensaje.Text != "2")
                        {
                            throw new OpcionInvalidaException("Lo siento, la opción no es válida. Ingrese nuevamente.");
                        }

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

                        break;

                    case 4:
                        try
                        {
                            int indicePublicacion = Int32.Parse(mensaje.Text) - 1;
                            this.publicacionComprar = this.resultadoBusqueda[indicePublicacion];
                        }
                        catch (FormatException)
                        {
                            throw new FormatException("Lo siento, no entendí el mensaje. Por favor ingrese únicamente un número.");
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            throw new IndexOutOfRangeException("Usted no ingresó un número de publicación válido. Por favor, intente nuevamente.");
                        }

                        // En vez de la excepción anterior, se podría lanzar IndexOutOfRangeException en la línea siguiente y manejarla
                        // en la clase program, pero nos pareció que manejar nuestra excepción podría resultar más específico para este caso.
                        this.TextResult.Append("Ingrese la cantidad que desea compar\n(En la unidad especificada en la publicación.)");
                        estado.Step++;
                        break;

                    case 5:
                        try
                        {
                            this.cantidad = float.Parse(mensaje.Text);
                        }
                        catch
                        {
                            throw new FormatException("Lo siento, no entendí el mensaje. Por favor ingrese únicamente numeros.");
                        }

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