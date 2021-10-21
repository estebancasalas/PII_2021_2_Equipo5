using System;

namespace ConsoleApplication
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
     }
}