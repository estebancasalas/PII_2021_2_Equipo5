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
    /// Clase que busca por palabras clave. Recorre la lista de todas las publicaciones y devuelve una lista con las coincidencias
    /// en palabras clave.
    /// Se decide crear esta clase para cumplir SRP ya que, esta se encarga solo de realizar la búsqueda por Palabras clave.
    /// Esta clase colabora con BuscarPublicacionHandler y BuscarPublicacion.
    /// Clase componente la cual está compuesta con BuscarPublicacion. Las instancias de esta clase existen solo cuando BuscarPublicacion lo delega.
    /// </summary>
    public class BusquedaKeyWord
    {
        /// <summary>
        /// Método que busca por palabras clave. Recorre la lista de todas las publicaciones y devuelve una lista con las coincidencias.
        /// </summary>
        /// <param name="palabras">Palabras claves que ingresa el usuario para buscar su futura publicación.</param>
        /// <returns>Devuelve la lista de publicaciones que coinciden con las palabras claves que ingreso el usuario.</returns>
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