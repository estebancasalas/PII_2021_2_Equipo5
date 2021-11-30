// -----------------------------------------------------------------------
// <copyright file="EscenarioEmpresaVerHistorial.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
/*
using System;
using Library;
using NUnit.Framework;

namespace LibraryTests
{
    public class EscenarioEmpresaVerHistorialTest
    {
        private readonly Empresa empresaPilar = new Empresa("Empresa Pilar", "Montevideo", "Textil", "InvitacionEmpresaJuan", "025896314");
        private readonly Empresario empresario = new Empresario(55667, new EstadoUsuario(), "Esteban");
        private readonly Usuario user = new Usuario(55667, new EstadoUsuario());
        private readonly ListaEmpresa listaEmpresa = new ListaEmpresa();
        private Mensaje message = new Mensaje(55667, string.Empty);
        private readonly HistorialHandler handler = new HistorialHandler();

        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void EmpresaVerHistorialTest()
        {
            string expected = string.Empty;
            this.empresaPilar.ListaEmpresarios.Add(this.empresario);

            this.message.Text = "/historial";
            expected = this.handler.Handle(this.message);

            Assert.AreEqual("No se encontraron elementos para mostrar.", expected);
        }

    }
}
*/