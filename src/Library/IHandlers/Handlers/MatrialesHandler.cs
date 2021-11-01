using System;
using System.Text;

namespace Library
{
    public class MaterialesHandler : AbstarctHandler

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

        public void Handle(Mensaje mensaje)
        {
            Console.WriteLine("Cual es el nombre del material?");
            string nombre = Console.ReadLine();
            Console.WriteLine("Cual es su costo?");
            double costo = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Cual es la cantidad?");
            double cantidad = Convert.ToDouble(Console.ReadLine()); 
            Console.WriteLine("Cual es la ubicación");
            string ubicacion = Console.ReadLine(); //Hay que hacer clase para conseguir la ubicacion.
            Console.WriteLine("Cuantas unidades?");
            string unidad = Console.ReadLine();
            Console.WriteLine("Posee alguna habilitación?");
            string habilitaciones = Console.ReadLine();

            Console.WriteLine("Cuál es la categoría?");
            string categoria = Console.ReadLine();

            Material material = new Material(nombre, costo, cantidad, ubicacion, unidad, habilitaciones, categoria);
        }
    }
}