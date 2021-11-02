using LocationApi;
using System;

namespace Library
{
    /// <summary>
    /// Clase con los datos de una publicación, contiene:
    /// -Título
    /// -Material
    /// -Palabras Claves
    /// -Frecuencia de disponibilidad
    /// -Ubicación
    /// </summary>
    public class Publicacion
    {
        /// <summary> 
        /// Nombre de la publicación.
        /// </summary>
        /// <value></value>
        private string titulo {get; set;}
        /// <summary>
        /// Tipo de material
        /// </summary>
        /// <value></value>
        public Material Material {get; set;}
        /// <summary>
        /// Palabras claves para lograr una busqueda efectiva
        /// </summary>
        private string palabrasClave;
        public string PalabrasClave
        {
            get{ return this.palabrasClave; }
            set{ this.PalabrasClave = value; }
        }
        /// <summary>
        ///Permite conocer cada tanto tiempo se genera
        /// </summary>
        /// <value></value>
        private string FrecuenciaDeDisponibilidad {get; set;}
        
        /// Donde se localiza el material de la publicación
        public Location Ubicacion {get; set;}

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

