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
        private CrearPublicacionHandler handler = new CrearPublicacionHandler();
        private EstadoUsuario estado = new EstadoUsuario();
        private EstadoUsuario estadoNE = new EstadoUsuario();
        private RegistroPublicaciones publicacionesAct = new RegistroPublicaciones();
        private Mensaje mensaje = new Mensaje(9999, string.Empty);

        /// <summary>
        /// Setup inicializa valores en común.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            ListaDeUsuario listaDeUsuario = new ListaDeUsuario();
            Usuario empresario = new Usuario(9999, this.estado);
            Usuario noempresario = new Usuario(8888, this.estadoNE);
            listaDeUsuario.Add(empresario);
            listaDeUsuario.Add(noempresario);
            Empresario user = new Empresario(9999, this.estado, "Pablo");
            ListaEmpresa listaEmpresa = new ListaEmpresa();
            Empresa empresa = new Empresa("Niike", "Montevieo", "Ropa", "1234567890", "098 673 111");
            empresa.ListaEmpresarios.Add(user);
            listaEmpresa.Add(empresa);
        }

        /// <summary>
        /// Test que verifica que el bot le pide que ingrese el material.
        /// </summary>
        [Test]
        public void Case0Test()
        {
            Mensaje mensaje = new Mensaje(9999, "/crearpublicacion");
            this.estado.Step = 0;
            this.estado.Handler = string.Empty;
            this.handler.Handle(mensaje);
            string expected = "Ingrese el material:";
            Assert.AreEqual(expected, this.handler.TextResult.ToString());
        }

        /// <summary>
        /// Test que verifica que el bot le pide que ingrese la categoria del material.
        /// </summary>
        [Test]
        public void Case1Test()
        {
            this.mensaje.Text = "Agua oxigenada";
            this.estado.Step = 1;
            this.estado.Handler = "/crearpublicacion";
            this.handler.Handle(this.mensaje);
            string expected = "Ingrese la categoria: \n(/Químicos\n  /Plásticos\n  /Celulósicos\n  /Eléctricos\n  /Textiles)\n";
            Assert.AreEqual(expected, this.handler.TextResult.ToString());
        }

        /// <summary>
        /// Test que verifica que el bot le pide que la unidad que cuantifica el material.
        /// </summary>
        [Test]
        public void Case2Test()
        {
            this.mensaje.Text = "/quimicos";
            this.estado.Step = 2;
            this.estado.Handler = "/crearpublicacion";
            this.handler.Handle(this.mensaje);
            string expected = "Ingrese la unidad con la que cuantifica el material:";
            Assert.AreEqual(expected, this.handler.TextResult.ToString());
        }

        /// <summary>
        /// Test que verifica que el bot le pide que ingrese precio por unidad.
        /// </summary>
        [Test]
        public void Case3Test()
        {
            this.mensaje.Text = "litros";
            this.estado.Step = 3;
            this.estado.Handler = "/crearpublicacion";
            this.handler.Handle(this.mensaje);
            string expected = "Ingrese el precio por unidad:";
            Assert.AreEqual(expected, this.handler.TextResult.ToString());
        }

        /// <summary>
        /// Test que verifica que el bot le pide que ingrese la cantidad que desea publicar del material.
        /// </summary>
        [Test]
        public void Case4Test()
        {
            this.mensaje.Text = "10";
            this.estado.Step = 4;
            this.estado.Handler = "/crearpublicacion";
            this.handler.Handle(this.mensaje);
            string expected = "Ingrese la cantidad:";
            Assert.AreEqual(expected, this.handler.TextResult.ToString());
        }

        /// <summary>
        /// Test que verifica que el bot le pide que si se necesita habilitaciones para manipular el material.
        /// </summary>
        [Test]
        public void Case5Test()
        {
            this.mensaje.Text = "40";
            this.estado.Step = 5;
            this.estado.Handler = "/crearpublicacion";
            this.handler.Handle(this.mensaje);
            string expected = "Ingrese habilitaciones necesarias para manipular el material:";
            Assert.AreEqual(expected, this.handler.TextResult.ToString());
        }

        /// <summary>
        /// Test que verifica que el bot le pide que ingrese el titulo de la publicación.
        /// </summary>
        [Test]
        public void Case6Test()
        {
            this.mensaje.Text = "Ninguna";
            this.estado.Step = 6;
            this.estado.Handler = "/crearpublicacion";
            this.handler.Handle(this.mensaje);
            string expected = "Ingrese el título:";
            Assert.AreEqual(expected, this.handler.TextResult.ToString());
        }

        /// <summary>
        /// Test que verifica que el bot le pide que ingrese las palabras claves de su publicación.
        /// </summary>
        [Test]
        public void Case7Test()
        {
            this.mensaje.Text = "Agua Oxígenada para todos";
            this.estado.Step = 7;
            this.estado.Handler = "/crearpublicacion";
            this.handler.Handle(this.mensaje);
            string expected = "Ingrese palabras claves separadas con ',' : ";
            Assert.AreEqual(expected, this.handler.TextResult.ToString());
        }

        /// <summary>
        /// Test que verifica que el bot le pide que ingrese la frequencia del material.
        /// </summary>
        [Test]
        public void Case8Test()
        {
            this.mensaje.Text = "Agua Oxigenada, Agua";
            this.estado.Step = 8;
            this.estado.Handler = "/crearpublicacion";
            this.handler.Handle(this.mensaje);
            string expected = "Ingrese frequencia de disponibilidad: ";
            Assert.AreEqual(expected, this.handler.TextResult.ToString());
        }

        /// <summary>
        /// Test que verifica que el bot le pide la ubicación donde se encuentra el material.
        /// </summary>
        [Test]
        public void Case9Test()
        {
            this.mensaje.Text = "1 vez por semana";
            this.estado.Step = 9;
            this.estado.Handler = "/crearpublicacion";
            this.handler.Handle(this.mensaje);
            string expected = "Ingrese dónde se encuentra: ";
            Assert.AreEqual(expected, this.handler.TextResult.ToString());
        }

/*
        /// <summary>
        /// Test que verifica si la publicación se creo correctamente.
        /// </summary>
        [Test]
        public void Case10Test_1()
        {
            this.mensaje.Text = "Montevideo";
            this.handler.localizacion = this.mensaje.Text;
            this.estado.Step = 10;
            this.estado.Handler = "/crearpublicacion";
            this.handler.Handle(this.mensaje);
            Assert.AreEqual(this.handler.localizacion, this.mensaje.Text);
        }

        /// <summary>
        /// Test que verifica si el bot responde correctamente.
        /// </summary>
        [Test]
        public void Case10Test_2()
        {
            this.mensaje.Text = "Montevideo";
            this.handler.localizacion = this.mensaje.Text;
            this.estado.Step = 10;
            this.estado.Handler = "/crearpublicacion";
            this.handler.Handle(this.mensaje);
            string expected = "Tú publicación ahora se encuentra activa.";
            Assert.AreEqual(expected, this.handler.TextResult.ToString());
        }
*/

/*
        /// <summary>
        /// Test que verifica que si la persona no es un empresario no pueda crear una publicación.
        /// </summary>
        // [Test]
        // public void ElseTest()
        // {
        //     Mensaje mensaje = new Mensaje(8888, "/crearpublicacion");
        //     estado.Step = 0;
        //     estado.Handler = "/crearpublicacion";
        //     handler.Handle(mensaje);
        //     string expected = "Para crear publicaciones debe pertenecer a una empresa.";
        //     Assert.AreEqual(expected, handler.TextResult.ToString());
        // }
    */
    }
}
