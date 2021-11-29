// -----------------------------------------------------------------------
// <copyright file="IStringbuilder.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace Library
{
    /// <summary>
    /// Interfaz para las clases que necesitan mostrar información. Fue creada para cumplir con
    /// DIP, para que las clases que implementan esta interfaz dependan de una abstracción y no
    /// de una clase concreta.
    /// </summary>
    public interface IConversorTexto
    {
        /// <summary>
        /// Firma del método que convierte a strings.
        /// </summary>
        /// <returns>string convetida.</returns>
        public string ConvertToString();
    }
}