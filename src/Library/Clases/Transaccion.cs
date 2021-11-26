// -----------------------------------------------------------------------
// <copyright file="Transaccion.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------
using System.Text;

namespace Library
{
    /// <summary>
    /// Clase que modela las transacciones entre emprendedores y empresas o viceversa.
    /// </summary>
    public class Transaccion : IStringbuilder
    {
        /// <summary>
        /// El vendedor es un objeto del tipo Empresa.
        /// </summary>
        public Empresa vendedor;

        /// <summary>
        /// El Comprador es un objeto de tipo Emprendedor.
        /// </summary>
        public Emprendedor Comprador;

        /// <summary>
        /// El NombreDelMaterial es el nombre del material que se vendió o se compró.
        /// </summary>
        public Material Material;

        /// <summary>
        /// La cantidad del material que se vendió o se compró.
        /// </summary>
        public double Cantidad;

        public Empresa Vendedor { get => vendedor; set => vendedor = value; }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="vendedor">Vendedor, es un objeto de la clase Empresa</param>
        /// <param name="comprador">Comprador, es un objeto de la clase Emprendedor</param>
        /// <param name="nombre">Nombre del material, tipo string</param>
        /// <param name="cantidad">Cantidad del material, tipo double</param>
        public Transaccion(Empresa vendedor, Emprendedor comprador, Material material, double cantidad)
        {
            this.Vendedor = vendedor;
            this.Comprador = comprador;
            this.Material = material;
            this.Cantidad = cantidad;
        }

        public string ConvertToString()
        {
            StringBuilder resultado = new StringBuilder();
            resultado.Append($"Material: {this.Material}\n");
            resultado.Append($"Cantidad: {this.Cantidad}\n");
            resultado.Append($"Vendedor: {this.Vendedor.Nombre}\n");
            resultado.Append($"Comprador: {this.Comprador.Nombre}\n");
            return resultado.ToString();
        }
    }
}
