// -----------------------------------------------------------------------
// <copyright file="Publicacion.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System.Text;

namespace Library
{
    /// <summary>
    /// Clase que modela un usario del tipo publicación.
    /// </summary>
    public class Publicacion : IConversorTexto
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Publicacion"/>.
        /// Constructor de la clase Publicacion.
        /// </summary>
        /// <param name="titulo">Título de la publicación.</param>
        /// <param name="material">Material que se va a publicar.</param>
        /// <param name="palabrasClave">Palabras clave para buscar la publicación.</param>
        /// <param name="frecuenciaDeDisponibilidad">Frecuencia de disponibilidad del material.</param>
        /// <param name="ubicacion">Ubicación del vendedor.</param>
        /// <param name="empresa">Nombre de quien vende el material.</param>
        public Publicacion(string titulo, Material material, string palabrasClave, string frecuenciaDeDisponibilidad, IUbicacion ubicacion, Empresa empresa)
        {
            this.Titulo = titulo;
            this.Material = material;
            this.PalabrasClave = palabrasClave;
            this.FrecuenciaDeDisponibilidad = frecuenciaDeDisponibilidad;
            this.Ubicacion = ubicacion;
            this.Vendedor = empresa;
            Singleton<RegistroPublicaciones>.Instance.Add(this);
        }

        /// <summary>
        /// Gets or sets nombre de quien hace la publicación.
        /// </summary>
        public Empresa Vendedor { get; set; }

        /// <summary>
        /// Se encarga de guardar el título de la publicación dentro del objeto publicación.
        /// </summary>
        /// <value></value>
        public string Titulo { get; set; }

        /// <summary>
        /// Se encarga de guardar el material de la publicación dentro del objeto publicación.
        /// </summary>
        /// <value></value>
        public Material Material { get; set; }

        /// <summary>
        /// Se encarga de guardar las palabras claves para lograr una búsqueda efectiva dentro del objeto publicación.
        /// </summary>
        public string PalabrasClave { get; set; }

        /// <summary>
        /// Permite conocer cada cuánto tiempo se genera el mismo y los guarda en el objeto material.
        /// </summary>
        /// <value></value>
        public string FrecuenciaDeDisponibilidad { get; set; }

        // Atributo en dónde se guarda la ubicación del material.
        public IUbicacion Ubicacion { get; set; }

        /// <summary>
        /// Método para crear un string con la información de la publicación.
        /// </summary>
        /// <returns>String con la información de la publicación.</returns>
        public string ConvertToString()
        {
            StringBuilder resultado = new StringBuilder();
            resultado.Append($"Título: {this.Titulo}\n");
            resultado.Append($"Material: {this.Material.ConvertToString()}\n");
            resultado.Append($"Palabras clave: {this.PalabrasClave}\n");
            resultado.Append($"Frecuencia de disponibilidad: {this.FrecuenciaDeDisponibilidad}\n");
            resultado.Append($"Ubicación: {this.Ubicacion.Ciudad}\n");
            resultado.Append($"Ubicación: {this.Ubicacion.Direccion}\n");
            resultado.Append($"Vendedor: {this.Vendedor.Nombre}\n");
            return resultado.ToString();
        }
    }
}