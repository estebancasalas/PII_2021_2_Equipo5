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
        RegistrarEmpresarioHandler registrarEmpresario;
       
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
            ListaEmpresa lista1 = new ListaEmpresa();
            Mensaje mensaje = new Mensaje(1234,"/empresa");
            RegistrarEmpresarioHandler registrarEmpresario = new RegistrarEmpresarioHandler();
            Administrador admin = new Administrador(456, "Esteban");
            admin.CrearInvitacion("Empresa1", "Montevideo", "textil", "InviteEmpresa1");
            registrarEmpresario.Handle(mensaje);
            Assert.That(ListaEmpresa.Empresas[0].ListaIdEmpresarios.Contains(1234));
        }
    }
}