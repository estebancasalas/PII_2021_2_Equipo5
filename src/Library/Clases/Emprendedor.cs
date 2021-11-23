// -----------------------------------------------------------------------
// <copyright file="Emprendedor.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace Library
{
    /// <summary>
    /// Clase que modela un usario del tipo emprendedor.
    /// Implementa la interfaz IUsuario, para lograr facilitar la extensión en caso de que
    /// surjan nuevos tipos de usuario.
    /// </summary>
    public class Emprendedor : IUsuario
    {
                /// <summary>
        /// Initializes a new instance of the <see cref="Emprendedor"/> class.
        /// Constructor de la clase emprendedor.
        /// </summary>
        /// <param name="id">Id del emprendedor.</param>
        /// <param name="nombre">Nombre del emprendedor.</param>
        /// <param name="ubicacion">Ubicación del emprendedor.</param>
        /// <param name="rubro">Rubro del emprendedor.</param>
        /// <param name="habilitaciones">Habilitaciones que tiene el emprendedor.</param>
        /// <param name="especializaciones">Especializaciones que tiene el emprendedor.</param>
        public Emprendedor(long id, string nombre, string ubicacion, string rubro, string habilitaciones, string especializaciones)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Ubicacion = ubicacion;
            this.Rubro = rubro;
            this.Habilitaciones = habilitaciones;
            this.Especializaciones = especializaciones;
        }

        /// <summary>
        /// Gets or sets id del Emprendedor.
        /// </summary>
        /// <value>Se guarda el Id de el usuario.</value>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets atributo para ver el estado en el que se encuentra este usuario dentro de los handlers.
        /// </summary>
        /// <value>Se guarda el Estado de la conversación del usuario.</value>
        public EstadoUsuario Estado { get; set; }

        /// <summary>
        /// Gets or sets nombre del emprendedor.
        /// </summary>
        /// <value>Se guarda el nombre del emprendedor.</value>
        public string Nombre { get; set; }

        /// <summary>
        /// Gets or sets ubicación del emprendedor.
        /// </summary>
        /// <value>Se guarda la dirección del emprendedor.</value>
        public string Ubicacion { get; set; }

        /// <summary>
        /// Gets or sets rubro del emprendedor.
        /// </summary>
        /// <value>Se guarda el rubro del emprendedor.</value>
        public string Rubro { get; set; }

        /// <summary>
        /// Gets habilitaciones del emprendedor(Link al documento).
        /// </summary>
        /// <value>Se guarda las habilitaciones que contiene el emprendedor.</value>
        public string Habilitaciones { get; }

        /// <summary>
        /// Gets especializaciones del emprendedor.
        /// </summary>
        /// <value>Se guardan las especializaciones del emprendedor.</value>
        public string Especializaciones { get; }
    }
}