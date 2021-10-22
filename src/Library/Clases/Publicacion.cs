using System;

namespace ConsoleApplication
{
    public class Publicacion
    {
        private string titulo {get; set;}
        private DatosDeMateriales material {get; set;}
        private string PalabrasClave {get; set;}
        private string FrecuenciaDeDisponibilidad {get; set;}

        public Publicacion(string titulo, DatosDeMateriales material, string PalabrasClave, string FrecuenciaDeDisponibilidad)
        {
            this.titulo = titulo;
            this.material = material;
            this.PalabrasClave = PalabrasClave;
            this.FrecuenciaDeDisponibilidad = FrecuenciaDeDisponibilidad;
        }
    }
}