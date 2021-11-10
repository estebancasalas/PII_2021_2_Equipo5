using NUnit.Framework;
using Library;
using System.Collections.Generic;
using LocationApi;

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
            Location alfa = new Location();
            Location beta = new Location();
            Location gamma = new Location();
            alfa.Locality = "Montevideo";
            beta.Locality = "Salto";
            gamma.Locality = "Tacuarembó";
            a = new Publicacion("A",madera,"PMadera","Frecuencia1",alfa,"SRDL1");
            b = new Publicacion("B",dos,"Material2","Frecuencia2",beta,"SRDL2");
            c = new Publicacion("C",tres,"Material3","Frecuencia3",gamma,"SRDL3");    
        }

        /// <summary>
        /// En este test verificamos que, cuando la invitación es válida, el id del usuario se añade correctamente a la lista de 
        /// ids de la empresa.
        /// </summary>
        [Test]
        public void BusquedaCategoriaTest()
        {
            
            Dictionary<string, string> diccionario = new Dictionary<string, string>();
            diccionario.Add("Que tipo de busqueda desea realizar? /categoria, /ciudad, /departamento, /palabrasclave" , "/categoria");
            diccionario.Add("Que desea buscar?", "Químicos");
            Mensaje mensaje = new Mensaje(1234,"/buscarpublicacion");
            BuscarPublicacionHandler buscarcategoria = new BuscarPublicacionHandler();
            EntaradaDeLaCadena Lector = new LectorTest(diccionario);
            buscarcategoria.Input = Lector;
            buscarcategoria.Handle(mensaje);
            Assert.AreEqual(buscarcategoria.result.Contains(a), true); 
        }

        [Test]
        public void BusquedaPorDepartamentoTest()
        {
            Dictionary<string, string> diccionario = new Dictionary<string, string>();
            diccionario.Add("Que tipo de busqueda desea realizar? /categoria, /ciudad, /departamento, /palabrasclave" , "/departamento");
            diccionario.Add("Que desea buscar?", "Salto");
            Mensaje mensaje = new Mensaje(1234,"/buscarpublicacion");
            BuscarPublicacionHandler buscardepartamento = new BuscarPublicacionHandler();
            EntaradaDeLaCadena Lector = new LectorTest(diccionario);
            buscardepartamento.Input = Lector;
            buscardepartamento.Handle(mensaje);
            Assert.AreEqual(buscardepartamento.result.Contains(b), true); 
        }
    }
}
