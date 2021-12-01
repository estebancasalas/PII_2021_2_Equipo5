// -----------------------------------------------------------------------
// <copyright file="BusquedaZonaCiudad.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace Library
{
    /// <summary>
    /// Clase que busca por zona. Recorre la lista de todas las publicaciones y devuelve una lista con las coincidencias de la zona ingresada.
    /// Se decide crear esta clase para cumplir SRP ya que se encarga solamente de realizar la búsqueda por zona.
    /// Esta clase colabora con BuscarPublicacionHandler y BuscarPublicacion.
    /// Clase componente la cual está compuesta con BuscarPublicacion. Las instancias de esta clase existen solo cuando BuscarPublicacion lo delega.
    /// </summary>
    /// </summary>
    public class BusquedaZonaCiudad
    {
        /// <summary>
        /// Busqueda por zona. Recorre la lista de todas las publicaciones y devuelve una lista con las coincidencias de zona.
        /// </summary>
        /// <param name="tipoZona">Tipo de zona en que se desea buscar(Ciudad, Departamento, etc) el usuario.</param>
        /// <param name="ubicacion">Nombre de la zona.</param>
        /// <returns>Devuelve la lista con publicaciones que coinciden con la búsqueda.</returns>
        public List<Publicacion> Buscar(string tipoZona, string ubicacion)
        {
            List<Publicacion> result = new List<Publicacion>();
            List<Publicacion> lista = Singleton<RegistroPublicaciones>.Instance.Activas;
            if (tipoZona.ToLower(CultureInfo.InvariantCulture) == "/ciudad")
            {
                foreach (Publicacion publicacion in lista)
                {
                    if (publicacion.Ubicacion.Ciudad == ubicacion)
                    {
                        result.Add(publicacion);
                    }
                }
            }

            return result;
        }
    }
}