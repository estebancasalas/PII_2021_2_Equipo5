using NUnit.Framework;
using Library;

namespace LibraryTests
{

    [TestFixture]
    public class CrearPublicacionTest   // publicacion tendria que tener nombre de la empresa. verificar que quien publica es empresa.
    {
        Mensaje mensaje;
        
       
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

        }
    }
}