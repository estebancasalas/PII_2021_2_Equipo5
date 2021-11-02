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
    }
}
