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
        /// <summary>
        /// En este test verificamos que, cuando la invitación es válida, el id del usuario se añade correctamente a la lista de 
        /// ids de la empresa.
        /// </summary>
        [Test]
        public void VerHistorialEmprendedorVacioTest()
        {
            Emprendedor emprendedor = new Emprendedor(4321, "Javier", "Mvd", "Constru", "ninguna", "construir");
            Mensaje mensaje = new Mensaje(1234,"/historial");
            HistorialHandler historial= new HistorialHandler();
            IFormatoSalida salida = new OutputTest();
            historial.Output = salida;
            historial.Handle(mensaje);
            string expected = "Tus transacciones son: \n";
            Assert.AreEqual(expected, historial.resultado);
        }

        /// <summary>
        /// Se testea el metodo mostrar historial cuando el emprendedor tiene compras registradas.
        /// </summary>
        [Test]
        public void VerHistorialEmprendedorNoVacioTest()
        {
            Empresa empresa = new Empresa("Adidas", "Montevideo", "zapatos", "1df2frgfrfdvuhwdujn3eji3rf");
            Emprendedor emprendedor = new Emprendedor(567, "Colgatte", "Mvd", "Veterinario", "ninguna", "curar");
            HistorialHandler historial = new HistorialHandler();
            Mensaje mensaje = new Mensaje(567,"/historial");
            Transaccion transaccion = new Transaccion(empresa, emprendedor, "Championes de Messi", 1);
            HistorialTransacciones transacciones = new HistorialTransacciones();
            List <Transaccion> listaTransacciones = Singleton<HistorialTransacciones>.Instance.Transacciones;
            listaTransacciones.Add(transaccion);
            IFormatoSalida salida = new OutputTest();
            historial.Output = salida;
            historial.Handle(mensaje);
            string resultado = "Tus transacciones son: \nAdidas vendió 1 de Championes de Messi a Colgatte\n";
            Assert.AreEqual(resultado, historial.resultado);
        } 
    }
}