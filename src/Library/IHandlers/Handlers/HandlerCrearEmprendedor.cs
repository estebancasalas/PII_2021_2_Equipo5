using System;

namespace Library
{
    public class CrearEmprendedorHandler : AbstarctHandler
    {
        public override void Handle(Mensaje mensaje)
        {
            Console.WriteLine("Cual es su nombre?");
            string nombre = Console.ReadLine();
            Console.WriteLine("Cual es su rubro?");
            string rubro = Console.ReadLine();
            Console.WriteLine("Cual es la direccion de su domicilio?");
            string ubicacion = Console.ReadLine(); //Hay que hacer clase para conseguir la ubicacion.
            Console.WriteLine("Posee alguna habilitacion?");
            string habilitacion = Console.ReadLine();
            Console.WriteLine("En que se especializa?");
            string especializaciones = Console.ReadLine();

            Emprendedor emprendedor = new Emprendedor(nombre, rubro, ubicacion, habilitacion, especializaciones);

        }
    }
}
