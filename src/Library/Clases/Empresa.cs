// -----------------------------------------------------------------------
// <copyright file="Empresa.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Library
{
    /// <summary>
    /// Clase que modela una empresa.
    /// Implementa la interfaz IConversorTexto para que dependa de una abstracción cumpliendo con el principio DIP.
    /// </summary>
    public class Empresa : IConversorTexto
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Empresa"/>.
        /// Es el constructor que se encarga de crear a la empresa en su totalidad.
        /// </summary>
        /// <param name="nombre">Nombre de la empresa.</param>
        /// <param name="ubicacion">Ubicación de la empresa.</param>
        /// <param name="rubro">Rubro de la empresa.</param>
        /// <param name="invitacion">Invitación de la empresa.</param>
        /// <param name="contacto">Contacto de la empresa.</param>
        
        public Empresa(string nombre, string ubicacion, string rubro, string invitacion, string contacto)
        {
            this.Invitacion = invitacion;
            this.Nombre = nombre;
            this.Ubicacion = ubicacion;
            this.Rubro = rubro;
            this.Contacto = contacto;
            Singleton<ListaEmpresa>.Instance.Add(this);
        }

        /// <summary>
        /// La ListaEmpresarios se encarga de registrar todos los usuarios que puede tener una misma empresa.
        /// Utiliza la libreria "System.Text.Json.Serialization" para serializar dicha lista.
        /// </summary>
        /// <value></value>
        [JsonInclude]
        public List<Empresario> ListaEmpresarios = new List<Empresario>();

        /// <summary>
        /// Obtiene o establece el contacto de la empresa.
        /// </summary>
        /// <value>Guarda el contacto en tipo string, la idea es que sea un mail o numero de teléfono</value>
        public string Contacto { get; set; }

        /// <summary>
        /// Obtiene o establece la invitación de la empresa.
        /// </summary>
        /// <value>Guarda la invitación que la empresa le brinda a los empresarios para unirse.</value>
        public string Invitacion { get; set; }

        /// <summary>
        /// Obtiene o establece guarda el nombre de la empresa.
        /// </summary>
        /// <value>Guarda el nombre de la empresa.</value>
        public string Nombre { get; set; }

        /// <summary>
        /// Obtiene o establece guarda la ubicación de la empresa.
        /// </summary>
        /// <value>Guarda la ubicación de la empresa.</value>
        public string Ubicacion { get; set; }

        /// <summary>
        /// Obtiene o establece guarda el rubro de la empresa.
        /// </summary>
        /// <value>Guarda el rubro de la empresa.</value>
        public string Rubro { get; set; }

        /// <summary>
        /// Método que crea un string con la información de la empresa.
        /// </summary>
        /// <returns>Devuelve el string con la información de la empresa.</returns>

        public string ConvertToString()
        {
            StringBuilder resultado = new StringBuilder();
            resultado.Append($"Nombre: {this.Nombre}\n");
            resultado.Append($"Ubicación: {this.Ubicacion}\n");
            resultado.Append($"Rubro: {this.Rubro}\n");
            return resultado.ToString();
        }
    }
}
