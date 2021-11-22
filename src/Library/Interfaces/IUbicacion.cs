// -----------------------------------------------------------------------
// <copyright file="IUbicacion.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Library
{
    // Esta bien asi el comentario?

    /// <summary>
    /// Interfaz que modela una ubicación.
    /// Creada por DIP. Las clases que necesitan trabajar con una o varias ubicaciones ahora dependen de esta abstracción y no de una clase concreta(como podría ser la clase Location
    /// en LocationApi).
    /// </summary>
    public interface IUbicacion
    {
        /// <summary>
        /// Gets or sets pais en el que se encuentra la ubicación.
        /// </summary>
        /// <value>guarda el pais en donde se encuentra.</value>
        string Pais { get; set; }

        /// <summary>
        /// Gets or sets ciudad en la que se encuentra la ubicación.
        /// </summary>
        /// <value>Guarda la ciudad en la que se encuentra.</value>
        string Ciudad { get; set; }

        /// <summary>
        /// Gets or sets direccion de la ubicación.
        /// </summary>
        /// <value>Guarda la ubicacion en donde se encuentra.</value>
        string Direccion { get; set; }

        /// <summary>
        /// Gets or sets codigo postal de la ubicación.
        /// </summary>
        /// <value>Guarda el codigo postal de su ubicacion.</value>
        string CodigoPostal { get; set; }

        /// <summary>
        /// Gets or sets latitud de las coordenadas de la ubicación.
        /// </summary>
        /// <value>Guarda la latitud de la ubicación.</value>
        string Latitud { get; set; }

        /// <summary>
        /// Gets or sets longitud de las coordenadas de la ubicación.
        /// </summary>
        /// <value>Guarda la longitud de las coordenadas de la ubicacion en donde se encuentra.</value>
        string Longitud { get; set; }
    }
}