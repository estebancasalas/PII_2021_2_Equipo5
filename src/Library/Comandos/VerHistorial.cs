using System;
using System.Text;
using System.Collections.Generic;

namespace Library
{
    public class VerHistorial 
    {
        public string EjecutarComando(string nombre)
        {  
            StringBuilder Resultado = new StringBuilder ("Tus transacciones son: \n ");
            
            foreach (Transaccion transaccion in HistorialTransacciones.Transacciones)
            {
                if (transaccion.Vendedor== nombre || transaccion.Comprador == nombre) 
                {
                    Resultado.Append($" {transaccion.Vendedor} vendió {transaccion.Cantidad} de {transaccion.Material} a {transaccion.Comprador}\n");
                }
                
            }
            return Resultado.ToString();
            

        } 
        // Esperar clase transaccion

        

        

    }
}