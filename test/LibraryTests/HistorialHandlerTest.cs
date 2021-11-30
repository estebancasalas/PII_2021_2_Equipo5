// -----------------------------------------------------------------------
// <copyright file="HistorialHandlerTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using Library;
using NUnit.Framework;

namespace LibraryTests
{
    /// <summary>
    /// Casos de prueba para el handler Historial.
    /// </summary>
    [TestFixture]
    public class HistorialHandlerTest
    {
        // Dictionary<string, string> comprarDicc = new Dictionary<string, string>();
        HistorialHandler handlerInvitar = new HistorialHandler();
        Emprendedor emprendedor = new Emprendedor(9999, "emprendedor", "8 de Octubre", "textil", "nada", "nada");
        Empresa empresa = new Empresa("empresa", "8 de Octubre", "textol", "12", "gmail");
        EstadoUsuario estado = new EstadoUsuario();
        Empresario empresario;
        Material material = new Material("tela", 2, 2, "m", "nada", "nada");
        Transaccion transaccion;
        Mensaje mensaje1 = new Mensaje(9999, "/historial"); //emprendedor
        Mensaje mensaje2 = new Mensaje(8765, "/historial"); //empresa
        ListaTransacciones lista = new ListaTransacciones();
        /// <summary>
        /// SetUp de los casos de prueba.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.empresario = new Empresario(8765, this.estado, "Ionas");
            this.transaccion = new Transaccion(this.empresa, this.emprendedor, this.material, 2);
            this.lista.Transacciones.Clear();
        }

        [Test]
        public void HistorialNoVacioPorEmprendedorTest()
        {
            this.lista.Add(this.transaccion);
            this.handlerInvitar.Handle(this.mensaje1);
            string expected = "Material: tela\nCantidad: 2\nVendedor: empresa\nComprador: emprendedor\n";
            Assert.AreEqual(expected, this.handlerInvitar.TextResult.ToString());
        }

        [Test]
        public void HistorialNoVacioPorEmpresaTest()
        {
            this.lista.Add(this.transaccion);
            this.handlerInvitar.Handle(this.mensaje2);
            string expected = "Material: tela\nCantidad: 2\nVendedor: empresa\nComprador: emprendedor\n";
            Assert.AreEqual(expected, this.handlerInvitar.TextResult.ToString());
        }

        /// <summary>
        /// En este test verificamos que, cuando la invitación es válida, el id del usuario se añade correctamente a la lista de
        /// ids de la empresa.
        /// </summary>
        [Test]
        public void VerHistorialVacioPorEmprendedorTest()
        {
            this.handlerInvitar.Handle(this.mensaje1);
            string expected = "No se encontraron elementos para mostrar.";
            Assert.AreEqual(expected, this.handlerInvitar.TextResult.ToString());
        }

        /// <summary>
        /// Se testea el metodo mostrar historial cuando el emprendedor tiene compras registradas.
        /// </summary>
        [Test]
        public void VerHistorialVacioPorEmpresaTest()
        {
            this.handlerInvitar.Handle(this.mensaje2);
            string resultado = "No se encontraron elementos para mostrar.";
            Assert.AreEqual(resultado, this.handlerInvitar.TextResult.ToString());
        }
   }
}
