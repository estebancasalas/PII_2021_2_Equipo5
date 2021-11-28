// <copyright file="BuscarPublicacionTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
using System.Collections.Generic;
using Library;
using NUnit.Framework;
using Ucu.Poo.Locations.Client;
using System.Text;

namespace LibraryTests
{
    /// <summary>
    /// Casos de prueba para buscar la publicacion.
    /// </summary>
    [TestFixture]
    public class BuscarPublicacionTest
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
            Material madera = new Material("PMadera", 1, 2, "Cantidad", "Habilitación1", "/Químicos");
            Material dos = new Material("Material2", 3, 4, "Cantidad", "Habilitación1", "/Plásticos");
            Material tres = new Material("Material3", 5, 6, "Cantidad", "Habilitación1", "/Eléctricos");

            IUbicacion alfa = new Ubicacion("Uruguay", "Montevideo", null, null, null, null);
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
            this.handler.resultadoBusqueda.Add(this.a);
            this.handler.resultadoBusqueda.Add(this.b);
            this.handler.resultadoBusqueda.Add(this.c);
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
            string expected = "Ingrese la categoría:\n  /Químicos\n  /Plásticos\n  /Celulósicos\n  /Eléctricos\n  /Textiles";
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
        /// Prueba el segundo paso del handler, el caso en que el usuario envíe un mensaje vacío.
        /// </summary>
        [Test]
        public void Case1VacioTest()
        {
            this.user.Estado.Step = 1;
            this.user.Estado.Handler = "/buscarpublicacion";
            this.mensaje.Id = 1234;
            this.mensaje.Text = string.Empty;
            this.handler.Handle(this.mensaje);
            string expected = "La opción que ingresó no es válida, por favor vuelva a intentarlo.";
            Assert.AreEqual(expected, this.handler.TextResult.ToString());
            Assert.AreEqual(this.user.Estado.Step, 2);
        }

        /// <summary>
        /// Prueba el tercer paso del handler.
        /// </summary>
        [Test]
        public void Case2SinPublicacionTest()
        {
            this.handler.resultadoBusqueda.Clear();
            this.user.Estado.Step = 2;
            this.user.Estado.Handler = "/buscarpublicacion";
            this.mensaje.Id = 1234;
            this.mensaje.Text = "/Químicos";
            this.handler.TipoBusqueda = "/categoria";
            this.handler.Handle(this.mensaje);
            string expected = "No se encontraron publicaciones que coincidan con esos parámetros. Vuelva a escribir /buscarpublicacion para realizar otra búsqueda.";
            Assert.AreEqual(expected, this.handler.TextResult.ToString());
            Assert.AreEqual(this.user.Estado.Step, 0);
            Assert.AreEqual(this.handler.Busqueda, this.mensaje.Text);
        }
        /// <summary>
        /// Test que prueba el tercer paso del handler cuando existen publicaciones. 
        /// </summary>
        // [Test]
        // public void Case2ConPublicacionTest()
        // {
        //     this.handler.resultadoBusqueda.Add(this.a);
        //     this.user.Estado.Step = 2;
        //     this.user.Estado.Handler = "/buscarpublicacion";
        //     this.mensaje.Id = 1234;
        //     this.mensaje.Text = "/Químicos";
        //     this.handler.TipoBusqueda = "/categoria";
        //     this.handler.Handle(this.mensaje);
           
        //     string expected = "Título: ";
        //     Assert.AreEqual(expected, this.handler.TextResult.ToString());
        //     Assert.AreEqual(this.user.Estado.Step, 0);
        //     Assert.AreEqual(this.handler.Busqueda, this.mensaje.Text);
        // }

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
            this.handler.Handle(this.mensaje);
            string expected = "Usted ingresó una opción no válida. Intente nuevamente.";
            Assert.AreEqual(expected, this.handler.TextResult.ToString());
            Assert.AreEqual(this.user.Estado.Step, 3);
        }

        /// <summary>
        /// Prueba el quinto paso del handler.
        /// </summary>
        [Test]
        public void Case4Test()
        {
            this.user.Estado.Step = 4;
            this.user.Estado.Handler = "/buscarpublicacion";
            this.mensaje.Id = 1234;
            this.mensaje.Text = "0";
            this.handler.Handle(this.mensaje);
            string expected = "Ingrese la cantidad que desea compar\n(En la unidad especificada en la publicación.)";
            Assert.AreEqual(expected, this.handler.TextResult.ToString());
            Assert.AreEqual(this.user.Estado.Step, 5);
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
    }
}
