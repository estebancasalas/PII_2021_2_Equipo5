// <copyright file="BuscarPublicacionTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
using System.Collections.Generic;
using Library;
using NUnit.Framework;
using Ucu.Poo.Locations.Client;

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
        Mensaje mensaje = new Mensaje(1234, string.Empty);
        EstadoUsuario estado = new EstadoUsuario();
        BuscarPublicacionHandler handler = new BuscarPublicacionHandler();
        IHandler nullHandler = new NullHandler();

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

            Empresa empresa1 = new Empresa("Empresa1", "UbicacionEmpresa1", "maderero", "123");
            Empresa empresa2 = new Empresa("Empresa2", "UbicacionEmpresa2", "plastico", "1232");
            Empresa empresa3 = new Empresa("Empresa3", "UbicacionEmpresa3", "electrica", "1233");

            this.a = new Publicacion("1", madera, "madera", "todos los dias", alfa, empresa1);
            this.b = new Publicacion("2", dos, "plastico", "todos los dias", beta, empresa2);
            this.c = new Publicacion("3", tres, "electrico", "todos los dias", gamma, empresa3);

            Usuario user = new Usuario(1234, estado);
            ListaDeUsuario lista = new ListaDeUsuario();
            lista.Add(user); 

            handler.SetNext(nullHandler); 
            handler.resultadoBusqueda.Add(this.a);
            handler.resultadoBusqueda.Add(this.b);
            handler.resultadoBusqueda.Add(this.c);
        }
        /// <summary>
        /// Prueba el primer paso
        /// </summary>
        [Test]
        public void Case0Test()
        {
            estado.Step = 0;
            mensaje.Id = 1234;
            mensaje.Text = "/buscarpublicacion";
            handler.Handle(mensaje);
            string expected = "¿De qué manera desea de buscar la publicación?\n Si desea buscar por categoría --> /categoria \n Si desea buscar por ciudad --> /ciudad \n Si desea buscar por palabras claves --> /palabrasclave";
            Assert.AreEqual(expected, handler.TextResult.ToString());
            Assert.AreEqual(estado.Step, 1); 
        }
        /// <summary>
        /// Prueba el segundo paso del handler, el caso en que el usuario desee buscar por categoría.
        /// </summary>
        [Test]
        public void Case1CategoriaTest()
        {
            estado.Step = 1;
            estado.Handler = "/buscarpublicacion";
            mensaje.Id = 1234;
            mensaje.Text = "/categoria";
            handler.Handle(mensaje);
            string expected = "Ingrese la categoría:\n     /Químicos, /Plásticos, /Celulósicos, /Eléctricos, /Textiles";
            Assert.AreEqual(expected, handler.TextResult.ToString());
            Assert.AreEqual(estado.Step, 2); 
        }
        /// <summary>
        /// Prueba el segundo paso del handler, el caso en que el usuario desee buscar por ciudad.
        /// </summary>
        [Test]
        public void Case1CiudadTest()
        {
            estado.Step = 1;
            estado.Handler = "/buscarpublicacion";
            mensaje.Id = 1234;
            mensaje.Text = "/ciudad";
            handler.Handle(mensaje);
            string expected = "Ingrese la ciudad";
            Assert.AreEqual(expected, handler.TextResult.ToString());
            Assert.AreEqual(estado.Step, 2); 
        }
        /// <summary>
        /// Prueba el segundo paso del handler, el caso en que el usuario desee buscar por palabras clave.
        /// </summary>
        [Test]
        public void Case1PalabrasClaveTest()
        {
            estado.Step = 1;
            estado.Handler = "/buscarpublicacion";
            mensaje.Id = 1234;
            mensaje.Text = "/palabrasclave";
            handler.Handle(mensaje);
            string expected = "Ingrese palabras clave";
            Assert.AreEqual(expected, handler.TextResult.ToString());
            Assert.AreEqual(estado.Step, 2); 
        }
        /// <summary>
        /// Prueba el segundo paso del handler, el caso en que el usuario envíe un mensaje vacío.
        /// </summary>
        [Test]
        public void Case1VacioTest()
        {
            estado.Step = 1;
            estado.Handler = "/buscarpublicacion";
            mensaje.Id = 1234;
            mensaje.Text = "";
            handler.Handle(mensaje);
            string expected = "La opción que ingresó no es válida, por favor vuelva a intentarlo.";
            Assert.AreEqual(expected, handler.TextResult.ToString());
            Assert.AreEqual(estado.Step, 2); 
        }
        /// <summary>
        /// Prueba el tercer paso del handler.
        /// </summary>
        [Test]
        public void Case2Test()
        {
            estado.Step = 2;
            estado.Handler = "/buscarpublicacion";
            mensaje.Id = 1234;
            mensaje.Text = "/Químicos";
            handler.TipoBusqueda = "/categoria";
            handler.Handle(mensaje);
            string expected = "¿Desea realizar una compra?\n 1-Si \n 2-No";
            Assert.AreEqual(expected, handler.TextResult.ToString());
            Assert.AreEqual(estado.Step, 3); 
        }
        /// <summary>
        /// Prueba el cuarto paso del handler, el caso en que el usuario no desee realizar una compra.
        /// </summary>
        [Test]
        public void Case3ComprarTest()
        {
            estado.Step = 3;
            estado.Handler = "/buscarpublicacion";
            mensaje.Id = 1234;
            mensaje.Text = "1";
            handler.Handle(mensaje);
            string expected = "Ingrese el número de la publicación que desea comprar.";
            Assert.AreEqual(expected, handler.TextResult.ToString());
            Assert.AreEqual(estado.Step, 4); 
        }
        /// <summary>
        /// Prueba el cuarto paso del handler, el caso en que el usuario desee realizar una compra.
        /// </summary>
        [Test]
        public void Case3NoComprarTest()
        {
            estado.Step = 3;
            estado.Handler = "/buscarpublicacion";
            mensaje.Id = 1234;
            mensaje.Text = "2";
            handler.Handle(mensaje);
            string expected = "Gracias por buscar en nuestro bot. Si desea realizar otra busqueda vuelva a escribir /buscarpublicacion.";
            Assert.AreEqual(expected, handler.TextResult.ToString());
            Assert.AreEqual(estado.Step, 0);
        }
        /// <summary>
        /// Prueba el cuarto paso del handler, el caso en que el mensaje no sea válido.
        /// </summary>
        [Test]
        public void Case3NoValidoTest()
        {
            estado.Step = 3;
            estado.Handler = "/buscarpublicacion";
            mensaje.Id = 1234;
            mensaje.Text = "";
            handler.Handle(mensaje);
            string expected = "Usted ingresó una opción no válida. Intente nuevamente.";
            Assert.AreEqual(expected, handler.TextResult.ToString());
            Assert.AreEqual(estado.Step, 3); 
        }
        /// <summary>
        /// Prueba el quinto paso del handler.
        /// </summary>
        [Test]
        public void Case4Test()
        {
            estado.Step = 4;
            estado.Handler = "/buscarpublicacion";
            mensaje.Id = 1234;
            mensaje.Text = "0";
            handler.Handle(mensaje);
            string expected = "Ingrese la cantidad que desea compar\n(En la unidad especificada en la publicación.)";
            Assert.AreEqual(expected, handler.TextResult.ToString());
            Assert.AreEqual(estado.Step, 5);
        }
        /// <summary>
        /// Prueba el sexto paso del handler.
        /// </summary>
        [Test]
        public void Case5Test()
        {
            estado.Step = 5;
            estado.Handler = "/buscarpublicacion";
            mensaje.Id = 1234;
            mensaje.Text = "0";
            handler.publicacionComprar = handler.resultadoBusqueda[0];
            handler.Handle(mensaje);
            string expected = "La compra ha sido registrada con éxito, por favor proceda a comunicarse con la empresa para finalizar la compra.\nContacto: {empresa.telefono}";
            Assert.AreEqual(expected, handler.TextResult.ToString());
            Assert.AreEqual(estado.Step, 5);
        }
    }
}