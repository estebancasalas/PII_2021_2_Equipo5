// <copyright file="CrearPublicacionTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections.Generic;
using Library;
using NUnit.Framework;

namespace LibraryTests
{
    /// <summary>
    /// Test del handler crear publicacion.
    /// </summary>
    [TestFixture]
    public class CrearPublicacionTest
    {
        private CrearPublicacionHandler publi;
        private Dictionary<string, string> diccionario = new Dictionary<string, string>();
        private Dictionary<string, string> diccionario2 = new Dictionary<string, string>();

        /// <summary>
        /// Test que verifica que los empresarios pueden crear publicaciones.
        /// </summary>
        [Test]
        public void PublicacionValidaTest()
        {
            this.diccionario2.Add("Ingrese el material:", "tela");
            this.diccionario2.Add("Ingrese la categoria:", "Textiles");
            this.diccionario2.Add("Ingrese la unidad con la que cuantifica el material:", "Metro");
            this.diccionario2.Add("Ingrese el precio por unidad:", "3");
            this.diccionario2.Add("Ingrese la cantidad:", "6");
            this.diccionario2.Add("Ingrese habilitaciones necesarias para manipular el material:", "a");
            this.diccionario2.Add("Ingrese el título:", "tela");
            this.diccionario2.Add("Ingrese palabras claves separadas con ',' : ", "a");
            this.diccionario2.Add("Ingrese frequencia de disponibilidad: ", "mensual");
            this.diccionario2.Add("Ingrese dónde se encuentra: ", "Av. 8 de Octubre 2738");
            this.diccionario2.Add("Ingrese nombre de la empresa: ", "Esteban telas");
            Mensaje mensaje = new Mensaje(1234, "/CrearPublicacion");
            Empresa empresa = new Empresa("Esteban telas", "Av. 8 de Octubre 2738", "textil", "1");
            Empresario empresario = new Empresario(mensaje.Id, new EstadoUsuario(), "juan");
            empresa.ListaEmpresarios.Add(empresario);
            EntaradaDeLaCadena lector = new LectorTest(this.diccionario2);
            this.publi = new CrearPublicacionHandler();
            this.publi.Input = lector;
            this.publi.SetNext(new NullHandler());
            this.publi.Handle(mensaje);
            List<Publicacion> listaPublicacion = Singleton<RegistroPublicaciones>.Instance.Activas;
            Publicacion expected = listaPublicacion.Find(x => x.Vendedor.Nombre == "Esteban telas");
            Assert.AreNotEqual(expected, null);
        }

        /// <summary>
        /// Test que verifica que los emprendedores no pueden crear publicaciones.
        /// </summary>
        [Test]
        public void PublicacionNoValidaTest()
        {
            this.diccionario.Add("Ingrese el material:", "tela");
            this.diccionario.Add("Ingrese la categoria:", "Textiles");
            this.diccionario.Add("Ingrese la unidad con la que cuantifica el material:", "Metro");
            this.diccionario.Add("Ingrese el precio por unidad:", "3");
            this.diccionario.Add("Ingrese la cantidad:", "6");
            this.diccionario.Add("Ingrese habilitaciones necesarias para manipular el material:", "a");
            this.diccionario.Add("Ingrese el título:", "tela");
            this.diccionario.Add("Ingrese palabras claves separadas con ',' : ", "a");
            this.diccionario.Add("Ingrese frequencia de disponibilidad: ", "mensual");
            this.diccionario.Add("Ingrese dónde se encuentra: ", "Av. 8 de Octubre 2738");
            this.diccionario.Add("Ingrese nombre de la empresa: ", "jose");
            Mensaje mensaje = new Mensaje(789, "/CrearPublicación");
            IUsuario emprendedor = new Emprendedor(789, "jose", string.Empty, string.Empty, string.Empty, string.Empty);
            EntaradaDeLaCadena lector = new LectorTest(this.diccionario);
            this.publi = new CrearPublicacionHandler();
            this.publi.Input = lector;
            this.publi.SetNext(new NullHandler());
            this.publi.Handle(mensaje);
            List<Publicacion> listaPublicacion = Singleton<RegistroPublicaciones>.Instance.Activas;
            Publicacion expected = listaPublicacion.Find(x => x.Vendedor.Nombre == "jose");
            Assert.AreEqual(expected, null);
        }
    }
}
