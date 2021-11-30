// -----------------------------------------------------------------------
// <copyright file="EscenarioEmpresaVerHistorial.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using Library;
using NUnit.Framework;

namespace LibraryTests
{
    public class EscenarioEmpresaVerHistorialTest
    {
        private readonly Empresa empresa = new Empresa("Empresa Pilar", "Montevideo", "Textil", "InvitacionEmpresaJuan", "025896314");
        private readonly Empresario empresario = new Empresario(5566, new EstadoUsuario(), "Esteban");
        private readonly Usuario user = new Usuario(5566, new EstadoUsuario());
        private readonly ListaEmpresa listaEmpresa = new ListaEmpresa();
        private Mensaje message = new Mensaje(5566, string.Empty);
        private readonly HistorialHandler handler = new HistorialHandler();
        private string expected = string.Empty;

        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void EmpresaVerHistorialTest()
        {
            this.empresa.ListaEmpresarios.Add(this.empresario);

            this.message.Text = "/historial";
            this.expected = this.handler.Handle(this.message);

            Assert.AreEqual("No se encontraron elementos para mostrar.", this.expected);
        }

    }
}