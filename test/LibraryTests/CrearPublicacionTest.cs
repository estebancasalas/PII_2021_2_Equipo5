using NUnit.Framework;
using Library;
using System.Collections.Generic;

namespace LibraryTests
{

    [TestFixture]
    public class CrearPublicacionTest
    {
        Mensaje mensaje;
        CrearPublicacionHandler publi = new CrearPublicacionHandler();
        Dictionary<string, string> diccionario = new Dictionary<string, string>();
       
        [SetUp]
        public void Setup()
        {
            diccionario.Add("Ingrese el material:", "tela");
            diccionario.Add("Ingrese la categoria:", "Textiles");
            diccionario.Add("Ingrese la unidad con la que cuantifica el material:", "Metro");
            diccionario.Add("Ingrese el precio por unidad:", "3");
            diccionario.Add("Ingrese la cantidad:", "6");
            diccionario.Add("Ingrese habilitaciones necesarias para manipular el material:", "");
            diccionario.Add("Ingrese el título:", "tela");
            diccionario.Add("Ingrese palabras claves separadas con ',' : ", "");
            diccionario.Add("Ingrese frequencia de disponibilidad: ", "mensual");
            diccionario.Add("Ingrese dónde se encuentra: ", "Av. 8 de Octubre 2738");
            diccionario.Add("Ingrese nombre de la empresa: ", "Esteban telas");
        }

        [Test]
        public void PublicacionValidaTest()
        {
            
            Mensaje mensaje = new Mensaje(1234,"/CrearPublicación");
            Empresa empresa = new Empresa("Esteban telas", "Av. 8 de Octubre 2738", "textil", "1");
            empresa.ListaIdEmpresarios.Add(mensaje.Id);
            EntaradaDeLaCadena lector = new LectorTest(diccionario);
            publi.Input = lector;
            publi.Handle(mensaje);
            Assert.That(RegistroPublicaciones.Activas.Count>0,Is.True);
        }
        [Test]
        public void PublicacionNoValidaTest()
        {

            Mensaje mensaje = new Mensaje(789,"/CrearPublicación");
            IUsuario emprendedor = new Emprendedor(789,"", "", "", "", "");
            EntaradaDeLaCadena lector = new LectorTest(diccionario);
            publi.Input = lector;
            publi.Handle(mensaje);
            Assert.That(RegistroPublicaciones.Activas.Count>0,Is.True);
        }
    }
}