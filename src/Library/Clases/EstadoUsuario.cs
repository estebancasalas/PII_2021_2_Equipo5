// -----------------------------------------------------------------------
// <copyright file="EstadoUsuario.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Library
{
    /// <summary>
    /// Clase para conocer el estado del usuario. Cumple con SRP porque tiene la responsabilidad de conocer que handler se esta ejecutando y el. 
    /// paso que se debe de ejecutar.
    /// </summary>
    public class EstadoUsuario
    {
        /// <summary>
        /// Atributo para saber en qué handler está el usuario.
        /// </summary>
        public string Handler;

        /// <summary>
        /// Cuenta los pasos del usuario.
        /// </summary>
        public int Step;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="EstadoUsuario"/>.
        /// Constructor del estado del usuario.
        /// </summary>
        public EstadoUsuario()
        {
            this.Handler = string.Empty;
            this.Step = 0;
        }
    }
}