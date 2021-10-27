using System;

namespace ConsoleApplication
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
        public DatosDeMateriales datosDeMateriales;
        public string PalabrasClave;
        public string FrecuenciaDeDisponibilidad;
        public string Ubicacion;

        public void EjecutarComando()
        {
            Console.WriteLine("Ingrese título: ");
            string titulo = Console.ReadLine();
            Console.WriteLine("Ingrese los datos de su material: ");
            DatosDeMateriales datosDeMateriales = Console.ReadLine();
            Console.WriteLine("Ingrese palabras clave: ");
            string PalabrasClave = Console.ReadLine();
            Console.WriteLine("Ingrese la frecuencia de disponibilidad: ");
            string FrecuenciaDeDisponibilidad = Console.ReadLine();
            Console.WriteLine("Ingrese la ubicación: ");
            string Ubicacion = Console.ReadLine();
            
            Publicacion publicacion = new Publicacion(titulo, datosDeMateriales, PalabrasClave, FrecuenciaDeDisponibilidad, Ubicacion);
        }
    }
}
