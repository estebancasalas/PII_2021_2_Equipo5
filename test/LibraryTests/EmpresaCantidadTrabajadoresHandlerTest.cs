// <copyright file="EmpresaCantidadTrabajadoresHandlerTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
using System;
using Library;
using NUnit.Framework;

namespace LibraryTests
{
    /// <summary>
    /// Casos de prueba para el handler que muestra la cantidad de trabajadores de una empresa.
    /// </summary>
    [TestFixture]
    public class EmpresaCantidadTrabajadoresHandlerTest
    {
        private Empresa empresa = new Empresa("telares", "8 de Octubre", "textil", "aaa3", "hotmail");
        private EmpresaCantidadTrabajadores handler = new EmpresaCantidadTrabajadores();
        private EstadoUsuario estado = new EstadoUsuario();
        private EstadoUsuario estado2 = new EstadoUsuario();
        private Usuario usuario;
        private Usuario usuario2;
        private ListaDeUsuario lista = new ListaDeUsuario();
        private Mensaje mensaje = new Mensaje(007, "/cantidadtrabajadores");
        private Mensaje mensaje2 = new Mensaje(008, "/cantidadtrabajadores");
        private Empresario empresario;

        /// <summary>
        /// Setup del test.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.usuario = new Usuario(007, this.estado);
            this.usuario2 = new Usuario(008, this.estado2);
            this.lista.Add(this.usuario);
            this.lista.Add(this.usuario2);
            this.empresario = new Empresario(007, this.estado, "Bond, James Bond");
        }

        /// <summary>
        /// Prueba el primer handler.
        /// </summary>
        [Test]
        public void PerteneceAEmpresaTest()
        {
            this.empresa.ListaEmpresarios.Add(this.empresario);
            this.handler.Handle(this.mensaje);
            string expected = "La cantidad de trabajadores de la empresa es: 1";
            Assert.AreEqual(this.handler.TextResult.ToString(), expected);
        }

        /// <summary>
        /// Test que prueba el comando cuando el usuario no pertenece a una empresa.
        /// </summary>
        [Test]
        public void NoPerteneceAEmpresaTest()
        {
            string resultado = string.Empty;
            try
            {
                this.handler.Handle(this.mensaje2);
            }
            catch (SinPermisoException)
            {
                resultado = "Lo siento, para utilizar este comando debe pertenecer a una empresa.";
            }

            string expected = "Lo siento, para utilizar este comando debe pertenecer a una empresa.";
            Assert.AreEqual(expected, resultado);
        }
    }
}