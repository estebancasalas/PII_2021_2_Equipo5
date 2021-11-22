// -----------------------------------------------------------------------
// <copyright file="IFormatoSalida.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace Library
{
    /// <summary>
    /// Interfaz para implementar una forma de mostrar un string en pantalla. Al ser una interfaz, se busca
    /// que se cumpla el principio OCP a través del principio LSP. Se pueden extender las capacidades del
    /// programa sin modificarlo (por ejemplo agregando otras API), al agregar clases que implementen la,
    /// interfaz y sustituyendo en el programa principal.
    /// </summary>
    public interface IFormatoSalida
    {
        /// <summary>
        /// Método para las clases que implementen esta interfaz. Muestra en pantalla el string pasado
        /// como parámetro.
        /// </summary>
        /// <param name="line">Lo que se muestra en consola.</param>
        /// <returns>Debe de ser una string.</returns>
        string PrintLine(string line);
    }
}