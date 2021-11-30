// <copyright file="CrearInvitacionHandlerTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections.Generic;
using Library;
using NUnit.Framework;

namespace LibraryTests
{
    /// <summary>
    /// Casos de prueba para el metodo CrearInvitacion.
    /// </summary>
    [TestFixture]
    public class CrearInvitacionHandlerTest
    {
        private InvitarHandler invitar = new InvitarHandler();
        private Mensaje mensajeNoAdmin = new Mensaje(1, "/crearinvitacion");
        private Mensaje mensaje = new Mensaje(1122, "/crearinvitacion");
        private EstadoUsuario estado = new EstadoUsuario();
        private Usuario user;
        private Usuario userNoAdmin;
        private Administrador admin;

        /// <summary>
        /// Setup de los casos de prueba.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.user = new Usuario(1122, this.estado);
            this.userNoAdmin = new Usuario(1, this.estado);
            ListaDeUsuario lista = new ListaDeUsuario();
            lista.Add(this.user);
            lista.Add(this.userNoAdmin);
            this.admin = new Administrador(1122, "Juan");
        }

        /// <summary>
        /// Caso de prueba que verifica que es necesario ser un administrador para crear una invitación.
        /// </summary>
        [Test]
        public void NoEsAdminTest()
        {
            string expected = string.Empty;
            this.mensajeNoAdmin.Text = "/crearinvitacion";
            this.estado.Step = 0;
            try
            {
                this.invitar.Handle(this.mensajeNoAdmin);
            }
            catch (SinPermisoException)
            {
                expected = "Usted no es un administrador.";
            }

            Assert.AreEqual("Usted no es un administrador.", expected);
        }

        /// <summary>
        /// Test del caso 0 de InvitarHandler.
        /// </summary>
        [Test]
        public void Case0Test()
        {
            this.mensaje.Text = "/crearinvitacion";
            this.user.Estado.Step = 0;
            this.invitar.Handle(this.mensaje);
            string expected = "¿Cuál es el nombre de la empresa?";
            Assert.AreEqual(expected, this.invitar.TextResult.ToString());
            Assert.AreEqual(this.user.Estado.Step, 1);
        }

        /// <summary>
        /// Test del caso 1 de InvitarHandler.
        /// </summary>
        [Test]
        public void Case1Test()
        {
            this.mensaje.Text = "colgatee";
            this.user.Estado.Step = 1;
            this.user.Estado.Handler = "/crearinvitacion";
            this.invitar.Handle(this.mensaje);
            string expected = "¿Cuál es la ubicación de la empresa?";
            Assert.AreEqual(expected, this.invitar.TextResult.ToString());
            Assert.AreEqual(this.user.Estado.Step, 2);
        }

        /// <summary>
        /// Test del caso 2 de InvitarHandler.
        /// </summary>
        [Test]
        public void Case2Test()
        {
            this.mensaje.Text = "8 de Octubre";
            this.user.Estado.Step = 2;
            this.user.Estado.Handler = "/crearinvitacion";
            this.invitar.Handle(this.mensaje);
            string expected = "¿Cuál es el rubro de la empresa?";
            Assert.AreEqual(expected, this.invitar.TextResult.ToString());
            Assert.AreEqual(this.user.Estado.Step, 3);
        }

        /// <summary>
        /// Test del caso 3 de InvitarHandler.
        /// </summary>
        [Test]
        public void Case3Test()
        {
            this.mensaje.Text = "textil";
            this.user.Estado.Step = 3;
            this.user.Estado.Handler = "/crearinvitacion";
            this.invitar.Handle(this.mensaje);
            string expected = "¿Mail o numero de teléfono para contactar a la empresa?";
            Assert.AreEqual(expected, this.invitar.TextResult.ToString());
            Assert.AreEqual(this.user.Estado.Step, 4);
        }

        /// <summary>
        /// Test del caso 4 de InvitarHandler.
        /// </summary>
        [Test]
        public void Case4Test()
        {
            this.mensaje.Text = "contacto@gmail.com";
            this.user.Estado.Step = 4;
            this.user.Estado.Handler = "/crearinvitacion";
            this.invitar.Handle(this.mensaje);
            string expected = "¿Qué codigo de invitación desea asignarle?";
            Assert.AreEqual(expected, this.invitar.TextResult.ToString());
            Assert.AreEqual(this.user.Estado.Step, 5);
        }

        /// <summary>
        /// Test del caso 5 de InvitarHandler.
        /// </summary>
        [Test]
        public void Case5Test()
        {
            this.mensaje.Text = "abc123";
            this.user.Estado.Step = 5;
            this.user.Estado.Handler = "/crearinvitacion";
            this.invitar.Nombre = "colgatee";
            this.invitar.Ubicacion = "8 de Octubre";
            this.invitar.Rubro = "textil";
            this.invitar.Contacto = "contacto@gmail.com";
            this.invitar.Handle(this.mensaje);
            string expected = "Empresa registrada con los siguientes datos:\nNombre: colgatee\nUbicacion: 8 de Octubre\nRubro: textil\nContacto: contacto@gmail.com\nInvitación: abc123";
            Assert.AreEqual(expected, this.invitar.TextResult.ToString());
            Assert.AreEqual(this.user.Estado.Step, 0);
        }
    }
}
