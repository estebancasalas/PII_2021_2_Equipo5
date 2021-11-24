// -----------------------------------------------------------------------
// <copyright file="IHandler.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace Library
{
    /// <summary>
    /// Interfaz para la creación de los handlers.
    /// Dada la naturaleza de los handlers se usa el patrón Chain of responsibility, asi se puede recorren todos
    /// los handlers hasta que se encuentre el que se necesita.
    /// </summary>
    public interface IHandler
    {
        /// <summary>
        /// Gets or sets las clases que apliquen IHandler pueden tambien pasar el Next para que se recorran el resto de los handlers.
        /// </summary>
        /// <value>Se guardan el recorrido del resto de los handler.</value>
        private IHandler Next
        {
            get
            {
                return this.Next;
            }

            set
            {
                this.Next = value;
            }
        }

        /// <summary>
        /// Todos los handlers deben tener un metodo para pasar al siguiente si no existe un comando que actualmente no esté apuntando.
        /// </summary>
        /// <param name="mensaje">Mensaje escrito por usuario</param>
        string Handle(Mensaje mensaje);

        /// <summary>
        /// Método set para indicar el siguiente handler en la cadena.
        /// </summary>
        /// <param name="handler"> handler que esta indicado a continuacion en la cadena.</param>
        /// <returns>Retorna cual es el siguiente handler.</returns>
        IHandler SetNext(IHandler handler);

        /// <summary>
        /// Método get para obtener el siguiente handler en la cadena.
        /// </summary>
        /// <returns>Retorna el handler siguiente.</returns>
        IHandler GetNext();
    }
}