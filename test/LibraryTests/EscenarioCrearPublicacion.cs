using System;
using Library;
using NUnit.Framework;

namespace LibraryTests
{
    [TestFixture]
    public class EscenarioCrearPublicacionTest
    {
        private readonly Empresa empresa = new Empresa("Empresa Juan", "Montevideo", "Textil", "InvitacionEmpresaJuan", "025896314");
        private readonly Empresario empresario = new Empresario(6655, new EstadoUsuario(), "Esteban");
        private readonly Usuario user = new Usuario(6655, new EstadoUsuario());
        private readonly ListaDeUsuario listaUsuario = new ListaDeUsuario();
        private readonly ListaEmpresa listaEmpresa = new ListaEmpresa();
        private Mensaje message = new Mensaje(6655, string.Empty);
        private CrearPublicacionHandler handler = new CrearPublicacionHandler();
        private readonly RegistroPublicaciones registroPublicaciones = new RegistroPublicaciones();

        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void CrearPublicacionTest()
        {
            this.empresa.ListaEmpresarios.Add(this.empresario);

            this.message.Text = "/crearpublicacion";
            this.handler.Handle(this.message);

            this.message.Text = "Madera";
            this.handler.Handle(this.message);

            this.message.Text = "/celulosicos";
            this.handler.Handle(this.message);

            this.message.Text = "Kg";
            this.handler.Handle(this.message);

            this.message.Text = "50";
            this.handler.Handle(this.message);

            this.message.Text = "500";
            this.handler.Handle(this.message);

            this.message.Text = "Ninguna";
            this.handler.Handle(this.message);

            this.message.Text = "Maderas Juan";
            this.handler.Handle(this.message);

            this.message.Text = "Madera, tablas, troncos";
            this.handler.Handle(this.message);

            this.message.Text = "Cada 2 semanas";
            this.handler.Handle(this.message);

            this.message.Text = "Salto, Salto";
            this.handler.Handle(this.message);

            Publicacion expected = this.registroPublicaciones.Activas.Find(x => x.Titulo == "Maderas Juan");
            Assert.AreNotEqual(null, expected);
        }
    }
}