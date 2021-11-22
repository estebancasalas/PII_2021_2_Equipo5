// -----------------------------------------------------------------------
// <copyright file="BusquedaZonaCiudad.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library
{
    /// <summary>
    /// Busqueda por zona. Recorre la lista de todas las publicaciones y devuelve una lista con las coincidencias en zona.
    /// Se decide crear esta clase para cumplir SRP ya que, esta se encarga solo de realizar la búsqueda por zona.
    /// Esta clase colabora con BuscarPublicacionHandler y BuscarPublicacion.
    /// </summary>
    public class BusquedaZonaCiudad : AbstractBuscar
    {
        /// <summary>
        /// Busqueda por zona. Recorre la lista de todas las publicaciones y devuelve una lista con las coincidencias.
        /// </summary>
        /// <param name="tipoZona">Tipo de zona en que se desea buscar(Ciudad, Departamento, etc).</param>
        /// <param name="ubicacion">Nombre de la zona.</param>
        /// <returns></returns>
        public List<Publicacion> Buscar(string tipoZona, string ubicacion)
        {
            List<Publicacion> result = new List<Publicacion>();
            List<Publicacion> lista = Singleton<RegistroPublicaciones>.Instance.Activas;
            if (tipoZona.ToLower() == "/ciudad")
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