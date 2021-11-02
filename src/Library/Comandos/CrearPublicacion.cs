using System;
using LocationApi;

namespace Library
{
    /// <summary>
    /// CearPublicacion es la clase que se encarga del modelado de la publicación.
    /// </summary>
    public class CrearPublicacion 
    {

        /// <summary>
        /// DatosDeMateriales es el objeto que se utiliza en publicación para luego poder
        /// adquirir los datos del material que se encuentran/pide en la clase Material.
        /// </summary>
        public Material DatosDeMateriales {get; set;}
        /// <summary>
        /// Método que pide los datos necesarios para crear una publicación. Deriva la
        /// responsabilidad de crear la publicación a la clase Publicacion para cumplir
        /// con el principio SRP.
        /// </summary>
        /// <returns></returns>
        public async void EjecutarComando()
        {
            Console.WriteLine("Ingrese título: ");
            string titulo = Console.ReadLine();
            Console.WriteLine("Ingrese palabras clave: ");
            string PalabrasClave = Console.ReadLine();
            Console.WriteLine("Ingrese la frecuencia de disponibilidad: ");
            string FrecuenciaDeDisponibilidad = Console.ReadLine();
            Console.WriteLine("Ingrese la ubicación: ");
            IUbicacion ubicacion = new Ubicacion();
            Location Localizacion = await ubicacion.GetUbicacion(Console.ReadLine());
            //Llamar al material handler para que ingrese los datos del material del que desea 
            //crear la publicación  
            
            Publicacion publicacion = new Publicacion(titulo, DatosDeMateriales, PalabrasClave, FrecuenciaDeDisponibilidad, Localizacion);
        }
    }
}
