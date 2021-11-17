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
            StringBuilder Resultado = new StringBuilder ("Tus transacciones son:\n");
            List<Transaccion> transacciones = Singleton<ListaTransacciones>.Instance.Buscar(id);
            
            foreach (Transaccion transaccion in transacciones)
            {
                    Resultado.Append($"{transaccion.Vendedor.Nombre} vendió {transaccion.Cantidad} de {transaccion.NombreDelMaterial} a {transaccion.Comprador.Nombre}\n");
            }
            return Resultado.ToString();
        } 
    }
}