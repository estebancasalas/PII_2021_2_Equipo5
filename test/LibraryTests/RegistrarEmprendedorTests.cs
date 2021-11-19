using NUnit.Framework;
using Library;
using System.Collections.Generic;

namespace LibraryTests
{
    /// <summary>
    /// Casos de prueba para el handler de CrearEmprendedor.
    /// </summary>

    [TestFixture]
    public class RegistrarEmprendedorTests
    {
        Mensaje mensaje;
        CrearEmprendedorHandler emprendedor = new CrearEmprendedorHandler(); 
        Dictionary<string, string> diccionario = new Dictionary<string, string>();
       
       /// <summary>
       /// SetUp de los casos de prueba.
       /// </summary>
        [SetUp]
        public void Setup()
        {
            diccionario.Add("¿Cuál es su nombre?", "juan");
            diccionario.Add("¿Cuál es su rubro?", "zochori al pan");
            diccionario.Add("¿Cuál es la direccion de su domicilio?", "Av. 8 de Octubre 2738");
            diccionario.Add("¿Posee alguna habilitacion?", "nop");
            diccionario.Add("¿En qué se especializa?", "hacer bots y llorar");
        }

        /// <summary>
        /// Verifica que el emprendedor se registra correctamente.
        /// </summary>
        [Test]
        public void RegistrarEmprendedorTest()
        {
            Mensaje mensaje = new Mensaje(1234,"mensaje");
            EntaradaDeLaCadena lector = new LectorTest(diccionario);
            emprendedor.Input = lector;
            emprendedor.SetNext(new NullHandler());
            emprendedor.Handle(mensaje);
             List <Emprendedor> listaEmprendedor = Singleton<ListaEmprendedores>.Instance.Emprendedores;
            Assert.That(listaEmprendedor.Count>0,Is.True);
        }
    }
}