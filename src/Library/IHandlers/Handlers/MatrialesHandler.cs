using System;
using System.Text;

namespace Library
{
    public class MaterialesHandler  :IHandler
    {
        public IHandler Next {get; set;}
        /*public void Handle(Mensaje mensaje)
        {
            if (mensaje.Text.Contains("/"))
            {}
            else
            {
                this.Next.Handle(mensaje);
            }
        }*/

        public override void Handle(Mensaje mensaje)
        {
            Console.WriteLine("Cual es su nombre?");
            string nombre = Console.ReadLine();
            Console.WriteLine("Cual es su costo?");
            string costo = Console.ReadLine();
            Console.WriteLine("Cual es la cantidad?");
            string cantidad = Console.ReadLine(); 
            Console.WriteLine("Cual es la ubicación");
            string ubicacion = Console.ReadLine(); //Hay que hacer clase para conseguir la ubicacion.
            Console.WriteLine("Cuantas unidades?");
            string unidad = Console.ReadLine();
            Console.WriteLine("Posee alguna habilitación?");
            string habilitaciones = Console.ReadLine();

            DatosDeMateriales material = new Material(nombre, costo, cantidad, ubicacion, unidad, habilitaciones);

        }
    }
}