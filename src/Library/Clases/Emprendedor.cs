using System;

namespace Library
{
    /// <summary>
    /// Clase con los datos del emprendedor. Incluye:
    /// -id (public string)
    /// -nombre (private string)
    /// -ubicación (public string)
    /// -rubro (private string)
    /// -habilitaciones (private string)
    /// -especializaciones (private string)
    /// </summary>
    public class Emprendedor
    {
        /// <summary>
        /// id del Emprendedor.
        /// </summary>
        /// <value></value>
        public string id {get; set;}
        private string nombre {get;}
        /// <summary>
        /// ubicación del emprendedor
        /// </summary>
        /// <value></value>
        public string ubicacion {get; set;}
        private string rubro {get;}
        private string habilitaciones{get;}
        private string  especializaciones {get;}

        public Emprendedor(string nombre, string ubicacion, string rubro, string habilitaciones, string especializaciones)
        {
            this.nombre = nombre;
            this.ubicacion = ubicacion;
            this.rubro = rubro;
            this.habilitaciones = habilitaciones;
            this.especializaciones = especializaciones;
        }
     }
}