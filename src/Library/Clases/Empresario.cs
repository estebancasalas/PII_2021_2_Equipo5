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
        /// Initializes a new instance of the <see cref="Empresario"/> class.
        /// Método constructor de la clase.
        /// </summary>
        /// <param name="num">Indica el Id del empresario.</param>
        /// <param name="estado">Indica el estado en el que se encuentra el empresario.</param>
        /// <param name="nombre">Indica el nombre que tiene el empresario.</param>
        public Empresario(long id, EstadoUsuario estado, string nombre)
        {
            this.Id = id;
            this.Estado = estado;
            this.Nombre = nombre;
        }

        /// <summary>
        /// Gets or sets id del usuario del empresario.
        /// </summary>
        /// <value>Guarda el id del empresario.</value>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets estado en el que se encuentra este usuario para los handlers.
        /// </summary>
        /// <value>Guarda el estado en el que se encuentra la conversasion con el usuario.</value>
        public EstadoUsuario Estado { get; set; }

        /// <summary>
        /// Gets or sets nombre del empresario.
        /// </summary>
        /// <value>Guarda el nombre del empresario.</value>
        public string Nombre { get; set; }
    }
}