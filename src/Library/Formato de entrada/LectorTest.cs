// -----------------------------------------------------------------------
// <copyright file="LectorTest.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// LectorTest hereda la clase de EntradaDeLaCadena para simular la interacción con el,
    /// usuario en los tests.
    /// Cumple con DIP pues la comunicación es a través de clases de alto nivel y
    /// abstracciones (Interfaces).
    /// Cumple SRP pues su única razón de cambio es recibir una línea de la consola.
    /// Se aplica el patrón Polimorfismo ya que se decide cuál de los métodos GetInput,
    /// usar en tiempo de ejecución, dependiendo del objeto que recibe el mensaje GetInput.
    /// </summary>
    public class LectorTest : EntradaDeLaCadena
    {
        /// <summary>
        /// Diccionario que simula la interacción entre usuario y bot.
        /// </summary>
        public Dictionary<string, string> diccionario;

        /// <summary>
        /// Initializes a new instance of the <see cref="LectorTest"/> class.
        /// Constructor de la clase.
        /// </summary>
        /// <param name="dic">diccionario del cual se leen las claves.</param>
        public LectorTest(Dictionary<string, string> dic)
        {
            this.diccionario = dic;
        }

        /// <summary>
        /// El GetInput es método el cúal despliega un mensaje en consola y recibe su respuesta.
        /// </summary>
        /// <param name="message">Mensaje que se muestra en consola al usuario.</param>
        /// <returns>Debe de ser un string.</returns>
        public override string GetInput(string message)
        {
            return this.diccionario[message];
        }
    }
}