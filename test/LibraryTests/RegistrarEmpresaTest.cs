using NUnit.Framework;
using Library;
using System.Collections.Generic;

namespace LibraryTests
{
    /// <summary>
    /// Casos de prueba para el handler RegistrarEmpresario.
    /// </summary>
    [TestFixture]
    public class RegistrarEmpresarioTests
    {
        Mensaje mensaje;
        RegistrarEmpresarioHandler registrarEmpresario;
       
       /// <summary>
       /// SetUp de los casos de prueba.
       /// </summary>
        [SetUp]
        public void Setup()
        {
            ListaEmpresa lista1 = new ListaEmpresa();
            Dictionary<string, string> diccionario = new Dictionary<string, string>();
        }

        /// <summary>
        /// En este test verificamos que, cuando la invitación es válida, el id del usuario se añade correctamente a la lista de 
        /// ids de la empresa.
        /// </summary>
        [Test]
        public void InvitacionValidaTest()
        {
            Dictionary<string, string> diccionario = new Dictionary<string, string>();
            diccionario.Add("Ingrese su código de invitación: ", "ValidToken");

            Mensaje mensaje = new Mensaje(1000,"/empresa");
            RegistrarEmpresarioHandler registrarEmpresario = new RegistrarEmpresarioHandler();
            Empresa empresa1 = new Empresa("ResgistrarEmpresaTest", "Montevideo", "textil", "ValidToken");
            List <string> lista = Singleton<ListaInvitaciones>.Instance.Invitaciones;
            lista.Add("ValidToken");
            LectorTest lector = new LectorTest(diccionario);
            registrarEmpresario.Input = lector;
            registrarEmpresario.SetNext(new NullHandler());
            registrarEmpresario.Handle(mensaje);

            Empresa empresa = Singleton<ListaEmpresa>.Instance.Buscar(1000);
            Assert.AreNotEqual(empresa, null);
        }
        /// <summary>
        /// Este test verifica que no es posible el registro con una invitacion invalida.
        /// </summary>
        [Test]
        public void InvitacionInvalidaTest()
        {
            Dictionary<string, string> diccionario = new Dictionary<string, string>();
            diccionario.Add("Ingrese su código de invitación: ", "InvalidToken");
            ListaEmpresa lista1 = new ListaEmpresa();
            Mensaje mensaje = new Mensaje(1000,"/empresa");
            RegistrarEmpresarioHandler registrarEmpresario = new RegistrarEmpresarioHandler();
            Administrador admin = new Administrador(456, "admin");
            admin.CrearInvitacion("ResgistrarEmpresaTest", "Montevideo", "textil", "ValidToken");
            LectorTest lector = new LectorTest(diccionario);
            registrarEmpresario.Input = lector;
            registrarEmpresario.SetNext(new NullHandler());
            registrarEmpresario.Handle(mensaje);

            Empresa empresa = Singleton<ListaEmpresa>.Instance.Buscar(1000);
            Assert.AreEqual(empresa, null);  
        }
    }
}