// -----------------------------------------------------------------------
// <copyright file="Emprendedor.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Text;

namespace Library
{
    /// <summary>
    /// Clase que modela un usuario del tipo emprendedor.
    /// Implementa la interfaz IUsuario e IConversorTexto. 
    /// Por el principio DIP depende de la abstracción IConversorTexto y también la interfaz IUsuario que por OCP facilita su extensión por si surjen nuevos usuarios y disminuye su modificación.
    /// </summary>
    public class Emprendedor : IUsuario, IConversorTexto
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Emprendedor"/>.
        /// Constructor de la clase emprendedor.
        /// </summary>
        /// <param name="id">id del emprendedor.</param>
        /// <param name="nombre">nombre del emprendedor.</param>
        /// <param name="ubicacion">ubicación del emprendedor.</param>
        /// <param name="rubro">rubro del emprendedor.</param>
        /// <param name="habilitaciones">habilitaciones del emprendedor.</param>
        /// <param name="especializaciones">especializaciones del emprendedor.</param>
        public Emprendedor(long id, string nombre, string ubicacion, string rubro, string habilitaciones, string especializaciones)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Ubicacion = ubicacion;
            this.Rubro = rubro;
            this.Habilitaciones = habilitaciones;
            this.Especializaciones = especializaciones;
            ListaEmprendedores lista = Singleton<ListaEmprendedores>.Instance;
            lista.Add(this);
        }

        /// <summary>
        /// Obtiene o establece id del Emprendedor.
        /// </summary>
        /// <value>Se guarda el Id de el usuario.</value>
        public long Id { get; set; }

        /// <summary>
        /// Obtiene o establece atributo para ver el estado en el que se encuentra este usuario dentro de los handlers.
        /// </summary>
        /// <value>Se guarda el Estado de la conversación del usuario.</value>
        public EstadoUsuario Estado { get; set; }

        /// <summary>
        /// Obtiene o establece nombre del emprendedor.
        /// </summary>
        /// <value>Se guarda el nombre del emprendedor.</value>
        public string Nombre { get; set; }

        /// <summary>
        /// Obtiene o establece ubicación del emprendedor.
        /// </summary>
        /// <value>Se guarda la dirección del emprendedor.</value>
        public string Ubicacion { get; set; }

        /// <summary>
        /// Obtiene o establece rubro del emprendedor.
        /// </summary>
        /// <value>Se guarda el rubro del emprendedor.</value>
        public string Rubro { get; set; }

        /// <summary>
        /// Obtiene habilitaciones del emprendedor(Link al documento).
        /// </summary>
        /// <value>Se guarda las habilitaciones que contiene el emprendedor.</value>
        public string Habilitaciones { get; }

        /// <summary>
        /// Obtiene especializaciones del emprendedor.
        /// </summary>
        /// <value>Se guardan las especializaciones del emprendedor.</value>
        public string Especializaciones { get; }

        /// <summary>
        /// Método que crea un string con toda la información del emprendedor.
        /// </summary>
        /// <returns>Devuelve una string con la información del emprendedor.</returns>
        public string ConvertToString()
        {
            StringBuilder resultado = new StringBuilder();
            resultado.Append($"Nombre: {this.Nombre}\n");
            resultado.Append($"Ubicación: {this.Ubicacion}\n");
            resultado.Append($"Rubro: {this.Rubro}\n");
            resultado.Append($"Habilitaciones: {this.Habilitaciones}\n");
            resultado.Append($"Especializaciones: {this.Especializaciones}\n");
            return resultado.ToString();
        }
    }
}