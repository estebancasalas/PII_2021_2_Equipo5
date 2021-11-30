// <copyright file="ComienzoHandlerTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
using System;
using Library;
using NUnit.Framework;

namespace LibraryTests
{
    /// <summary>
    /// Casos de prueba para el handler inicial de la cadena.
    /// </summary>
    [TestFixture]
    public class ComienzoHandlerTest
    {
        private ComienzoHandler handler = new ComienzoHandler();
        private EstadoUsuario estado = new EstadoUsuario();
        private Usuario usuario;
        private ListaDeUsuario lista = new ListaDeUsuario();
        private Mensaje mensaje = new Mensaje(000, "/comandos");

        /// <summary>
        /// Setup del test.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.usuario = new Usuario(000, this.estado);
            this.lista.Add(this.usuario);
        }

        /// <summary>
        /// Prueba el primer handler.
        /// </summary>
        [Test]
        public void Case0Test()
        {
            this.handler.Handle(this.mensaje);
            string expected = "Bienvenido al Bot de materiales reciclables, te ayudaré a encontrar el material que quieras para tu emprendimiento, los comandos disponibles son: \nComo empresa tus comandos son: \n/empresario\n/crearpublicacion\n/cantidadtrabajadores\n/crearinvitacion\n/historial\n/salir\nComo emprendedor tus comandos son: \n/emprendedor\n/buscarpublicacion\n/historial\n/comprar\n/salir\n";
            Assert.AreEqual(this.handler.TextResult.ToString(), expected);
        }
    }
}
