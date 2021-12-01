// -----------------------------------------------------------------------
// <copyright file="AceptarInvitacionTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using Library;
using NUnit.Framework;

namespace LibraryTests
{
    /// <summary>
    /// Test de User Story.
    /// Este test comprueba que un usuario puede unirse a una empresa mediante un código de invitación, y asi poder crear publicaciones.
    /// </summary>
    public class AceptarInvitacionTest
    {
        private Usuario user = new Usuario(45, new EstadoUsuario());
        private RegistrarEmpresarioHandler handler = new RegistrarEmpresarioHandler();
        private Mensaje message = new Mensaje(45, string.Empty);
        private ListaDeUsuario listaDeUsuario = new ListaDeUsuario();
        private ListaInvitaciones listaInvitaciones = new ListaInvitaciones();
        private ListaEmpresa listaEmpresa = new ListaEmpresa();
        private Empresa empresa;

        /// <summary>
        /// SetUp del caso de prueba.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.empresa = new Empresa("Empresa Ionas", "8 de Octubre 2738", "Textil", "InvitacionEmpresaIonas", "099123456");
            this.listaDeUsuario.Add(this.user);
            this.listaInvitaciones.Add("InvitacionEmpresaIonas");
        }

        /// <summary>
        /// Caso de prueba que verifica que un usuario se puede unir a una empresa mediante un codigo de invitación.
        /// </summary>
        [Test]
        public void AceptarInvitacionEmpresaTest()
        {
            this.message.Text = "/Empresario";
            this.handler.Handle(this.message);

            this.message.Text = "InvitacionEmpresaIonas";
            this.handler.Handle(this.message);

            this.message.Text = "Esteban Casalás";
            this.handler.Handle(this.message);

            Empresa expected = this.listaEmpresa.Buscar(this.message.Id);
            Assert.AreEqual(expected, this.empresa);
        }
    }
}