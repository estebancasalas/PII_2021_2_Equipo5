// -----------------------------------------------------------------------
// <copyright file="Publicacion.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System.Text;

namespace Library
{
    /// <summary>
    /// Clase que modela una publicación. Cumple con el principio DIP ya que depende de una abstracción IConversorTexto.
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
        /// Obtiene o establece nombre de quien realiza la publicación.
        /// </summary>
        /// <value>Vendedor de la publicación.</value>
        public Empresa Vendedor { get; set; }

        /// <summary>
        /// Obtiene o establece el título de la publicación.
        /// </summary>
        /// <value>Título</value>
        public string Titulo { get; set; }

        /// <summary>
        /// Obtiene o establece el material de la publicación.
        /// </summary>
        /// <value>Material.</value>
        public Material Material { get; set; }

        /// <summary>
        /// Obtiene o establece las palabras claves para buscar una publicación.
        /// </summary>
        /// <value>Palabras claves.</value>
        public string PalabrasClave { get; set; }

        /// <summary>
        /// Obtiene o establece cada cuánto tiempo se genera el material.
        /// </summary>
        /// <value>Frecuencia de disponibilidad del material.</value>
        public string FrecuenciaDeDisponibilidad { get; set; }

        /// <summary>
        /// Obtiene o establece la ubicación del material.
        /// </summary>
        /// <value>Ubicación del material.</value>
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
            resultado.Append($"Ubicación: {this.Ubicacion.Direccion}, {this.Ubicacion.Ciudad}, {this.Ubicacion.Pais}\n");
            resultado.Append($"Vendedor: {this.Vendedor.Nombre}\n");
            return resultado.ToString();
        }
    }
}