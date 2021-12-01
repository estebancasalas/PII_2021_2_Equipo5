// -----------------------------------------------------------------------
// <copyright file="Ubicacion.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Library
{
    /// <summary>
    /// Clase que modela una ubicación.
    /// Implementa IUbicacion para cumplir con el principio DIP.
    /// Colabora con: UbicacionProvider.
    /// </summary>
    public class Ubicacion : IUbicacion
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Ubicacion"/>.
        /// Constructor de la clase.
        /// </summary>
        /// <param name="pais">País donde se ubica.</param>
        /// <param name="ciudad">Ciudad donde se ubica.</param>
        /// <param name="direccion">Dirección donde se ubica.</param>
        /// <param name="codigoPostal">Código postal de donde se ubica.</param>
        /// <param name="latitud">Latitud de la ubicación.</param>
        /// <param name="longitud">Longitud de la ubicación.</param>
        public Ubicacion(string pais, string ciudad, string direccion, string codigoPostal, string latitud, string longitud)
        {
            this.Pais = pais;
            this.Ciudad = ciudad;
            this.Direccion = direccion;
            this.CodigoPostal = codigoPostal;
            this.Latitud = latitud;
            this.Longitud = longitud;
        }

        /// <summary>
        /// Obtiene o establece el País.
        /// </summary>
        /// <value>País en donde se encuentra la ubicación.</value>
        public string Pais { get; set; } = "Uruguay";

        /// <summary>
        /// Obtiene o establece la Ciudad.
        /// </summary>
        /// <value>Ciudad en donde se encuentra la ubicación.</value>
        public string Ciudad { get; set; } = "Montevideo";

        /// <summary>
        /// Obtiene o establece la dirección.
        /// </summary>
        /// <value>Dirección en donde se encuentra la ubicación.</value>
        public string Direccion { get; set; } = string.Empty;

        /// <summary>
        /// Obtiene o establece el código postal.
        /// </summary>
        /// <value>Código postal donde se encuentra la ubicación.</value>
        public string CodigoPostal { get; set; } = string.Empty;

        /// <summary>
        /// Obtiene o establece la Latitud de las coordenadas.
        /// </summary>
        /// <value>Latitud de coordenadas donde se encuentra la ubicación.</value>
        public string Latitud { get; set; } = string.Empty;

        /// <summary>
        /// Obtiene o establece la Longitud de las coordenadas.
        /// </summary>
        /// <value>Longitud de coordenadas donde se encuentra la ubicación.</value>
        public string Longitud { get; set; } = string.Empty;
    }
}
