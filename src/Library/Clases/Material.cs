// -----------------------------------------------------------------------
// <copyright file="Material.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    /// <summary>
    /// Esta clase se encarga del modelado del material.
    /// </summary>
    public class Material : IConversorTexto
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Material"/>.
        /// </summary>
        /// <param name="nombre">El nombre del material.</param>
        /// <param name="costo">El costo del material.</param>
        /// <param name="cantidad">LA cantidad de material.</param>
        /// <param name="unidad">La unidad en la cual se cuantifica el material.</param>
        /// <param name="habilitaciones">Las habliitaciones que se necesitan para el material.</param>
        /// <param name="categoria">La categoría del material.</param>
        public Material(string nombre, double costo, double cantidad, string unidad, string habilitaciones, string categoria)
        {
            this.Nombre = nombre;
            this.Costo = costo;
            this.Cantidad = cantidad;
            this.Unidad = unidad;
            this.Habilitaciones = habilitaciones;
            if (this.PosiblesCategorias.Contains(categoria.ToLower()))
            {
                this.Categoria = categoria;
            }
            else
            {
                Console.WriteLine("Categoría no válida.");
            }
        }

        /// <summary>
        /// Obtiene o establece el nombre de el material.
        /// </summary>
        /// <value>Se guarda el nombre del material.</value>
        public string Nombre { get; set; }

        /// <summary>
        /// Obtiene gets se encarga de guardar el costo del material dentro del objeto material.
        /// </summary>
        /// <value>Se guarda el valor del costo.</value>
        public double Costo { get; }

        /// <summary>
        /// Obtiene gets se encarga de guardar la cantidad que existe del mismo dentro del objeto material.
        /// </summary>
        /// <value>Guarda la cantidad del material.</value>
        public double Cantidad { get; }

        /// <summary>
        /// Obtiene la unidad que se encarga de guardar la unidad en la cual se pesa el material dentro del objeto material.
        /// </summary>
        /// <value>Guarda la unidad de la cantidad del material.</value>
        public string Unidad { get; }

        /// <summary>
        /// Obtiene se encarga de guardar las habliitaciones, que se necesitan para obtener el material, dentro del objeto material.
        /// Link al documento.
        /// </summary>
        /// <value>Guarda las habilitaciones para obtener el material.</value>
        public string Habilitaciones { get; }

        /// <summary>
        /// Obtiene gets se encarga de guardar la categoría del material dentro del objeto material.
        /// </summary>
        /// <value>Guarda la categoria del material.</value>
        public string Categoria { get; }

        /// <summary>
        /// Lista que contiene las categorías del material.
        /// </summary>
        public List<string> PosiblesCategorias = new List<string>() { "/químicos", "/plásticos", "/celulósicos", "/eléctricos", "/textiles", "/metálicos", "/metálicos ferrosos", "/solventes", "/vidrio", "/residuos orgánicos", "/otros" };

        /// <summary>
        /// Método para crear un string con la información del material.
        /// </summary>
        /// <returns>String con la información del material.</returns>
        public string ConvertToString()
        {
            StringBuilder resultado = new StringBuilder();
            resultado.Append($"Nombre: {this.Nombre}\n");
            resultado.Append($"Costo: {this.Costo}\n");
            resultado.Append($"Cantidad: {this.Cantidad}\n");
            resultado.Append($"Unidad: {this.Unidad}\n");
            resultado.Append($"Habilitaciones: {this.Habilitaciones}\n");
            return resultado.ToString();
        }
    }
}
