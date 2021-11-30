// <copyright file="BuscarPublicacionTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Library;
using NUnit.Framework;
using Ucu.Poo.Locations.Client;

namespace LibraryTests
{
    /// <summary>
    /// Casos de prueba para buscar la publicacion.
    /// </summary>
    [TestFixture]
    public class BuscarPublicacionHandlerTest
    {
        private Publicacion a;
        private Publicacion b;
        private Publicacion c;
        private Mensaje mensaje = new Mensaje(1234, string.Empty);
        private EstadoUsuario estado = new EstadoUsuario();
        private BuscarPublicacionHandler handler = new BuscarPublicacionHandler();
        private IHandler nullHandler = new NullHandler();
        private Usuario user;

        /// <summary>
        /// Setup del test.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            Material madera = new Material("PMadera", 1, 2, "Cantidad", "Habilitación1", "/Quimicos");
            Material dos = new Material("Material2", 3, 4, "Cantidad", "Habilitación1", "/Plasticos");
            Material tres = new Material("Material3", 5, 6, "Cantidad", "Habilitación1", "/Electricos");

            IUbicacion alfa = new Ubicacion("Uruguay", "Montevideo", "8 de Octubre 1234", null, null, null);
            IUbicacion beta = new Ubicacion("Uruguay", "Salto", null, null, null, null);
            IUbicacion gamma = new Ubicacion("Uruguay", "Tacuarembo", null, null, null, null);

            Empresa empresa1 = new Empresa("Empresa1", "UbicacionEmpresa1", "maderero", "123", "091234567");
            Empresa empresa2 = new Empresa("Empresa2", "UbicacionEmpresa2", "plastico", "1232", "099557959");
            Empresa empresa3 = new Empresa("Empresa3", "UbicacionEmpresa3", "electrica", "1233", "098998895");

            this.a = new Publicacion("1", madera, "madera", "todos los dias", alfa, empresa1);
            this.b = new Publicacion("2", dos, "plastico", "todos los dias", beta, empresa2);
            this.c = new Publicacion("3", tres, "electrico", "todos los dias", gamma, empresa3);

            this.user = new Usuario(1234, this.estado);
            ListaDeUsuario lista = new ListaDeUsuario();
            lista.Add(this.user);

            this.handler.SetNext(this.nullHandler);
        }

        /// <summary>
        /// Prueba el primer paso.
        /// </summary>
        [Test]
        public void Case0Test()
        {
            this.user.Estado.Step = 0;
            this.mensaje.Id = 1234;
            this.mensaje.Text = "/buscarpublicacion";
            this.handler.Handle(this.mensaje);
            string expected = "¿De qué manera desea de buscar la publicación?\n Si desea buscar por categoría --> /categoria \n Si desea buscar por ciudad --> /ciudad \n Si desea buscar por palabras claves --> /palabrasclave";
            Assert.AreEqual(expected, this.handler.TextResult.ToString());
            Assert.AreEqual(this.user.Estado.Step, 1);
        }

        /// <summary>
        /// Prueba el segundo paso del handler, el caso en que el usuario desee buscar por categoría.
        /// </summary>
        [Test]
        public void Case1CategoriaTest()
        {
            this.user.Estado.Step = 1;
            this.user.Estado.Handler = "/buscarpublicacion";
            this.mensaje.Id = 1234;
            this.mensaje.Text = "/categoria";
            this.handler.Handle(this.mensaje);
            string expected = "Ingrese la categoría:\n  /quimicos, /plasticos, /celulosicos, /electricos, /textiles, /metalicos, /MetalicosFerrosos, /Solventes, /Vidrio, /ResiduosOrganicos, /Otros";
            Assert.AreEqual(expected, this.handler.TextResult.ToString());
            Assert.AreEqual(this.user.Estado.Step, 2);
            Assert.AreEqual(this.handler.TipoBusqueda, this.mensaje.Text);
        }

        /// <summary>
        /// Prueba el segundo paso del handler, el caso en que el usuario desee buscar por ciudad.
        /// </summary>
        [Test]
        public void Case1CiudadTest()
        {
            this.user.Estado.Step = 1;
            this.user.Estado.Handler = "/buscarpublicacion";
            this.mensaje.Id = 1234;
            this.mensaje.Text = "/ciudad";
            this.handler.Handle(this.mensaje);
            string expected = "Ingrese la ciudad";
            Assert.AreEqual(expected, this.handler.TextResult.ToString());
            Assert.AreEqual(this.user.Estado.Step, 2);
            Assert.AreEqual(this.handler.TipoBusqueda, this.mensaje.Text);
        }

