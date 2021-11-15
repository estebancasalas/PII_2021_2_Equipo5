using NUnit.Framework;
using Library;
using System.Collections.Generic;

namespace LibraryTests
{
    /// <summary>
    /// Casos de prueba para el handler RegistrarEmpresario.
    /// </summary>
    [TestFixture]
    public class RegistrarEmpresaTests
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

            Mensaje mensaje = new Mensaje(1234,"/empresa");
            RegistrarEmpresarioHandler registrarEmpresario = new RegistrarEmpresarioHandler();
            Empresa empresa1 = new Empresa("ResgistrarEmpresaTest", "Montevideo", "textil", "ValidToken");
            ListaInvitaciones.Invitaciones.Add("ValidToken");
            LectorTest lector = new LectorTest(diccionario);
            registrarEmpresario.Input = lector;
            registrarEmpresario.Handle(mensaje);

            BuscarEmpresa buscarempresa = new BuscarEmpresa();
            Empresa empresa = buscarempresa.Buscar("ResgistrarEmpresaTest");
            Assert.That(empresa.ListaIdEmpresarios.Contains(1234), Is.True);
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
            Mensaje mensaje = new Mensaje(1234,"/empresa");
            RegistrarEmpresarioHandler registrarEmpresario = new RegistrarEmpresarioHandler();
            Administrador admin = new Administrador(456, "admin");
            admin.CrearInvitacion("ResgistrarEmpresaTest", "Montevideo", "textil", "ValidToken");
            LectorTest lector = new LectorTest(diccionario);
            registrarEmpresario.Handle(mensaje);

            BuscarEmpresa buscarempresa = new BuscarEmpresa();
            Empresa empresa = buscarempresa.Buscar("ResgistrarEmpresaTest");
            Assert.That(empresa.ListaIdEmpresarios.Contains(1234),Is.False);   
        }
    }
}