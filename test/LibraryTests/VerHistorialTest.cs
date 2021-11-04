using NUnit.Framework;
using Library;
using System.Collections.Generic;
using System;

namespace LibraryTests
{

    [TestFixture]
    public class VerHistorialTest
    {
        Mensaje mensaje;
        HistorialTransacciones transacciones = new HistorialTransacciones();

        HistorialHandler historial = new HistorialHandler();
        Dictionary<string, string> diccionario = new Dictionary<string, string>();
        Dictionary<string, string> diccionario2 = new Dictionary<string, string>();
        CrearPublicacionHandler publi = new CrearPublicacionHandler();
        ComprarHandler comprar = new ComprarHandler();
        // Dictionary<string, string> comprarDicc = new Dictionary<string, string>(); 

        

        
       
        [SetUp]
        public void Setup()
        {

        }

        /// <summary>
        /// En este test verificamos que, cuando la invitación es válida, el id del usuario se añade correctamente a la lista de 
        /// ids de la empresa.
        /// </summary>
        [Test]
        public void VerHistorialEmprendedorVacioTest()
        {
            Emprendedor emprendedor = new Emprendedor(1234, "Javier", "Mvd", "Constru", "ninguna", "construir");
            Mensaje mensaje = new Mensaje(1234,"/historial");
            HistorialHandler historial= new HistorialHandler();
            diccionario2.Add("¿Cuál es tu nombre?" , "Javier");
            EntaradaDeLaCadena entrada = new LectorTest(diccionario);
            historial.Input = entrada;
            historial.Handle(mensaje);
            string expected = "Tus transacciones son: \n";
            Assert.AreEqual(expected, historial.resultado);
        }

        [Test]
        public void VerHistorialEmprendedorNoVacioTest()
        {
            Empresa empresa = new Empresa("Abbidas", "Montevideo", "zapatos", "1df2frgfrfdvuhwdujn3eji3rf");
            Emprendedor emprendedor = new Emprendedor(567, "Colgatte", "Mvd", "Veterinario", "ninguna", "curar");
            HistorialHandler historial = new HistorialHandler();
            Mensaje mensaje = new Mensaje(567,"/historial");
            Transaccion transaccion = new Transaccion(empresa, emprendedor, "Championes de Messi", 1);
            HistorialTransacciones.Transacciones.Add(transaccion);
            diccionario.Add("¿Cuál es tu nombre?" , "Colgatte");
            EntaradaDeLaCadena entrada3 = new LectorTest(diccionario);
            historial.Input = entrada3;
            historial.Handle(mensaje);
            Assert.That(HistorialTransacciones.Transacciones.Count == 1, Is.True);
            

        } 
        
        

        // [Test]
        // public void VerHistorialEmpresaNoVacioTest()
        // {
        //     Emprendedor emprendedor = new Emprendedor(567, "Pablo", "Mvd", "Veterinario", "ninguna", "curar");
        //     Mensaje mensaje = new Mensaje(567,"/comprar");
        //     comprarDicc.Add("Ingrese nombre de la publicación: " , "MADERA!!!");
        //     comprarDicc.Add("Ingrese cantidad que desea comrpar: " , "20");
        //     Assert.That(HistorialTransacciones.Transacciones.Count == 1, Is.True);
        // }
        
        // [Test]
        // public void VerHistorialEmpresaVacioTest()
        // {
        //     Dictionary<string, string> empresaNVDicc = new Dictionary<string, string>(); 
            
        //     Empresa empresa = new Empresa("Colgatte", "Montevideo", "pasta dental", "12rfdvuhwdujn3eji3rf");
        //     Mensaje mensaje = new Mensaje(1234,"/historial");
        //     HistorialHandler historial= new HistorialHandler();
        //     empresaNVDicc.Add("¿Cuál es tu nombre?" , "Colgatte");
        //     EntaradaDeLaCadena entrada3 = new LectorTest(empresaNVDicc);
        //     historial.Input = entrada3;
        //     historial.Handle(mensaje);
        //     Assert.That(HistorialTransacciones.Transacciones.Count == 0, Is.True);
        // }

    }
}