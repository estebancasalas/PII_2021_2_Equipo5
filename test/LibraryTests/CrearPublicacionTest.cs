
// <copyright file="CrearPublicacionTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections.Generic;
using Library;
using NUnit.Framework;


namespace LibraryTests
{
    /// <summary>
    /// Test del handler crear publicacion.
    /// </summary>
    [TestFixture]
    public class CrearPublicacionTest
    {
        CrearPublicacionHandler handler = new CrearPublicacionHandler();
        EstadoUsuario estado = new EstadoUsuario();
        EstadoUsuario estadoNE = new EstadoUsuario();
        RegistroPublicaciones publicacionesAct = new RegistroPublicaciones();
        Mensaje mensaje = new Mensaje(9999, "");

        /// <summary>
        /// Setup inicializa valores en común.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            ListaDeUsuario listaDeUsuario = new ListaDeUsuario();
            Usuario empresario = new Usuario(9999, estado);
            Usuario noempresario = new Usuario(8888,estadoNE);
            listaDeUsuario.Add(empresario);
            listaDeUsuario.Add(noempresario);
            Empresario user = new Empresario(9999, estado, "Pablo");
            ListaEmpresa listaEmpresa = new ListaEmpresa();
            Empresa empresa = new Empresa("Niike", "Montevieo", "Ropa", "1234567890", "098 673 111");
            empresa.listaEmpresarios.Add(user);
            listaEmpresa.Add(empresa);
        }

        /// <summary>
        /// Test que verifica que el bot le pide que ingrese el material.
        /// </summary>
        [Test]
        public void Case0Test()
        {
            Mensaje mensaje = new Mensaje(9999, "/crearpublicacion");
            estado.Step = 0;
            estado.Handler = "";
            handler.Handle(mensaje);
            string expected = "Ingrese el material:"; 
            Assert.AreEqual(expected, handler.TextResult.ToString());
        }

        /// <summary>
        /// Test que verifica que el bot le pide que ingrese la categoria del material.
        /// </summary>
        [Test]
        public void Case1Test()
        {
            mensaje.Text = "Agua oxigenada";
            estado.Step = 1;
            estado.Handler = "/crearpublicacion";
            handler.Handle(mensaje);
            string expected = "Ingrese la categoria:"; 
            Assert.AreEqual(expected, handler.TextResult.ToString());
        }

        /// <summary>
        /// Test que verifica que el bot le pide que la unidad que cuantifica el material.
        /// </summary>
        [Test]
        public void Case2Test()
        {
            mensaje.Text = "/químicos";
            estado.Step = 2;
            estado.Handler = "/crearpublicacion";
            handler.Handle(mensaje);
            string expected = "Ingrese la unidad con la que cuantifica el material:"; 
            Assert.AreEqual(expected, handler.TextResult.ToString());
        }

        /// <summary>
        /// Test que verifica que el bot le pide que ingrese precio por unidad.
        /// </summary>
        [Test]
        public void Case3Test()
        {
            mensaje.Text = "litros";
            estado.Step = 3;
            estado.Handler = "/crearpublicacion";
            handler.Handle(mensaje);
            string expected = "Ingrese el precio por unidad:"; 
            Assert.AreEqual(expected, handler.TextResult.ToString());
        }

        /// <summary>
        /// Test que verifica que el bot le pide que ingrese la cantidad que desea publicar del material.
        /// </summary>
        [Test]
        public void Case4Test()
        {
            mensaje.Text = "10";
            estado.Step = 4;
            estado.Handler = "/crearpublicacion";
            handler.Handle(mensaje);
            string expected = "Ingrese la cantidad:"; 
            Assert.AreEqual(expected, handler.TextResult.ToString());
        }

        /// <summary>
        /// Test que verifica que el bot le pide que si se necesita habilitaciones para manipular el material.
        /// </summary>
        [Test]
        public void Case5Test()
        {
            mensaje.Text = "40";
            estado.Step = 5;
            estado.Handler = "/crearpublicacion";
            handler.Handle(mensaje);
            string expected = "Ingrese habilitaciones necesarias para manipular el material:"; 
            Assert.AreEqual(expected, handler.TextResult.ToString());
        }

        /// <summary>
        /// Test que verifica que el bot le pide que ingrese el titulo de la publicación.
        /// </summary>
        [Test]
        public void Case6Test()
        {
            mensaje.Text = "Ninguna";
            estado.Step = 6;
            estado.Handler = "/crearpublicacion";
            handler.Handle(mensaje);
            string expected = "Ingrese el título:"; 
            Assert.AreEqual(expected, handler.TextResult.ToString());
        }

        /// <summary>
        /// Test que verifica que el bot le pide que ingrese las palabras claves de su publicación.
        /// </summary>
        [Test]
        public void Case7Test()
        {
            mensaje.Text = "Agua Oxígenada para todos";
            estado.Step = 7;
            estado.Handler = "/crearpublicacion";
            handler.Handle(mensaje);
            string expected = "Ingrese palabras claves separadas con ',' : "; 
            Assert.AreEqual(expected, handler.TextResult.ToString());
        }

        /// <summary>
        /// Test que verifica que el bot le pide que ingrese la frequencia del material.
        /// </summary>
        [Test]
        public void Case8Test()
        {
            mensaje.Text = "Agua Oxigenada, Agua";
            estado.Step = 8;
            estado.Handler = "/crearpublicacion";
            handler.Handle(mensaje);
            string expected = "Ingrese frequencia de disponibilidad: "; 
            Assert.AreEqual(expected, handler.TextResult.ToString());
        }

        /// <summary>
        /// Test que verifica que el bot le pide la ubicación donde se encuentra el material.
        /// </summary>
        [Test]
        public void Case9Test()
        {
            mensaje.Text = "1 vez por semana";
            estado.Step = 9;
            estado.Handler = "/crearpublicacion";
            handler.Handle(mensaje);
            string expected = "Ingrese dónde se encuentra: "; 
            Assert.AreEqual(expected, handler.TextResult.ToString());
        }
        
        /// <summary>
        /// Test que verifica si la publicación se creo correctamente.
        /// </summary>
/*        [Test]
        public void Case10Test_1()
        {
            mensaje.Text = "Montevideo";
            this.handler.localizacion = mensaje.Text;
            estado.Step = 10;
            estado.Handler = "/crearpublicacion";
            handler.Handle(mensaje);
            Assert.AreEqual(this.handler.localizacion, mensaje.Text);
        }

        /// <summary>
        /// Test que verifica si el bot responde correctamente.
        /// </summary>
        [Test]
        public void Case10Test_2()
        {
            mensaje.Text = "Montevideo";
            this.handler.localizacion = mensaje.Text;
            estado.Step = 10;
            estado.Handler = "/crearpublicacion";
            handler.Handle(mensaje);
            string expected = "Tú publicación ahora se encuentra activa."; 
            Assert.AreEqual(expected, handler.TextResult.ToString());
        }
*/
        /// <summary>
        /// Test que verifica que si la persona no es un empresario no pueda crear una publicación.  
        /// </summary>       
        [Test]
        public void ElseTest()
        {
            Mensaje mensaje = new Mensaje(8888, "/crearpublicacion");
            estado.Step = 0;
            estado.Handler = "/crearpublicacion";
            handler.Handle(mensaje);
            string expected = "Para crear publicaciones debe pertenecer a una empresa."; 
            Assert.AreEqual(expected, handler.TextResult.ToString());
        }
    }
}
