// -----------------------------------------------------------------------
// <copyright file="Empresario.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace Library
{
    /// <summary>
    /// Clase que modela un empresario perteneciente a una empresa.
    /// </summary>
    public class Empresario : IUsuario
    {
        /// <summary>
        /// Id del usuario del empresario.
        /// </summary>
        /// <value></value>
        public int Id { get; set; }

        /// <summary>
        /// Estado en el que se encuentra este usuario para los handlers.
        /// </summary>
        /// <value></value>
        public EstadoUsuario Estado { get; set; }

        /// <summary>
        /// Nombre que tiene el empresario.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Empresario"/> class.
        /// Método constructor de la clase.
        /// </summary>
        /// <param name="num">Indica el Id del empresario.</param>
        /// <param name="estado">Indica el estado en el que se encuentra el empresario.</param>
        /// <param name="nombre">Indica el nombre que tiene el empresario.</param>
        public Empresario(int num, EstadoUsuario estado, string nombre)
        {
            this.Id = num;
            this.Estado = estado;
            this.Nombre = nombre;
        }
    }
}