        /// <summary>
        /// Prueba el segundo paso del handler, el caso en que el usuario desee buscar por palabras clave.
        /// </summary>
        [Test]
        public void Case1PalabrasClaveTest()
        {
            this.user.Estado.Step = 1;
            this.user.Estado.Handler = "/buscarpublicacion";
            this.mensaje.Id = 1234;
            this.mensaje.Text = "/palabrasclave";
            this.handler.Handle(this.mensaje);
            string expected = "Ingrese palabras clave";
            Assert.AreEqual(expected, this.handler.TextResult.ToString());
            Assert.AreEqual(this.user.Estado.Step, 2);
            Assert.AreEqual(this.handler.TipoBusqueda, this.mensaje.Text);
        }

        /// <summary>
        /// Prueba la excepción en en segundo paso del test.
        /// </summary>
        [Test]
        public void Case1VacioTest()
        {
            this.user.Estado.Step = 1;
            this.user.Estado.Handler = "/buscarpublicacion";
            this.mensaje.Id = 1234;
            this.mensaje.Text = string.Empty;
            string resultado = string.Empty;
            try
            {
                this.handler.Handle(this.mensaje);
            }
            catch (OpcionInvalidaException)
            {
                resultado = "El tipo de búsqueda que ingresó no es válido, por favor intente nuevamente.";
            }

            string expected = "El tipo de búsqueda que ingresó no es válido, por favor intente nuevamente.";
            Assert.AreEqual(expected, resultado);
        }

        /// <summary>
        /// Prueba la excepción en el tercer paso del Handler.
        /// </summary>
        [Test]
        public void Case2SinPublicacionTest()
        {
            this.handler.resultadoBusqueda.Clear();
            this.user.Estado.Step = 2;
            this.user.Estado.Handler = "/buscarpublicacion";
            this.mensaje.Id = 1234;
            this.mensaje.Text = "/otros";
            this.handler.TipoBusqueda = "/categoria";
            this.handler.Handle(this.mensaje);

            string expected = "No se encontraron publicaciones que coincidan con esos parámetros. Vuelva a escribir /buscarpublicacion para realizar otra búsqueda.";
            Assert.AreEqual(expected, this.handler.TextResult.ToString());
            Assert.AreEqual(this.user.Estado.Step, 0);
        }

        /// <summary>
        /// Test que prueba el tercer paso del handler cuando existen publicaciones.
        /// </summary>
        [Test]
        public void Case2ConPublicacionTest()
        {
            RegistroPublicaciones lista = new RegistroPublicaciones();
            lista.Activas.Clear();
            lista.Add(this.a);
            lista.Add(this.b);
            lista.Add(this.c);
            this.user.Estado.Step = 2;
            this.user.Estado.Handler = "/buscarpublicacion";
            this.mensaje.Id = 1234;
            this.mensaje.Text = "/Quimicos";
            this.handler.TipoBusqueda = "/categoria";
            this.handler.Handle(this.mensaje);
            string expected = "Publicación 1:\nTítulo: 1\nMaterial: Nombre: PMadera\nCosto: 1\nCantidad: 2\nUnidad: Cantidad\nHabilitaciones: Habilitación1\n\nPalabras clave: madera\nFrecuencia de disponibilidad: todos los dias\nUbicación: 8 de Octubre 1234, Montevideo, Uruguay\nVendedor: Empresa1\n\n\n¿Desea realizar una compra?\n 1-Si \n 2-No";
            Assert.AreEqual(expected, this.handler.TextResult.ToString());
            Assert.AreEqual(this.user.Estado.Step, 3);
            Assert.AreEqual(this.handler.busqueda, this.mensaje.Text);
        }

        /// <summary>
        /// Prueba el cuarto paso del handler, el caso en que el usuario no desee realizar una compra.
        /// </summary>
        [Test]
        public void Case3ComprarTest()
        {
            this.user.Estado.Step = 3;
            this.user.Estado.Handler = "/buscarpublicacion";
            this.mensaje.Id = 1234;
            this.mensaje.Text = "1";
            this.handler.Handle(this.mensaje);
            string expected = "Ingrese el número de la publicación que desea comprar.";
            Assert.AreEqual(expected, this.handler.TextResult.ToString());
            Assert.AreEqual(this.user.Estado.Step, 4);
        }

        /// <summary>
        /// Prueba el cuarto paso del handler, el caso en que el usuario desee realizar una compra.
        /// </summary>
        [Test]
        public void Case3NoComprarTest()
        {
            this.user.Estado.Step = 3;
            this.user.Estado.Handler = "/buscarpublicacion";
            this.mensaje.Id = 1234;
            this.mensaje.Text = "2";
            this.handler.Handle(this.mensaje);
            string expected = "Gracias por buscar en nuestro bot. Si desea realizar otra busqueda vuelva a escribir /buscarpublicacion.";
            Assert.AreEqual(expected, this.handler.TextResult.ToString());
            Assert.AreEqual(this.user.Estado.Step, 0);
        }

