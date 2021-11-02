//--------------------------------------------------------------------------------
// <copyright file="TrainTests.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------


using NUnit.Framework;
using Library;

namespace LibraryTests
{

    [TestFixture]
    public class RegistrarEmpresaTests
    {
        Mensaje mensaje;
        Administrador admin = new Administrador(456, "Esteban");
        CrearEmpresaHandler handler = new CrearEmpresaHandler();
       
        [SetUp]
        public void Setup()
        {
            mensaje.Text = "/CrearUsuario";
            mensaje.Id = 1234;
            admin.CrearInvitacion("Empresa1", "Montevideo", "textil", "9876");

        }


        [Test]
        public void Test()
        {
            
        }
    }
}