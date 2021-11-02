using System;
using System.Text;

namespace Library
{
    /// <summary>
    /// Handler encargado de la creación de un objeto de la clase Material. Implementa AbstractHandler
    /// porque interactúa con el usuario.
    /// </summary>
    public class MaterialesHandler : AbstractHandler

    {
        /// <summary>
        /// Método que evalúa el mensaje y crea un Material. Le pide los datos al usuario y luego crea
        /// un objeto Material con esos datos.
        /// </summary>
        /// <param name="mensaje"></param>
        public override void Handle(Mensaje mensaje)
        {
            Console.WriteLine("Cual es el nombre del material?");
            string nombre = Console.ReadLine();
            Console.WriteLine("Cual es su costo?");
            double costo = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Cual es la cantidad?");
            double cantidad = Convert.ToDouble(Console.ReadLine()); 
            Console.WriteLine("Cuantas unidades?");
            string unidad = Console.ReadLine();
            Console.WriteLine("Posee alguna habilitación?");
            string habilitaciones = Console.ReadLine();
            Console.WriteLine("Cuál es la categoría?");
            string categoria = Console.ReadLine();

            Material material = new Material(nombre, costo, cantidad, unidad, habilitaciones, categoria);
        }
    }
}