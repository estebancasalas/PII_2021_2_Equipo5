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
        /// Id del Emprendedor.
        /// </summary>
        /// <value></value>
        public int Id {get; set;}
        /// <summary>
        /// Nombre del emprendedor.
        /// </summary>
        /// <value></value>
        public string Nombre {get; set;}
        /// <summary>
        /// Ubicación del emprendedor.
        /// </summary>
        /// <value></value>
        public string Ubicacion {get; set;}
        /// <summary>
        /// Rubro del emprendedor.
        /// </summary>
        /// <value></value>
        public string Rubro {get; set;}
        /// <summary>
        /// Habilitaciones del emprendedor(Link al documento).
        /// </summary>
        /// <value></value>
        public string Habilitaciones{get;}
        /// <summary>
        /// Especializaciones del emprendedor.
        /// </summary>
        /// <value></value>
        public string Especializaciones {get;}
        /// <summary>
        /// Constructor de la clase emprendedor.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="ubicacion"></param>
        /// <param name="rubro"></param>
        /// <param name="habilitaciones"></param>
        /// <param name="especializaciones"></param>

        public Emprendedor(int id, string nombre, string ubicacion, string rubro, string habilitaciones, string especializaciones)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Ubicacion = ubicacion;
            this.Rubro = rubro;
            this.Habilitaciones = habilitaciones;
            this.Especializaciones = especializaciones;
        }
     }
}