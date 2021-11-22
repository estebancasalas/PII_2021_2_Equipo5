// -----------------------------------------------------------------------
// <copyright file="Transaccion.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

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
        private Empresa vendedor;

        /// <summary>
        /// El Comprador es un objeto de tipo Emprendedor 
        /// </summary>
        private Emprendedor comprador;

        /// <summary>
        /// El NombreDelMaterial es el nombre del material que se vendió o se compró.
        /// </summary>
        private string nombreDelMaterial;

        /// <summary>
        /// La cantidad del material que se vendió o se compró.
        /// </summary>
        private double cantidad;

        public Empresa Vendedor { get => vendedor; set => vendedor = value; }
        public Emprendedor Comprador { get => comprador; set => comprador = value; }
        public string NombreDelMaterial { get => nombreDelMaterial; set => nombreDelMaterial = value; }
        public double Cantidad { get => cantidad; set => cantidad = value; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Transaccion"/> class.
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
