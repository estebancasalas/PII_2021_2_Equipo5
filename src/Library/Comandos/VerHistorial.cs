using System;
using System.Text;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Clase que permite al usuario(emprendedor, empresa) ver su historial de compra o venta. 
    /// </summary>
    public class VerHistorial 
    {
        
        /// <summary>
        /// Método que recorre la lista de transacciones de el usuario y retorna su historial.
        /// </summary>
        /// <param name="nombre">Nombre de quien quiere ver el historial</param>
        /// <returns></returns>
        public string EjecutarComando(int id)
        {  
<<<<<<< HEAD
            StringBuilder Resultado = new StringBuilder ("Tus transacciones son: \n ");
            List<Transaccion> lista = Singleton<HistorialTransacciones>.Instance.Transacciones;
            foreach (Transaccion transaccion in lista)
=======
            StringBuilder Resultado = new StringBuilder ("Tus transacciones son: \n");
            HistorialTransacciones historial = new HistorialTransacciones();
            
            foreach (Transaccion transaccion in historial.Buscar(id))
>>>>>>> 3b0ae8df6d682f92e30ab63ade51e2c9c0b52c06
            {
                    Resultado.Append($"{transaccion.Vendedor.Nombre} vendió {transaccion.Cantidad} de {transaccion.NombreDelMaterial} a {transaccion.Comprador.Nombre}\n");
            }
            return Resultado.ToString();
        } 
    }
}