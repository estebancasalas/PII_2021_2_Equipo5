using NUnit.Framework;
using Library;
using System.Collections.Generic;

namespace LibraryTests
{
    /// <summary>
    /// Casos de prueba para el metodo CrearInvitacion
    /// </summary>
    [TestFixture]
    public class CrearInvitacionTests
    {
        Mensaje mensaje;
        InvitarHandler invitar;

        /// <summary>
        /// Setup de los casos de prueba.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            ListaEmpresa lista1 = new ListaEmpresa();

        }

        /// <summary>
        /// En este test verificamos que, cuando la invitación es válida, el id del usuario se añade correctamente a la lista de 
        /// ids de la empresa.
        /// </summary>
        [Test]
        public void InvitacionValidaTest()
        {
            Mensaje mensaje = new Mensaje(1234,"/crearinvitacion");
            Administrador admin = new Administrador(1234, "admin");
            invitar = new InvitarHandler();
            Dictionary<string, string> diccionario = new Dictionary<string, string>();
            diccionario.Add("nombre empresa", "empresa1");
            diccionario.Add("ubicacion de la empresa", "Av. 8 de Octubre 2738");
            diccionario.Add("rubro de la empresa","textil");
            diccionario.Add("Codigo de invitacion", "invitacion1");
            
            
            EntaradaDeLaCadena lector = new LectorTest(diccionario);
            invitar.Input = lector;
            invitar.SetNext(new NullHandler());
            invitar.Handle(mensaje);
            List <Empresa> listaEmpresa = Singleton<ListaEmpresa>.Instance.Empresas;
            List <string> listaInvitaciones = Singleton<ListaInvitaciones>.Instance.Invitaciones;
            Assert.That(listaInvitaciones.Contains("invitacion1"),Is.True);
            Assert.AreNotEqual(listaEmpresa.Find(x => x.Invitacion == "invitacion1"), null);

        }
    }
}