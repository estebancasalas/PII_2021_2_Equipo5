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
    public class CrearInvitacionTests
    {
        Mensaje mensaje;
        InvitarHandler invitar;
        
       
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
            invitar.nombre = "empresa1";
            invitar.rubro = "texil";
            invitar.token = "invitacion1";
            invitar.ubicacion = "mi ksa";
            invitar.Handle(mensaje);
            Assert.That(ListaInvitaciones.Invitaciones.Contains("invitacion1"),Is.True);
            Assert.AreEqual(ListaEmpresa.Empresas.Count, 1);
        }
    }
}