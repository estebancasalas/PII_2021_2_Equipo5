// -----------------------------------------------------------------------
// <copyright file="Ubicacion.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Library
{
    /// <summary>
    /// Clase que modela una ubicación.
    /// Implementa IUbicacion.
    /// Colabora con: UbicacionProvider,
    /// </summary>
    public class Ubicacion : IUbicacion
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Ubicacion"/> class.
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
        /// Propiedad que almacena el País.
        /// </summary>
        /// <value></value>
        public string Pais { get; set; } = "Uruguay";

        /// <summary>
        /// Propiedad que almacena la Ciudad.
        /// </summary>
        /// <value></value>
        public string Ciudad { get; set; } = "Montevideo";

        /// <summary>
        /// Propiedad que almacena la dirección.
        /// </summary>
        /// <value></value>
        public string Direccion { get; set; } = string.Empty;

        /// <summary>
        /// Propiedad que almacena el código postal.
        /// </summary>
        /// <value></value>
        public string CodigoPostal { get; set; } = string.Empty;

        /// <summary>
        /// Propiedad que almacena la Latitud de las coordenadas.
        /// </summary>
        /// <value></value>
        public string Latitud { get; set; } = string.Empty;

        /// <summary>
        /// Propiedad que almacena la Longitud de las coordenadas.
        /// </summary>
        /// <value></value>
        public string Longitud { get; set; } = string.Empty;
    }
}
