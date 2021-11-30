// -----------------------------------------------------------------------
// <copyright file="RegistrarEmpresarioTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using Library;
using NUnit.Framework;

namespace LibraryTests
{
    /// <summary>
    /// Casos de prueba para el handler RegistrarEmpresario.
    /// </summary>
    [TestFixture]
    public class RegistrarEmpresarioTest
    {
        private Usuario usuario1 = new Usuario(4567, new EstadoUsuario());
        private Mensaje mensaje1 = new Mensaje(4567, "/Empresario");
        private RegistrarEmpresarioHandler handlerTest1 = new RegistrarEmpresarioHandler();
        private Empresa empresa = new Empresa("Colgate", "Montevideo", "Metalurgica", "invitación colgate", "099876543");

        /// <summary>
        /// SetUp de los casos de prueba.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            ListaDeUsuario listaDeUsuario = new ListaDeUsuario();
            listaDeUsuario.Add(this.usuario1);
            ListaEmpresa listaEmpresa = new ListaEmpresa();
            listaEmpresa.Add(this.empresa);
            ListaInvitaciones listaInvitaciones = new ListaInvitaciones();
            listaInvitaciones.Add("invitación colgate");
        }

        /// <summary>
        /// Verifica que la primer interacción del handler es correcta.
        /// </summary>
        [Test]
        public void Case0Test()
        {
            this.handlerTest1.Handle(this.mensaje1);
            string expected = "Ingrese su código de invitación: ";
            Assert.AreEqual(expected, this.handlerTest1.TextResult.ToString());
        }

        /// <summary>
        /// Verifica que, cuando la invitación es válida, el segundo paso del handler sea correcto.
        /// </summary>
        [Test]
        public void Caso1InvitacionValidaTest()
        {
            this.usuario1.Estado.Step = 1;
            this.usuario1.Estado.Handler = "/Empresario";
            this.mensaje1.Text = "invitación colgate";
            this.handlerTest1.Handle(this.mensaje1);
            string expected = "Ingrese su nombre: ";
            Assert.AreEqual(expected, this.handlerTest1.TextResult.ToString());
            Assert.AreEqual(this.mensaje1.Text, this.handlerTest1.Invitacion);
        }

        /// <summary>
        /// Verifica que, cuando la invitación no es válida, el segundo paso del handler sea correcto.
        /// </summary>
        [Test]
        public void Caso1InvitacionNoValidaTest()
        {
            this.usuario1.Estado.Step = 1;
            this.usuario1.Estado.Handler = "/Empresario";
            this.mensaje1.Text = "invitación colgaatee";
            string resultado = string.Empty;
            try
            {
                this.handlerTest1.Handle(this.mensaje1);
            }
            catch (OpcionInvalidaException)
            {
                resultado = "Lo siento, su invitacion no es valida. El proceso se ha finalizado.";
            }
            string expected = "Lo siento, su invitacion no es valida. El proceso se ha finalizado.";
            Assert.AreEqual(expected, resultado);
        }

        /// <summary>
        /// Verifica que el tercer paso del handler sea correcto.
        /// </summary>
        [Test]
        public void Caso2Test()
        {
            this.usuario1.Estado.Step = 2;
            this.usuario1.Estado.Handler = "/Empresario";
            this.mensaje1.Text = "Pedro";
            this.handlerTest1.Empresa = this.empresa;
            this.handlerTest1.Handle(this.mensaje1);
            string expected = $"{this.handlerTest1.Nombre}, te has registrado a {this.handlerTest1.Empresa.Nombre} correctamente";
            Assert.AreEqual(expected, this.handlerTest1.TextResult.ToString());
            Assert.AreEqual(this.mensaje1.Text, this.handlerTest1.Nombre);
        }

        /// <summary>
        /// Verfica que el handler no se ejecuta si el usuario está previamente registrado.
        /// </summary>
        [Test]
        public void UsuarioRegistradoTest()
        {
            Emprendedor emprendedor = new Emprendedor(4321, "Pedro", "A.v 8 de Octubre 2347", "Metalúrgico", "Si.", "Aluminio");
            ListaEmprendedores listaEmprendedores = new ListaEmprendedores();
            listaEmprendedores.Add(emprendedor);
            Usuario usuario = new Usuario(4321, new EstadoUsuario());
            ListaDeUsuario listaDeUsuario = new ListaDeUsuario();
            listaDeUsuario.Add(usuario);
            Mensaje mensaje1 = new Mensaje(4321, "/Empresario");
            string resultado = string.Empty;
            try
            {
                this.handlerTest1.Handle(mensaje1);
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