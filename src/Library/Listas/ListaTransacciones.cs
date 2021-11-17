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
        public List <Transaccion> Transacciones = Singleton<List<Transaccion>>.Instance;
        public void Add(Transaccion transaccion)
        {
            this.Transacciones.Add(transaccion);
        }
    }
}