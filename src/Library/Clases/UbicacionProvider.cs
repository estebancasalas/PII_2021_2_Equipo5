// -----------------------------------------------------------------------
// <copyright file="UbicacionProvider.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using Ucu.Poo.Locations.Client;

namespace Library
{
    /// <summary>
    /// Esta clase se encarga de generar una ubicación utilizando la API Location. 
    /// Implementa la interfaz IUbicacionProvider por DIP(Explicado en IUbicacionProvider).
    /// Depende de IUbicacion y colabora con CrearPublicacionHandler
    /// </summary>
    public class UbicacionProvider : IUbicacionProvider
    {
        /// <summary>
        /// GetUbicacion es el método que al pasarle una udirección la convierte en un objeto de tipo IUbicacion.
        /// </summary>
        /// <param name="ubicacion">Es la dirección que pasa el cliente.</param>
        /// <returns>Retorna la ubicación.</returns>
        public IUbicacion GetUbicacion(string ubicacion)
        {
            LocationApiClient client = new LocationApiClient();
            Location location = client.GetLocation(ubicacion);
            IUbicacion ubi = new Ubicacion(location.CountryRegion, location.Locality, location.AddresLine, location.PostalCode, location.Latitude.ToString(), location.Longitude.ToString());
            return ubi;
        }
    }
}
