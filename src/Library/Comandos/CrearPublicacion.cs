using System;
using LocationApi;

namespace Library
{
    public class CrearPublicacion : IComandos
    {
        public string Nombre; 
        public string nombre 
        {
            get => Nombre; 
            set => Nombre = "/CrearPublicacion";
        }
        public string titulo;
        public Material DatosDeMateriales;
        public string PalabrasClave;
        public string FrecuenciaDeDisponibilidad;
        public Location Localizacion;

        public async void EjecutarComando()
        {
            Console.WriteLine("Ingrese título: ");
            string titulo = Console.ReadLine();
            Console.WriteLine("Ingrese los datos de su material: ");
            string datosDeMateriales = Console.ReadLine();
            Console.WriteLine("Ingrese palabras clave: ");
            string PalabrasClave = Console.ReadLine();
            Console.WriteLine("Ingrese la frecuencia de disponibilidad: ");
            string FrecuenciaDeDisponibilidad = Console.ReadLine();
            Console.WriteLine("Ingrese la ubicación: ");
            IUbicacion ubicacion = new Ubicacion();
            Location Localizacion = await ubicacion.GetUbicacion(Console.ReadLine());
            
            Publicacion publicacion = new Publicacion(titulo, DatosDeMateriales, PalabrasClave, FrecuenciaDeDisponibilidad, Localizacion);
        }
    }
}
