// <copyright file="CrearInvitacionTest.cs" company="PlaceholderCompany">
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
        private Administrador admin;

        /// <summary>
        /// Setup de los casos de prueba.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.user = new Usuario(1, this.estado);
            ListaDeUsuario lista = new ListaDeUsuario();
            lista.Add(this.user);
            this.admin = new Administrador(1122, "Juan");
        }
        
        // En InvitarHandler se verifica con usuario, administrador no es usuario
        // Cambié para que verifique con lista administradores, agregar caso en que usuario busca eso
        // [Test]
        // public void NoEsAdminTest()
        // {
        //     this.mensajeNoAdmin.Text = "/crearinvitacion";
        //     this.estado.Step = 0;
        //     string expected = "Usted no es un administrador.";
        //     invitar.Handle(mensajeNoAdmin);
        //     Assert.AreEqual(this.invitar.TextResult.ToString(), expected);
        // }

        [Test]
        public void Case0Test()
        {
            this.mensaje.Text = "/crearinvitacion";
            this.admin.Estado.Step = 0;
            invitar.Handle(mensaje);
            string expected = "¿Cuál es el nombre de la empresa?";
            Assert.AreEqual(expected, this.invitar.TextResult.ToString());
            Assert.AreEqual(this.admin.Estado.Step, 1);
        }

        [Test]
        public void Case1Test()
        {
            this.mensaje.Text = "colgatee";
            this.admin.Estado.Step = 1;
            this.admin.Estado.Handler = "/crearinvitacion";
            invitar.Handle(mensaje);
            string expected = "¿Cuál es la ubicación de la empresa?";
            Assert.AreEqual(expected, this.invitar.TextResult.ToString());
           // Assert.AreEqual(this.admin.Estado.Step, 2);
        }

        [Test]
        public void Case2Test()
        {
            this.mensaje.Text = "8 de Octubre";
            this.admin.Estado.Step = 2;
            this.admin.Estado.Handler = "/crearinvitacion";
            invitar.Handle(mensaje);
            string expected = "¿Cuál es el rubro de la empresa?";
            Assert.AreEqual(expected, this.invitar.TextResult.ToString());
            //Assert.AreEqual(this.admin.Estado.Step, 3);
        }

        [Test]
        public void Case3Test()
        {
            this.mensaje.Text = "textil";
            this.admin.Estado.Step = 3;
            this.admin.Estado.Handler = "/crearinvitacion";
            invitar.Handle(mensaje);
            string expected = "¿Mail o numero de teléfono para contactar a la empresa?";
            Assert.AreEqual(expected, this.invitar.TextResult.ToString());
            //Assert.AreEqual(this.admin.Estado.Step, 4);
        }

        [Test]
        public void Case4Test()
        {
            this.mensaje.Text = "contacto@gmail.com";
            this.admin.Estado.Step = 4;
            this.admin.Estado.Handler = "/crearinvitacion";
            invitar.Handle(mensaje);
            string expected = "¿Qué codigo de invitación desea asignarle?";
            Assert.AreEqual(expected, this.invitar.TextResult.ToString());
            //Assert.AreEqual(this.admin.Estado.Step, 5);
        }

        [Test]
        public void Case5Test()
        {
            this.mensaje.Text = "abc123";
            this.admin.Estado.Step = 5;
            this.admin.Estado.Handler = "/crearinvitacion";
            this.invitar.Nombre = "colgatee";
            this.invitar.Ubicacion = "8 de Octubre";
            this.invitar.Rubro = "textil";
            this.invitar.Contacto = "contacto@gmail.com";
            this.invitar.Handle(mensaje);
            string expected = "Empresa registrada con los siguientes datos:\nNombre: colgatee\nUbicacion: 8 de Octubre\nRubro: textil\nContacto: contacto@gmail.com\nInvitación: abc123";
            Assert.AreEqual(expected, this.invitar.TextResult.ToString());
            //Assert.AreEqual(this.admin.Estado.Step, 0);
        }
    }
}
