using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Clase que modela un usario del tipo empresa. 
    /// Implementa la interfaz IUsuario, para lograr facilitar la extensión en caso de que 
    /// surjan nuevos tipos de usuario.
    /// </summary>
    public class Empresa : IUsuario
    {
        /// <summary>
        /// La listaIdEmpresarios se encarga de registrar todos los usuarios que 
        /// puede tener una misma empresa.
        /// </summary>
        /// <value></value>
        public List<int> ListaIdEmpresarios {get; set;}
        /// <summary>
        /// Guarda el nombre de la empresa.
        /// </summary>
        /// <value></value>
        public string Nombre {get; set;}
        /// <summary>
        /// Guarda la ubicación de la empresa. 
        /// </summary>
        /// <value></value>
        public string Ubicacion {get; set;}
        /// <summary>
        /// Guarda el rubro de la empresa.
        /// </summary>
        /// <value></value>
        public string Rubro {get;set;}
        /// <summary>
        /// Es el constructor que se encarga de crear a la empresa en su totalidad
        /// </summary>
        /// <param name="nombre"></param>Se encarga de guardar el nombre de la empresa dentro del objeto empresa
        /// <param name="ubicacion"></param>Se encarga de guardar la ubicación de la empresa dentro del objeto empresa
        /// <param name="rubro"></param>Se encarga de guardar el rubro de la empresa dentro del objeto empresa
        public Empresa(string nombre, string ubicacion, string rubro)
        {
            this.ListaIdEmpresarios = new List<int>();
            this.Nombre = nombre;
            this.Ubicacion = ubicacion;
            this.Rubro = rubro;
        }
    }
}