// -----------------------------------------------------------------------
// <copyright file="VerHistorial.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

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
        /// <param name="id">Nombre de quien quiere ver el historial.</param>
        /// <returns></returns>
        public string EjecutarComando(long id)
        {
            StringBuilder resultado = new StringBuilder("Tus transacciones son:\n");
            List<Transaccion> transacciones = Singleton<ListaTransacciones>.Instance.Buscar(id);

            foreach (Transaccion transaccion in transacciones)
            {
                resultado.Append($"{transaccion.Vendedor.Nombre} vendió {transaccion.Cantidad} de {transaccion.Material} a {transaccion.Comprador.Nombre}\n");
            }

            return resultado.ToString();
        }
    }
}
