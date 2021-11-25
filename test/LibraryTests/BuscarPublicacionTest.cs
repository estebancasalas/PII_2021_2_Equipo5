// <copyright file="BuscarPublicacionTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections.Generic;
using Library;
using NUnit.Framework;
using Ucu.Poo.Locations.Client;

namespace LibraryTests
{
    /// <summary>
    /// Casos de prueba para buscar la publicacion.
    /// </summary>
    [TestFixture]
    public class BuscarPublicacionTest
    {
        private Publicacion a;
        private Publicacion b;
        private Publicacion c;
        Mensaje mensaje;

        [SetUp]
        public void Setup()
        {
            EstadoUsuario estado = new EstadoUsuario();
            Empresario empresario = new Empresario(1234, estado, "Juan");
            List<IUsuario> lista = Singleton<List<IUsuario>>.Instance;
            lista.Add(empresario);

            Material madera = new Material("PMadera", 1, 2, "Cantidad", "Habilitación1", "Químicos");
            Material dos = new Material("Material2", 3, 4, "Cantidad", "Habilitación1", "Plásticos");
            Material tres = new Material("Material3", 5, 6, "Cantidad", "Habilitación1", "Eléctricos");

            IUbicacion alfa = new Ubicacion("Uruguay", "Montevideo", null, null, null, null);
            IUbicacion beta = new Ubicacion("Uruguay", "Salto", null, null, null, null);
            IUbicacion gamma = new Ubicacion("Uruguay", "Tacuarembo", null, null, null, null);

            Empresa empresa1 = new Empresa("Empresa1", "UbicacionEmpresa1", "maderero", "123");
            Empresa empresa2 = new Empresa("Empresa2", "UbicacionEmpresa2", "plastico", "1232");
            Empresa empresa3 = new Empresa("Empresa3", "UbicacionEmpresa3", "electrica", "1233");

            this.a = new Publicacion("1", madera, "madera", "todos los dias", alfa, empresa1);
            this.b = new Publicacion("2", dos, "plastico", "todos los dias", beta, empresa2);
            this.c = new Publicacion("3", tres, "electrico", "todos los dias", gamma, empresa3);
        }

        /// <summary>
        /// En este test verificamos que, cuando la invitación es válida, el id del usuario se añade correctamente a la lista de,
        /// ids de la empresa.
        /// </summary>
        [Test]
        public void BusquedaCategoriaTest()
        {
            Dictionary<string, string> diccionario = new Dictionary<string, string>();
            diccionario.Add("Que tipo de busqueda desea realizar? /categoria, /ciudad, /palabrasclave", "/categoria");
            diccionario.Add("Que desea buscar?", "Químicos");
            BuscarPublicacionHandler buscarCategoria = new BuscarPublicacionHandler();
            EntaradaDeLaCadena lector = new LectorTest(diccionario);
            buscarCategoria.Input = lector;
            buscarCategoria.SetNext(new NullHandler());
            this.mensaje = new Mensaje(1234, "/buscarpublicacion");
            buscarCategoria.Handle(this.mensaje);
            Assert.AreEqual(buscarCategoria.Result.Contains(this.a), true);
        }

        [Test]
        public void BusquedaPorCiudadTest()
        {
            Dictionary<string, string> diccionario = new Dictionary<string, string>();
            diccionario.Add("Que tipo de busqueda desea realizar? /categoria, /ciudad, /palabrasclave", "/ciudad");
            diccionario.Add("Que desea buscar?", "Salto");
            Mensaje mensaje = new Mensaje(1234, "/buscarpublicacion");
            BuscarPublicacionHandler buscarCiudad = new BuscarPublicacionHandler();
            EntaradaDeLaCadena lector = new LectorTest(diccionario);
            buscarCiudad.Input = lector;
            buscarCiudad.SetNext(new NullHandler());
            buscarCiudad.Handle(mensaje);
            Assert.AreEqual(buscarCiudad.Result.Contains(this.b), true);
        }

        [Test]
        public void BusquedaPorPalabrasClaveTest()
        {
            Dictionary<string, string> diccionario = new Dictionary<string, string>();
            diccionario.Add("Que tipo de busqueda desea realizar? /categoria, /ciudad, /palabrasclave", "/palabrasclave");
            diccionario.Add("Que desea buscar?", "electrico");
            Mensaje mensaje = new Mensaje(1234, "/buscarpublicacion");
            BuscarPublicacionHandler buscarPalabra = new BuscarPublicacionHandler();
            EntaradaDeLaCadena lector = new LectorTest(diccionario);
            buscarPalabra.SetNext(new NullHandler());
            buscarPalabra.Input = lector;
            buscarPalabra.Handle(mensaje);
            Assert.AreEqual(buscarPalabra.Result.Contains(this.c), true);
        }
    }
}
