// -----------------------------------------------------------------------
// <copyright file="Administrador.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace Library
{
    /// <summary>
    /// Clase que modela el rol de administrador.
    /// Es el encargado de generar las invitaciones para las empresas.
    /// </summary>
    public class Administrador
    {
        private int id;
        private string nombre;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Administrador"/>.
        /// Constructor de la clase Administrador.
        /// </summary>
        /// <param name="id">El id con el cual se registra un administrador.</param>
        /// <param name="nombre">El  con el cual se registra un administrador.</param>
        public Administrador(int id, string nombre)
        {
            this.Id = id;
            this.Nombre = nombre;
            ListaAdministradores lista = Singleton<ListaAdministradores>.Instance;
            lista.Add(this);
        }

        /// <summary>
        /// Obtiene o establece se guarda el id de el administrador al registrarse.
        /// </summary>
        /// <value>Id del administrador.</value>
        public int Id
        {
            get { return this.id; } set { this.id = value; }
        }

        /// <summary>
        /// Obtiene o establece guarda el nombre que pone el administrador al registrarse.
        /// </summary>
        /// <value>Nombre del administrador.</value>
        public string Nombre
        {
            get { return this.nombre; } set { this.nombre = value; }
        }

        /// <summary>
        /// Método que crea el objeto empresa y su token de invitación.
        /// </summary>
        /// <param name="nombre">Nombre de la empresa.</param>
        /// <param name="ubicacion">Ubicación de la empresa.</param>
        /// <param name="rubro">Rubro de la empresa.</param>
        /// <param name="token">Token de invitación creada por el administrador.</param>
        public static void CrearInvitacion(string nombre, string ubicacion, string rubro, string token)
        {
            Empresa empresa = new Empresa(nombre, ubicacion, rubro, token);
            Singleton<ListaInvitaciones>.Instance.Add(token);
        }
    }
}
