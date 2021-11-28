// -----------------------------------------------------------------------
// <copyright file="IUbicacionProvider.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Library
{
    /// <summary>
    /// Interfaz que modela las clases que obtienen ubicaciones a partir de direcciones. 
    /// Creada por DIP, las clases que necesiten obtener una ubicacion dependerán de esta abstracción y no de una clase concreta.
    /// </summary>
    public interface IUbicacionProvider
    {
        /// <summary>
        /// Método para obtener la ubicación de tipo IUbicacion a partir de una dirección en string.
        /// </summary>
        /// <param name="ubicacion">Dirección de la que se desea obtener la ubicación.</param>
        /// <returns>Devuelve la ubicación en formato IUbicacion.</returns>
        IUbicacion GetUbicacion(string ubicacion);
    }
}