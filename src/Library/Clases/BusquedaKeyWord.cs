// -----------------------------------------------------------------------
// <copyright file="BusquedaKeyWord.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Busqueda por palabras clave. Recorre la lista de todas las publicaciones y devuelve una lista con las coincidencias
    /// en palabras clave.
    /// Se decide crear esta clase para cumplir SRP ya que, esta se encarga solo de realizar la búsqueda por Palabras clave.
    /// Esta clase colabora con BuscarPublicacionHandler y BuscarPublicacion.
    /// </summary>
    public class BusquedaKeyWord : AbstractBuscar
    {
        /// <summary>
        /// Busqueda por palabras clave. Recorre la lista de todas las publicaciones y devuelve una lista con las coincidencias.
        /// </summary>
        /// <param name="palabras">Palabra clave que ayuda a la busqueda.</param>
        /// <returns></returns>
        public List<Publicacion> Buscar(string palabras)
        {
            List<Publicacion> result = new List<Publicacion>();
            List<Publicacion> lista = Singleton<RegistroPublicaciones>.Instance.Activas;

            foreach (Publicacion publicacion in lista)
            {
                if (publicacion.PalabrasClave.Contains(palabras))
                {
                    result.Add(publicacion);
                }
            }

            return result;
        }
    }
}