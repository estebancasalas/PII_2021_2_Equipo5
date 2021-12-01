// -----------------------------------------------------------------------
// <copyright file="Transaccion.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------
using System.Text;

namespace Library
{
    /// <summary>
    /// Clase que modela las transacciones entre emprendedores y empresas.  Implementa la interfaz IConversorTexto para que dependa de una abstracción cumpliendo con el principio DIP.
    /// </summary>
    public class Transaccion : IConversorTexto
    {
        /// <summary>
        /// El vendedor del material como tipo Empresa.
        /// </summary>
        public Empresa Vendedor;

        /// <summary>
        /// El Comprador del material como tipo Emprendedor.
        /// </summary>
        public Emprendedor Comprador;

        /// <summary>
        /// Es el material que se compró o vendió.
        /// </summary>
        public Material Material;

        /// <summary>
        /// La cantidad del material que se vendió o se compró.
        /// </summary>
        public double Cantidad;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Transaccion"/>.
        /// Constructor de la clase.
        /// </summary>
        /// <param name="vendedor">Empresa que vende el material.</param>
        /// <param name="comprador">Comprador del material.</param>
        /// <param name="material">Material de la transacción.</param>
        /// <param name="cantidad">Cantidad del material, tipo double.</param>
        public Transaccion(Empresa vendedor, Emprendedor comprador, Material material, double cantidad)
        {
            this.Vendedor = vendedor;
            this.Comprador = comprador;
            this.Material = material;
            this.Cantidad = cantidad;
        }

        /// <summary>
        /// Método para crear un string con la información de la transacción.
        /// </summary>
        /// <returns>Devuelve el string con la información de la transacción.</returns>
        public string ConvertToString()
        {
            StringBuilder resultado = new StringBuilder();
            resultado.Append($"Material: {this.Material.Nombre}\n");
            resultado.Append($"Cantidad: {this.Cantidad}\n");
            resultado.Append($"Vendedor: {this.Vendedor.Nombre}\n");
            resultado.Append($"Comprador: {this.Comprador.Nombre}\n");
            return resultado.ToString();
        }
    }
}
