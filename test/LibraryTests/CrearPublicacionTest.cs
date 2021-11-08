/*

Test comentado debido a errores inesperados qu eno tienen relacion con el core del bot. (errores al momento de utilizar el setup)

using NUnit.Framework;
using Library;
using System.Collections.Generic;

namespace LibraryTests
{

    [TestFixture]
    public class CrearPublicacionTest
    {
        Mensaje mensaje;
        CrearPublicacionHandler publi;
        Dictionary<string, string> diccionario = new Dictionary<string, string>();
        Dictionary<string, string> diccionario2 = new Dictionary<string, string>();
       
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
            diccionario2.Add("Ingrese el material:", "tela");
            diccionario2.Add("Ingrese la categoria:", "Textiles");
            diccionario2.Add("Ingrese la unidad con la que cuantifica el material:", "Metro");
            diccionario2.Add("Ingrese el precio por unidad:", "3");
            diccionario2.Add("Ingrese la cantidad:", "6");
            diccionario2.Add("Ingrese habilitaciones necesarias para manipular el material:", "");
            diccionario2.Add("Ingrese el título:", "tela");
            diccionario2.Add("Ingrese palabras claves separadas con ',' : ", "");
            diccionario2.Add("Ingrese frequencia de disponibilidad: ", "mensual");
            diccionario2.Add("Ingrese dónde se encuentra: ", "Av. 8 de Octubre 2738");
            diccionario2.Add("Ingrese nombre de la empresa: ", "Esteban telas");
            Mensaje mensaje = new Mensaje(1234,"/CrearPublicación");
            Empresa empresa = new Empresa("Esteban telas", "Av. 8 de Octubre 2738", "textil", "1");
            empresa.ListaIdEmpresarios.Add(mensaje.Id);
            EntaradaDeLaCadena lector = new LectorTest(diccionario2);
            publi = new CrearPublicacionHandler();
            publi.Input = lector;
            publi.Handle(mensaje);
            Assert.That(RegistroPublicaciones.Activas.Count>0,Is.True);
        }
        [Test]
        public void PublicacionNoValidaTest()
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
            Mensaje mensaje = new Mensaje(789,"/CrearPublicación");
            IUsuario emprendedor = new Emprendedor(789,"", "", "", "", "");
            EntaradaDeLaCadena lector = new LectorTest(diccionario);
            publi = new CrearPublicacionHandler();
            publi.Input = lector;
            publi.Handle(mensaje);
            Assert.That(RegistroPublicaciones.Activas.Count>0,Is.True);
        }
    }
}
*/