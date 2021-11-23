// <copyright file="VerHistorialTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
/*
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

        [SetUp]
        public void Setup()
        {
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
            Mensaje mensaje = new Mensaje(1234, "/buscarpublicacion");
            BuscarPublicacionHandler buscarCategoria = new BuscarPublicacionHandler();
            EntaradaDeLaCadena lector = new LectorTest(diccionario);
            buscarCategoria.Input = lector;
            buscarCategoria.SetNext(new NullHandler());
            buscarCategoria.Handle(mensaje);
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
*/
/*
// <copyright file="VerHistorialTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using Library;
using NUnit.Framework;

namespace LibraryTests
{
    /// <summary>
    /// Casos de prueba para el handler Historial.
    /// </summary>
    [TestFixture]
    public class VerHistorialTest
    {
        // Dictionary<string, string> comprarDicc = new Dictionary<string, string>();

        /// <summary>
        /// SetUp de los casos de prueba.
        /// </summary>
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// En este test verificamos que, cuando la invitación es válida, el id del usuario se añade correctamente a la lista de
        /// ids de la empresa.
        /// </summary>
        [Test]
        public void VerHistorialEmprendedorVacioTest()
        {
            Emprendedor emprendedor = new Emprendedor(4321, "Javier", "Mvd", "Constru", "ninguna", "construir");
            Mensaje mensaje = new Mensaje(1234, "/historial");
            HistorialHandler historial = new HistorialHandler();
            IFormatoSalida salida = new OutputTest();
            historial.Output = salida;
            historial.SetNext(new NullHandler());
            historial.Handle(mensaje);
            string expected = "Tus transacciones son:\n";
            Assert.AreEqual(expected, historial.resultado);
        }

        /// <summary>
        /// Se testea el metodo mostrar historial cuando el emprendedor tiene compras registradas.
        /// </summary>
        [Test]
        public void VerHistorialEmprendedorNoVacioTest()
        {
            Empresa empresa = new Empresa("Adidas", "Montevideo", "zapatos", "1df2frgfrfdvuhwdujn3eji3rf");
            Emprendedor emprendedor = new Emprendedor(567, "Colgatte", "Mvd", "Veterinario", "ninguna", "curar");
            HistorialHandler historial = new HistorialHandler();
            Mensaje mensaje = new Mensaje(567, "/historial");
            Transaccion transaccion = new Transaccion(empresa, emprendedor, "Championes de Messi", 1);
            ListaTransacciones transacciones = new ListaTransacciones();
            List<Transaccion> listaTransacciones = Singleton<ListaTransacciones>.Instance.Transacciones;
            listaTransacciones.Add(transaccion);
            IFormatoSalida salida = new OutputTest();
            historial.Output = salida;
            historial.SetNext(new NullHandler());
            historial.Handle(mensaje);
            string resultado = "Tus transacciones son:\nAdidas vendió 1 de Championes de Messi a Colgatte\n";
            Assert.AreEqual(resultado, historial.resultado);
        }
    }
}
*/