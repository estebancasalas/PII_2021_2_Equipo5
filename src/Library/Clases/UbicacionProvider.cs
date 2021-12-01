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
    /// Implementa la interfaz IUbicacionProvider para cumplir con el principio DIP.
    /// Depende de IUbicacionProvider y colabora con CrearPublicacionHandler.
    /// </summary>
    public class UbicacionProvider : IUbicacionProvider
    {
        /// <summary>
        /// GetUbicacion es el método que, al pasarle una dirección, la convierte en un objeto de tipo IUbicacion.
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
