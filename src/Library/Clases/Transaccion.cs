using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Clase que modela las transacciones entre emprendedores y empresas o viceversa. 
    /// </summary>
    public class Transaccion
    {
        /// <summary>
        /// El vendedor es un objeto del tipo Empresa.
        /// </summary>
        public Empresa Vendedor; 
        /// <summary>
        /// El Comprador es un objeto de tipo Emprendedor 
        /// </summary>
        public Emprendedor Comprador; 
        /// <summary>
        /// El NombreDelMaterial es el nombre del material que se vendió o se compró.
        /// </summary>
        public string NombreDelMaterial;
        /// <summary>
        /// La cantidad del material que se vendió o se compró.
        /// </summary>
        public double Cantidad; 
        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="vendedor">Vendedor, es un objeto de la clase Empresa</param>
        /// <param name="comprador">Comprador, es un objeto de la clase Emprendedor</param>
        /// <param name="nombre">Nombre del material, tipo string</param>
        /// <param name="cantidad">Cantidad del material, tipo double</param>
        public Transaccion(Empresa vendedor, Emprendedor comprador, string nombre, double cantidad)
        {
            this.Vendedor = vendedor;
            this.Comprador = comprador;
            this.NombreDelMaterial = nombre;
            this.Cantidad = cantidad;
        }
    }
}
