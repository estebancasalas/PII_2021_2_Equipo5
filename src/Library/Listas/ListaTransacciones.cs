using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Clase que se encarga de conocer todas las transacciones que se realizan 
    /// de una empresa a un emprendedor o viceversa. 
    /// </summary>
    public class HistorialTransacciones
    {
        /// <summary>
        /// Transacciones es quien tiene la lista con los objetos de la clase Transaccion. 
        /// </summary>
        /// <returns></returns>
        public static List <Transaccion> Transacciones = Singleton<List<Transaccion>>.Instance;

        public List<Transaccion> Buscar(int id)
        {
            List<Transaccion> resultado = new List<Transaccion>();
            foreach (Transaccion transaccion in HistorialTransacciones.Transacciones)
            {
                if (transaccion.Vendedor.ListaIdEmpresarios.Contains(id) || transaccion.Comprador.Id == id) 
                {
                    resultado.Add(transaccion);
                }
            }
            return resultado;
        }
    }

}