using NUnit.Framework;
using Library;
using System.Collections.Generic;
using Ucu.Poo.Locations.Client;

namespace LibraryTests
{

    [TestFixture]
    public class BuscarPublicacionTest
    {
        Mensaje mensaje;
        InvitarHandler invitar;
        Publicacion a; 
        Publicacion b; 
        Publicacion c; 
       
        [SetUp]
        public void Setup()
        {
            Material madera = new Material("PMadera",1,2,"Cantidad","Habilitación1","Químicos");
            Material dos = new Material("Material2",3,4,"Cantidad","Habilitación1","Plásticos");
            Material tres = new Material("Material3",5,6,"Cantidad","Habilitación1","Eléctricos");

            IUbicacion alfa = new Ubicacion("Uruguay", "Montevideo", null, null, null, null);
            IUbicacion beta = new Ubicacion("Uruguay", "Salto", null, null, null, null);
            IUbicacion gamma = new Ubicacion("Uruguay", "Tacuarembo", null, null, null, null);

            Empresa empresa1 = new Empresa("Empresa1", "UbicacionEmpresa1", "maderero", "123");
            Empresa empresa2 = new Empresa("Empresa2", "UbicacionEmpresa2", "plastico", "1232");
            Empresa empresa3 = new Empresa("Empresa3", "UbicacionEmpresa3", "electrica", "1233");
            
            a = new Publicacion("1", madera, "madera", "todos los dias", alfa, empresa1);
            b = new Publicacion("2", dos, "plastico", "todos los dias", beta, empresa2);
            c = new Publicacion("3", tres, "electrico", "todos los dias", beta, empresa3);
            

        }

        /// <summary>
        /// En este test verificamos que, cuando la invitación es válida, el id del usuario se añade correctamente a la lista de 
        /// ids de la empresa.
        /// </summary>
        [Test]
        public void BusquedaCategoriaTest()
        {
            
            Dictionary<string, string> diccionario = new Dictionary<string, string>();
            diccionario.Add("Que tipo de busqueda desea realizar? /categoria, /ciudad, /palabrasclave" , "/categoria");
            diccionario.Add("Que desea buscar?", "Químicos");
            Mensaje mensaje = new Mensaje(1234,"/buscarpublicacion");
            BuscarPublicacionHandler buscarCategoria = new BuscarPublicacionHandler();
            EntaradaDeLaCadena Lector = new LectorTest(diccionario);
            buscarCategoria.Input = Lector;
            buscarCategoria.SetNext(new NullHandler());
            buscarCategoria.Handle(mensaje);
            Assert.AreEqual(buscarCategoria.result.Contains(a), true); 
        }

        [Test]
        public void BusquedaPorCiudadTest()
        {
            Dictionary<string, string> diccionario = new Dictionary<string, string>();
            diccionario.Add("Que tipo de busqueda desea realizar? /categoria, /ciudad, /palabrasclave" , "/ciudad");
            diccionario.Add("Que desea buscar?", "Salto");
            Mensaje mensaje = new Mensaje(1234,"/buscarpublicacion");
            BuscarPublicacionHandler buscarCiudad = new BuscarPublicacionHandler();
            EntaradaDeLaCadena Lector = new LectorTest(diccionario);
            buscarCiudad.Input = Lector;
            buscarCiudad.SetNext(new NullHandler());
            buscarCiudad.Handle(mensaje);
            Assert.AreEqual(buscarCiudad.result.Contains(b), true); 
        }

        [Test]
        public void BusquedaPorPalabrasClaveTest()
        {
            Dictionary<string, string> diccionario = new Dictionary<string, string>();
            diccionario.Add("Que tipo de busqueda desea realizar? /categoria, /ciudad, /palabrasclave" , "/palabrasclave");
            diccionario.Add("Que desea buscar?", "electrico");
            Mensaje mensaje = new Mensaje(1234,"/buscarpublicacion");
            BuscarPublicacionHandler buscarPalabra = new BuscarPublicacionHandler();
            EntaradaDeLaCadena Lector = new LectorTest(diccionario);
            buscarPalabra.SetNext(new NullHandler());
            buscarPalabra.Input = Lector;
            buscarPalabra.Handle(mensaje);
            Assert.AreEqual(buscarPalabra.result.Contains(c), true); 
        }
    }
}
