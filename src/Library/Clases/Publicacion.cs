using LocationApi;
using System;

namespace Library
{
    /// <summary>
    /// Clase que modela un usario del tipo publicación. 
    /// </summary>
    public class Publicacion
    {
        /// <summary>
        /// Nombre de quien hace la publicación.
        /// </summary>
        public string NombreEmpresa;
        /// <summary> 
        /// Se encarga de guardar el título de la publicación dentro del objeto publicación.
        /// </summary>
        /// <value></value>
        public string Titulo;
        /// <summary>
        /// Se encarga de guardar el material de la publicación dentro del objeto publicación.
        /// </summary>
        /// <value></value>
        public Material Material;
        /// <summary>
        /// Se encarga de guardar las palabras claves para lograr una búsqueda efectiva dentro del objeto publicación.
        /// </summary>
        public string PalabrasClave;
        /// <summary>
        /// Permite conocer cada cuánto tiempo se genera el mismo y los guarda en el objeto material. 
        /// </summary>
        /// <value></value>
        public string FrecuenciaDeDisponibilidad;
        
        /// Atributo en dónde se guarda la ubicación del material.
        public Location Ubicacion { get; set; }
       /// <summary>
       /// Constructor de la clase Publicacion.
       /// </summary>
       /// <param name="titulo">Título de la publicación</param>
       /// <param name="material">Material que se va a publicar</param>
       /// <param name="PalabrasClave">Palabras clave para buscar la publicación</param>
       /// <param name="FrecuenciaDeDisponibilidad">Frecuencia de disponibilidad del material</param>
       /// <param name="ubicacion">Ubicación del vendedor</param>
       /// <param name="nombreEmpresa">Nombre de quien vende el material</param>

        public Publicacion(string titulo, Material material, string PalabrasClave, string FrecuenciaDeDisponibilidad, Location ubicacion, string nombreEmpresa)
        {
            this.Titulo = titulo;
            this.Material = material;
            this.PalabrasClave = PalabrasClave;
            this.FrecuenciaDeDisponibilidad = FrecuenciaDeDisponibilidad;
            this.Ubicacion = ubicacion;
            this.NombreEmpresa = nombreEmpresa;
            RegistroPublicaciones.AñadirNuevaPublicacion(this);
        }
    }
}

