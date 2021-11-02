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
        /// Se encarga de guardar el título de la publicación dentro del objeto publicación.
        /// </summary>
        /// <value></value>
        private string titulo {get; set;}
        /// <summary>
        /// Se encarga de guardar el material de la publicación dentro del objeto publicación.
        /// </summary>
        /// <value></value>
        public Material Material {get; set;}
        /// <summary>
        /// Se encarga de guardar las palabras claves para lograr una búsqueda efectiva dentro del objeto publicación.
        /// </summary>
        private string palabrasClave;
        /// <summary>
        /// Son los metodos get y set para poder acceder a el atributo palabrasClaves desde otras clases.   
        /// </summary>
        /// <value></value>
        public string PalabrasClave
        {
            get{ return this.palabrasClave; }
            set{ this.palabrasClave = value; }
        }
        /// <summary>
        /// Permite conocer cada cuanto tiempo se genera el mismo y los guarda en el objeto material. 
        /// </summary>
        /// <value></value>
        private string FrecuenciaDeDisponibilidad {get; set;}
        
        /// Atributo en dónde se guarda la ubicación del material.
        public Location Ubicacion {get; set;}
        /// <summary>
        /// Constructor de la ubicación 
        /// </summary>
        /// <param name="titulo"></param> Es el título de la publicación.
        /// <param name="material"></param>Es el material de la publicación.
        /// <param name="PalabrasClave"></param>Son las palabras claves de la publicación.
        /// <param name="FrecuenciaDeDisponibilidad"></param>Es la frecuencia de disponibilidad de la publicación.
        /// <param name="ubicacion"></param>Es la ubicación de la publicación.

        public Publicacion(string titulo, Material material, string PalabrasClave, string FrecuenciaDeDisponibilidad, Location ubicacion)
        {
            this.titulo = titulo;
            this.Material = material;
            this.PalabrasClave = PalabrasClave;
            this.FrecuenciaDeDisponibilidad = FrecuenciaDeDisponibilidad;
            this.Ubicacion = ubicacion;
        }
        //Falta categoria.
    }
}

