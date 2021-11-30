// <copyright file="RegistrarEmprendedorTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections.Generic;
using Library;
using NUnit.Framework;

namespace LibraryTests
{
    /// <summary>
    /// Casos de prueba para el handler de CrearEmprendedor.
    /// Se testean los pasos del handler individualmente, de esta forma se comprueba que cada
    /// paso se ejecuta correctamente y que el conjunto de los pasos también lo hace.
    /// </summary>
    [TestFixture]
    public class RegistrarEmprendedorTests
    {
        private Usuario user = new Usuario(1234, new EstadoUsuario());
        private Mensaje mensaje = new Mensaje(1234, "/Emprendedor");
        private CrearEmprendedorHandler handlerTest = new CrearEmprendedorHandler();

       /// <summary>
       /// SetUp de los casos de prueba.
       /// </summary>
        [SetUp]
        public void Setup()
        {
            ListaDeUsuario listaDeUsuario = new ListaDeUsuario();
            listaDeUsuario.Add(this.user);
        }

        /// <summary>
        /// Verifica que la primer interacción del handler es correcta.
        /// </summary>
        [Test]
        public void Caso0Test()
        {
            this.handlerTest.Handle(this.mensaje);
            string expected = "¿Cuál es su nombre?";
            Assert.AreEqual(expected, this.handlerTest.TextResult.ToString());
        }

        /// <summary>
        /// Test que verfica la segunda interacción del handler es correcta.
        /// </summary>
        [Test]
        public void Caso1Test()
        {
            this.user.Estado.Step = 1;
            this.user.Estado.Handler = "/emprendedor";
            this.mensaje.Text = "Juan";
            this.handlerTest.Handle(this.mensaje);
            string expected = "¿Cuál es su rubro?";
            Assert.AreEqual(expected, this.handlerTest.TextResult.ToString());
            Assert.AreEqual(this.mensaje.Text, this.handlerTest.Nombre);
        }

        /// <summary>
        /// Test que verfica la tercera interacción del handler es correcta.
        /// </summary>
        [Test]
        public void Caso2Test()
        {
            this.user.Estado.Step = 2;
            this.user.Estado.Handler = "/emprendedor";
            this.mensaje.Text = "Textil";
            this.handlerTest.Handle(this.mensaje);
            string expected = "¿Cuál es la direccion de su domicilio/emprendimiento?";
            Assert.AreEqual(expected, this.handlerTest.TextResult.ToString());
            Assert.AreEqual(this.mensaje.Text, this.handlerTest.Rubro);
        }

        /// <summary>
        /// Test que verfica la cuarta interacción del handler es correcta.
        /// </summary>
        [Test]
        public void Caso3Test()
        {
            this.user.Estado.Step = 3;
            this.user.Estado.Handler = "/emprendedor";
            this.mensaje.Text = "18 de Julio 2333";
            this.handlerTest.Handle(this.mensaje);
            string expected = "¿Posee alguna habilitacion?";
            Assert.AreEqual(expected, this.handlerTest.TextResult.ToString());
            Assert.AreEqual(this.mensaje.Text, this.handlerTest.Ubicacion);
        }

        /// <summary>
        /// Test que verfica la quinta interacción del handler es correcta.
        /// </summary>
        [Test]
        public void Caso4Test()
        {
            this.user.Estado.Step = 4;
            this.user.Estado.Handler = "/emprendedor";
            this.mensaje.Text = "No.";
            this.handlerTest.Handle(this.mensaje);
            string expected = "¿En qué se especializa?";
            Assert.AreEqual(expected, this.handlerTest.TextResult.ToString());
            Assert.AreEqual(this.mensaje.Text, this.handlerTest.Habilitacion);
        }

        /// <summary>
        /// Test que verfica la sexta interacción del handler es correcta.
        /// </summary>
        [Test]
        public void Caso5Test()
        {
            this.user.Estado.Step = 5;
            this.user.Estado.Handler = "/emprendedor";
            this.mensaje.Text = "Telar";
            this.handlerTest.Nombre = "Juan";
            this.handlerTest.Rubro = "Textil";
            this.handlerTest.Ubicacion = "18 de Julio 2333";
            this.handlerTest.Habilitacion = "No";
            this.handlerTest.Handle(this.mensaje);
            string expected = $"Usted se ha registrado con los siguientes datos:\nJuan\nTextil\n18 de Julio 2333\nNo\nTelar\n\nSi quiere seguir utilizando el bot ingrese otro /comandos .";
            Assert.AreEqual(expected, this.handlerTest.TextResult.ToString());
            Assert.AreEqual(this.mensaje.Text, this.handlerTest.Especializaciones);
        }

        /// <summary>
        /// Verfica que el handler no se ejecuta si el usuario está previamente registrado.
        /// </summary>
        [Test]
        public void UsuarioRegistradoTest()
        {
            Emprendedor emprendedor = new Emprendedor(4321, "Pedro", "Av. 8 de Octubre 2347", "Metalúrgico", "Si.", "Aluminio");
            ListaEmprendedores listaEmprendedores = new ListaEmprendedores();
            listaEmprendedores.Add(emprendedor);
            Usuario usuario = new Usuario(4321, new EstadoUsuario());
            ListaDeUsuario listaDeUsuario = new ListaDeUsuario();
            listaDeUsuario.Add(usuario);
            Mensaje mensaje1 = new Mensaje(4321, "/Emprendedor");
            string resultado = string.Empty;
            try
            {
                this.handlerTest.Handle(mensaje1);
            }
            catch (YaRegistradoException)
            {
                resultado = "Usted ya está registrado.";
            }

            string expected = "Usted ya está registrado.";
            Assert.AreEqual(expected, resultado);
        }
    }
}
