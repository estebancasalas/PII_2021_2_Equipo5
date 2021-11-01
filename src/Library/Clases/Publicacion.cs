
using System;

namespace Library
{
    public class Publicacion
    {
        private string titulo {get; set;}
        public Material Material {get; set;}
        private string palabrasClave;
        public string PalabrasClave
        {
            get{ return this.palabrasClave; }
            set{ this.PalabrasClave = value; }
        }
        private string FrecuenciaDeDisponibilidad {get; set;}
        private string Ubicacion {get; set;}

        public Publicacion(string titulo, Material material, string PalabrasClave, string FrecuenciaDeDisponibilidad, string ubicacion)
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

