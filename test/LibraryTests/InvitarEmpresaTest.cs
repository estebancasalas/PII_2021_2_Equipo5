
// -----------------------------------------------------------------------
// <copyright file="InvitarEmpresaTest.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using Library;
using NUnit.Framework;

namespace LibraryTests
{
    /// <summary>
    /// Test de User Story.
    /// Este test comprueba que un Administrador puede crear una invitacion de una empresa para que sus empresario puedan unirse
    /// y crear publicaciones.
    /// </summary>
    [TestFixture]
    public class InvitarEmpresaTest
    {
        private readonly Usuario usuarioAdmin = new Usuario(1234, new EstadoUsuario());
        private readonly ListaDeUsuario listaUsuario = new ListaDeUsuario();

        private readonly Mensaje message = new Mensaje(1234, string.Empty);
        private InvitarHandler handler = new InvitarHandler();

        /// <summary>
        /// En este caso de prueba, se simula la conversación del administrador con el bot.
        /// Al final de éste, se comprueba que se creo la empresa buscándola por su nombre.
        /// </summary>
        [Test]
        public void InvitarTest()
        {
            Administrador admin = new Administrador(1234, "Esteban");
            this.listaUsuario.Add(this.usuarioAdmin);

            // Primer mensaje del administrador.
            this.message.Text = "/crearinvitacion";
            this.handler.Handle(this.message);

            // Segundo mensaje del administrador.
            this.message.Text = "Empresa Esteban";
            this.handler.Handle(this.message);

            // Tercer mensaje del administrador.
            this.message.Text = "8 de Octubre 2738";
            this.handler.Handle(this.message);

            // Cuarto mensaje del administrador.
            this.message.Text = "Textil";
            this.handler.Handle(this.message);

            // Quinto mensaje del administrador.
            this.message.Text = "empresaEsteban@email.com";
            this.handler.Handle(this.message);

            // Sexto mensaje del administrador.
            this.message.Text = "InvitacionEmpresaEsteban";
            this.handler.Handle(this.message);

            ListaEmpresa listaEmpresa = new ListaEmpresa();
            Empresa expected;

            // Busca una empresa cuyo nombre coincida con el que ingresó en administrador.
            expected = listaEmpresa.Empresas.Find(x => x.Nombre == "Empresa Esteban");

            // Verifica que se encontro una empresa con ese nombre.
            Assert.AreNotEqual(expected, null);
        }
    }
}