// -----------------------------------------------------------------------
// <copyright file="IMostrar.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    /// <summary>
    /// Interfaz creada para cumplir con el patrón DIP. Permite que las clases dependan de abstracciones
    /// en vez de clases concretas.
    /// </summary>
    public interface IMostrar
    {
        /// <summary>
        /// Método que construye un string con todos los elementos de la lista.
        /// </summary>
        /// <param name="lista">Lista para mostrar en pantalla.</param>
        /// <returns>Te devuelve los string de la lista.</returns>
        StringBuilder Mostrar(List<IConversorTexto> lista);
    }
}