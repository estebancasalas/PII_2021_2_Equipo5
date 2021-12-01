// -----------------------------------------------------------------------
// <copyright file="Empresario.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace Library
{
    /// <summary>
    /// Clase que modela un empresario que pertenece a una empresa.
    /// Implementa la abstracción IUsuario ya que por el principio OCP permite su extension en caso de posibles nuevos usuarios y disminuye su modificación.
    /// </summary>
    public class Empresario : IUsuario
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Empresario"/>.
        /// Método constructor de la clase.
        /// </summary>
        /// <param name="id">Id del empresario.</param>
        /// <param name="estado">Estado del empresario.</param>
        /// <param name="nombre">Nombre del empresario.</param>
        public Empresario(long id, EstadoUsuario estado, string nombre)
        {
            this.Id = id;
            this.Estado = estado;
            this.Nombre = nombre;
        }

        /// <summary>
        /// Obtiene o establece id del usuario del empresario.
        /// </summary>
        /// <value>Guarda el id del empresario.</value>
        public long Id { get; set; }

        /// <summary>
        /// Obtiene o establece el estado en el que se encuentra este usuario para los handlers.
        /// </summary>
        /// <value>Guarda el estado en el que se encuentra la conversasion con el usuario.</value>
        public EstadoUsuario Estado { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del empresario.
        /// </summary>
        /// <value>Guarda el nombre del empresario.</value>
        public string Nombre { get; set; }
    }
}