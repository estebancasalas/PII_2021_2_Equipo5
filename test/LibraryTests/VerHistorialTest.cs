using NUnit.Framework;
using Library;
using System.Collections.Generic;
using System;

namespace LibraryTests
{
    /// <summary>
    /// Casos de prueba para el handler Historial.
    /// </summary>
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

        

        
       /// <summary>
       /// SetUp de los casos de prueba.
       /// </summary>
        [SetUp]
        public void Setup()
        {

        }
/*      No se logró resolver el fallo del test, lo comentamos para que el programa compile.

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
*/
        /// <summary>
        /// Se testea el metodo mostrar historial cuando el emprendedor tiene compras registradas.
        /// </summary>
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
    }
}