// <copyright file="RegistrarEmprendedorTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections.Generic;
using Library;
using NUnit.Framework;

namespace LibraryTests
{
    /// <summary>
    /// Casos de prueba para el handler de CrearEmprendedor.
    /// </summary>
    [TestFixture]
    public class RegistrarEmprendedorTests
    {
        private readonly CrearEmprendedorHandler emprendedor = new ();
        private readonly Dictionary<string, string> diccionario = new ();

       /// <summary>
       /// SetUp de los casos de prueba.
       /// </summary>
        [SetUp]
        public void Setup()
        {
            this.diccionario.Add("¿Cuál es su nombre?", "juan");
            this.diccionario.Add("¿Cuál es su rubro?", "zochori al pan");
            this.diccionario.Add("¿Cuál es la direccion de su domicilio?", "Av. 8 de Octubre 2738");
            this.diccionario.Add("¿Posee alguna habilitacion?", "nop");
            this.diccionario.Add("¿En qué se especializa?", "hacer bots y llorar");
        }

        /// <summary>
        /// Verifica que el emprendedor se registra correctamente.
        /// </summary>
        [Test]
        public void RegistrarEmprendedorTest()
        {
            Mensaje mensaje = new (1234, "/emprendedor");
            EntaradaDeLaCadena lector = new LectorTest(this.diccionario);
            this.emprendedor.Input = lector;
            this.emprendedor.SetNext(new NullHandler());
            this.emprendedor.Handle(mensaje);
            ListaEmprendedores listaEmprendedor = new ();
            Assert.AreNotEqual(listaEmprendedor.Buscar(mensaje.Id), null);
        }
    }
}