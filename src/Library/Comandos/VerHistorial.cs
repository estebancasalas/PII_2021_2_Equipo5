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
        public string EjecutarComando(string nombre)
        {  
            StringBuilder Resultado = new StringBuilder ("Tus transacciones son: \n ");
            foreach (Transaccion transaccion in HistorialTransacciones.Transacciones)
            {
                if (transaccion.Vendedor.Nombre == nombre || transaccion.Comprador.Nombre == nombre) 
                {
                    Resultado.Append($" {transaccion.Vendedor} vendió {transaccion.Cantidad} de {transaccion.NombreDelMaterial} a {transaccion.Comprador}\n");
                }
            }
            return Resultado.ToString();
        } 
    }
}