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
    public class Emprendedor // : IUsuario
    {
        /// <summary>
        /// id del Emprendedor.
        /// </summary>
        /// <value></value>
        public string id {get; set;}
        public string Nombre {get;}
        /// <summary>
        /// ubicación del emprendedor
        /// </summary>
        /// <value></value>
        public string Ubicacion {get; set;}
        public string Rubro {get;}
        public string Habilitaciones{get;}
        public string Especializaciones {get;}

        // public List <Transacciones> Transacciones = new List<Transacciones>();

        public Emprendedor(string nombre, string ubicacion, string rubro, string habilitaciones, string especializaciones)
        {
            this.Nombre = nombre;
            this.Ubicacion = ubicacion;
            this.Rubro = rubro;
            this.Habilitaciones = habilitaciones;
            this.Especializaciones = especializaciones;
        }
     }
}