        /// <summary>
        /// Prueba el cuarto paso del handler, el caso en que el mensaje no sea válido.
        /// </summary>
        [Test]
        public void Case3NoValidoTest()
        {
            this.user.Estado.Step = 3;
            this.user.Estado.Handler = "/buscarpublicacion";
            this.mensaje.Id = 1234;
            this.mensaje.Text = string.Empty;
            string resultado = string.Empty;
            try
            {
                this.handler.Handle(this.mensaje);
            }
            catch (OpcionInvalidaException)
            {
                resultado = "Lo siento, la opción no es válida. Ingrese nuevamente.";
            }

            string expected = "Lo siento, la opción no es válida. Ingrese nuevamente.";
            Assert.AreEqual(expected, resultado);
        }

        /// <summary>
        /// Prueba el quinto paso del handler.
        /// </summary>
        [Test]
        public void Case4ValidoTest()
        {
            this.handler.resultadoBusqueda.Add(a);
            this.user.Estado.Step = 4;
            this.user.Estado.Handler = "/buscarpublicacion";
            this.mensaje.Id = 1234;
            this.mensaje.Text = "1";
            this.handler.Handle(this.mensaje);
            string expected = "Ingrese la cantidad que desea compar\n(En la unidad especificada en la publicación.)";
            Assert.AreEqual(expected, this.handler.TextResult.ToString());
            Assert.AreEqual(this.user.Estado.Step, 5);
        }

        /// <summary>
        /// Prueba el quinto paso, cuando hay una excepción por los datos ingresados.
        /// </summary>
        [Test]
        public void Case4OutOfRangeTest()
        {
            this.user.Estado.Step = 4;
            this.user.Estado.Handler = "/buscarpublicacion";
            this.mensaje.Id = 1234;
            this.mensaje.Text = "0";
            string resultado = string.Empty;
            try
            {
                this.handler.Handle(this.mensaje);
            }
            catch (IndexOutOfRangeException)
            {
                resultado = "Usted no ingresó un número de publicación válido. Por favor, intente nuevamente.";
            }

            string expected = "Usted no ingresó un número de publicación válido. Por favor, intente nuevamente.";
            Assert.AreEqual(expected, resultado);
        }

        /// <summary>
        /// Prueba el quinto paso, cuando hay una excepción de formato.
        /// </summary>
        [Test]
        public void Case4FormatExceptionTest()
        {
            this.user.Estado.Step = 4;
            this.user.Estado.Handler = "/buscarpublicacion";
            this.mensaje.Id = 1234;
            this.mensaje.Text = "1a";
            string resultado = string.Empty;
            try
            {
                this.handler.Handle(this.mensaje);
            }
            catch (FormatException)
            {
                resultado = "Lo siento, no entendí el mensaje. Por favor ingrese únicamente un número.";
            }

            string expected = "Lo siento, no entendí el mensaje. Por favor ingrese únicamente un número.";
            Assert.AreEqual(expected, resultado);
        }

        /// <summary>
        /// Prueba el sexto paso del handler.
        /// </summary>
        [Test]
        public void Case5Test()
        {
            this.user.Estado.Step = 5;
            this.user.Estado.Handler = "/buscarpublicacion";
            this.mensaje.Id = 1234;
            this.mensaje.Text = "0";
            this.handler.publicacionComprar = this.handler.resultadoBusqueda[0];
            this.handler.Handle(this.mensaje);
            string expected = $"La compra ha sido registrada con éxito, por favor proceda a comunicarse con la empresa para finalizar la compra.\nContacto: 091234567";
            Assert.AreEqual(expected, this.handler.TextResult.ToString());
            Assert.AreEqual(this.user.Estado.Step, 0);
        }

        /// <summary>
        /// Prueba el sexto paso, cuando hay una excepción.
        /// </summary>
        [Test]
        public void Case5FormatExceptionTest()
        {
            this.user.Estado.Step = 4;
            this.user.Estado.Handler = "/buscarpublicacion";
            this.mensaje.Id = 1234;
            this.mensaje.Text = "1a";
            string resultado = string.Empty;
            try
            {
                this.handler.Handle(this.mensaje);
            }
            catch (FormatException)
            {
                resultado = "Lo siento, no entendí el mensaje. Por favor ingrese únicamente un número.";
            }

            string expected = "Lo siento, no entendí el mensaje. Por favor ingrese únicamente un número.";
            Assert.AreEqual(expected, resultado);
        }
    }
}
