// -----------------------------------------------------------------------
// <copyright file="BusquedaCategoria.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Globalization;

namespace Library
{
    /// <summary>
    /// Clase que busca por categoría. Recorre la lista de todas las publicaciones y devuelve una lista con las coincidencias
    /// de la categoría (si las hay).
    /// Se decide crear esta clase para cumplir SRP ya que solamente se encarga de realizar la búsqueda por categoría.
    /// Esta clase colabora con BuscarPublicacionHandler y BuscarPublicacion.
    /// Clase componente la cual está compuesta con BuscarPublicacion. Las instancias de esta clase existen solo cuando BuscarPublicacion lo delega.
    /// </summary>
    public class BusquedaCategoria
    {
        /// <summary>
        /// Método que toma como parámetro una categoría y recorre la lista de publicaciones buscando coincidencias.
        /// </summary>
        /// <param name="categoria">Categoria del material que el usuario desea buscar.</param>
        /// <returns>Lista de coincidencias.</returns>
        public List<Publicacion> Buscar(string categoria)
        {
            List<Publicacion> result = new List<Publicacion>();
            List<Publicacion> lista = Singleton<RegistroPublicaciones>.Instance.Activas;

            foreach (Publicacion publicacion in lista)
            {
                if (publicacion.Material.Categoria.ToLower(CultureInfo.InvariantCulture)
                    == categoria.ToLower(CultureInfo.InvariantCulture))
                {
                    result.Add(publicacion);
                }
            }

            return result;
        }
    }
}