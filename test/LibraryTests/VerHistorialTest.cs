using NUnit.Framework;
using Library;

namespace LibraryTests
{

    [TestFixture]
    public class VerHistorialTest
    {
        Mensaje mensaje;
       
        [SetUp]
        public void Setup()
        {
            //Publicacion publicacion1 = new

        }

        /// <summary>
        /// En este test verificamos que, cuando la invitación es válida, el id del usuario se añade correctamente a la lista de 
        /// ids de la empresa.
        /// </summary>
        [Test]
        public void InvitacionValidaTest()
        {
            ListaEmpresa lista1 = new ListaEmpresa();
            Mensaje mensaje = new Mensaje(1234,"/empresa");
            RegistrarEmpresarioHandler registrarEmpresario = new RegistrarEmpresarioHandler();
            Administrador admin = new Administrador(456, "admin");
            admin.CrearInvitacion("Empresa1", "Montevideo", "textil", "ValidToken");
            registrarEmpresario.token = "ValidToken";
            registrarEmpresario.Handle(mensaje);
            Assert.That(ListaEmpresa.Empresas[0].ListaIdEmpresarios.Contains(1234),Is.True);
        }
        [Test]
        public void InvitacionInvalidaTest()
        {
            ListaEmpresa lista1 = new ListaEmpresa();
            Mensaje mensaje = new Mensaje(1234,"/empresa");
            RegistrarEmpresarioHandler registrarEmpresario = new RegistrarEmpresarioHandler();
            Administrador admin = new Administrador(456, "admin");
            admin.CrearInvitacion("Empresa1", "Montevideo", "textil", "ValidToken");
            registrarEmpresario.token = "InvalidToken";
            registrarEmpresario.Handle(mensaje);
            Assert.That(ListaEmpresa.Empresas[0].ListaIdEmpresarios.Contains(1234),Is.False);   
        }
    }
}