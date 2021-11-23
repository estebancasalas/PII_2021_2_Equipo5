// -----------------------------------------------------------------------
// <copyright file="Singleton.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace Library
{
    /// <summary>
    /// Se usa en los handlers que requieren la utilización del patrón singleton, tales como AbstractHandler y UsuarioInterfaz.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class Singleton<T>
        where T : new()
    {
        private static T instance;

        /// <summary>
        /// Gets se crea una nueva instancia solo si no existe previamente.
        /// </summary>
        /// <value>Se guarda una nueva instancia.</value>
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new T();
                }

                return instance;
            }
        }
    }
}