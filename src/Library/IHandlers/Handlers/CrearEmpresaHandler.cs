/*
using System;
using System.Text;

namespace Library
{
        public class CrearPublicacionHandler : IHandler
    {
        public IHandler Next {get; set;}
        private string titulo;
        private string material;
        private string ubicacion;
        private string frecuenciaDeDisponibilidad; 
        private string categorias; 

        public void Handle(Mensaje mensaje)
        {
            Console.WriteLine("Indique el nombre de su publicación: ");
            titulo = Console.ReadLine();
            Console.WriteLine("Indique el material de la publicación que desea hacer: ");
            material = Console.ReadLine();
            Console.WriteLine("Indique la ubicación en dónde se encuentra el material: ");
            ubicacion = Console.ReadLine();
            Console.WriteLine("Indique las palabras claves para poder encontrar su material: ");
            categorias = Console.ReadLine();
            Console.WriteLine("Indique las palabras claves para poder encontrar su material: ");
            palabrasClave = Console.ReadLine();

        }
    }
}   
*/
using System;
using System.Text;
using System.Collections.Generic;

namespace Library
{
    public class CrearPublicacionHandler : AbstarctHandler
    {
        public override void Handle(Mensaje mensaje)
        {
            base.Handle(mensaje);
            if (mensaje.Text == "/CrearPublicación")
            {
                CrearPublicacion publicacioncreada = new CrearPublicacion ();
            }
            else
            {
                this.Next.Handle(mensaje);
            }

        }
    }
}