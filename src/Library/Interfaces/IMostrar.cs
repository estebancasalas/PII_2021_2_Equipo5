// -----------------------------------------------------------------------
// <copyright file="IMostrar.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Interfaz creada para cumplir con el patrón DIP. Permite que las clases dependan de abstracciones
    /// en vez de clases concretas.
    /// </summary>
    public interface IMostrar
    {
        /// <summary>
        /// Método para mostrar una lista. Depende de la clase que implemente la interfaz.
        /// </summary>
        /// <param name="lista">Lista para mostrar en pantalla.</param>
        void Mostrar(List<IStringbuilder> lista);
    }
}