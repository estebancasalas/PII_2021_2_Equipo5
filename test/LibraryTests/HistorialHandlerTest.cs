
// using System;
// using System.Collections.Generic;
// using Library;
// using NUnit.Framework;
// using System.Text;

// namespace LibraryTests
// {
//     /// <summary>
//     /// Casos de prueba para el handler Historial.
//     /// </summary>
//     [TestFixture]
//     public class HistorialHandlerTest
//     {
//         // Dictionary<string, string> comprarDicc = new Dictionary<string, string>();
//         HistorialHandler handler = new HistorialHandler();
//         /// <summary>
//         /// SetUp de los casos de prueba.
//         /// </summary>
//         [SetUp]
//         public void Setup()
//         {
//         }

//         [Test]
//         public void HistorialPorEmprendedorTest()
//         {
//             EstadoUsuario estadoMartin = new EstadoUsuario();
//             Empresario martin = new Empresario(123456, estadoMartin, "Martin Rodriguez");
//             Empresa mrespejos = new Empresa("MRespejos", "Av Italia 3456", "Ventas de espejos", "0990", "23111899");
//             IUbicacion ubiMR = new Ubicacion("Uruguay", "Montevideo", "Av Italia 3456", "11900", "1652566767", "43566277");
//             Material espejosMat = new Material("Espejos", 100, 250, "cajas", "ninguna", "/otros");
//             Publicacion ventaEspejos = new Publicacion("Los mejores espejos", espejosMat, "Espejos", "Semanal", ubiMR , mrespejos);
            
//             Emprendedor pablo = new Emprendedor(654321, "Pablo Perez", "Montevideo", "Zapatero", null, null);

//             ListaTransacciones listaTransacciones = new ListaTransacciones();
//             Transaccion transaccion = new Transaccion(mrespejos, pablo, espejosMat, 23);
//             listaTransacciones.Add(transaccion);
            

           
//             Mensaje mensaje = new Mensaje(654321, "/historial");
//             handler.Handle(mensaje);
//             string expected = "Material: Espejos\nCantidad: 23\nVendedor: MRespejos\nComprador: Pablo Perez\n";
//             Assert.AreEqual(expected, handler.TextResult.ToString()); 
//         }

//         [Test]
//         public void HistorialPorEmpresaTest()
//         {
//             EstadoUsuario estadoPatricio = new EstadoUsuario();
//             Empresario patricio = new Empresario(9911, estadoPatricio, "Patricio Recoba");
//             Empresa palletsPato = new Empresa("PatoPallets", "Av Agraciada 2343", "Ventas de pallets", "1899", "23118754");
//             IUbicacion ubiPP = new Ubicacion("Uruguay", "Montevideo", "Av Agraciada 2343", "11900", "13456767", "4234577");
//             Material palletsDePato = new Material("Pallets", 10, 100, "pallet", "ninguna", "/otros");
//             Publicacion ventaPallets = new Publicacion("Los mejores pallets", palletsDePato, "Pallets", "Diario", ubiPP , palletsPato);
            
//             Emprendedor jose = new Emprendedor(1199, "Jose Podrent", "Montevideo", "Feriante", null, null);

//             ListaTransacciones listaTransacciones = new ListaTransacciones();
//             Transaccion transaccion = new Transaccion(palletsPato, jose, palletsDePato, 58);
//             listaTransacciones.Add(transaccion);
            

//             Mensaje mensaje = new Mensaje(9911, "/historial");
//             handler.Handle(mensaje);
//             string expected = "Material: Pallets\nCantidad: 58\nVendedor: PatoPallets\nComprador: Jose Podrent\n";
//             Assert.AreEqual(expected, handler.TextResult.ToString());
//         }      
        
        
        
        
        
        /// <summary>
        /// En este test verificamos que, cuando la invitación es válida, el id del usuario se añade correctamente a la lista de
        /// ids de la empresa.
        /// </summary>
        // [Test]
        // public void VerHistorialEmprendedorVacioTest()
        // {
        //     Emprendedor emprendedor = new Emprendedor(4321, "Javier", "Mvd", "Constru", "ninguna", "construir");
        //     Mensaje mensaje = new Mensaje(1234, "/historial");
        //     HistorialHandler historial = new HistorialHandler();
        //     IFormatoSalida salida = new OutputTest();
        //     historial.Output = salida;
        //     historial.SetNext(new NullHandler());
        //     historial.Handle(mensaje);
        //     string expected = "Tus transacciones son:\n";
        //     Assert.AreEqual(expected, historial.resultado);
        // }

        /// <summary>
        /// Se testea el metodo mostrar historial cuando el emprendedor tiene compras registradas.
        /// </summary>
        // [Test]
        // public void VerHistorialEmprendedorNoVacioTest()
        // {
        //     Empresa empresa = new Empresa("Adidas", "Montevideo", "zapatos", "1df2frgfrfdvuhwdujn3eji3rf");
        //     Emprendedor emprendedor = new Emprendedor(567, "Colgatte", "Mvd", "Veterinario", "ninguna", "curar");
        //     HistorialHandler historial = new HistorialHandler();
        //     Mensaje mensaje = new Mensaje(567, "/historial");
        //     Transaccion transaccion = new Transaccion(empresa, emprendedor, "Championes de Messi", 1);
        //     ListaTransacciones transacciones = new ListaTransacciones();
        //     List<Transaccion> listaTransacciones = Singleton<ListaTransacciones>.Instance.Transacciones;
        //     listaTransacciones.Add(transaccion);
        //     IFormatoSalida salida = new OutputTest();
        //     historial.Output = salida;
        //     historial.SetNext(new NullHandler());
        //     historial.Handle(mensaje);
        //     string resultado = "Tus transacciones son:\nAdidas vendió 1 de Championes de Messi a Colgatte\n";
        //     Assert.AreEqual(resultado, historial.resultado);
        // }
  //  }
//}
