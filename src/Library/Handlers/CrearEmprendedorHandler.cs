using System;

namespace Library
{
    /// <summary>
    /// Handler encargado de crear un emprendedor. Implementa AbstractHandler porque interactúa con el
    /// usuario.
    /// </summary>
    public class CrearEmprendedorHandler : AbstractHandler
    {
        /// <summary>
        /// Método encargado de crear un emprendedor. El mismo interactúa con el usuario para que le
        /// dé los datos para crear un emprendedor. Colabora con la clase Emprendedor.
        /// </summary>
        /// <param name="mensaje">Indica que se quiere crear un emprendedor</param>
        public override void Handle(Mensaje mensaje)
        {
            Console.WriteLine("¿Cuál es su nombre?");
            string nombre = Console.ReadLine();
            Console.WriteLine("¿Cuál es su rubro?");
            string rubro = Console.ReadLine();
            Console.WriteLine("¿Cuál es la direccion de su domicilio?");
            string ubicacion = Console.ReadLine(); //Hay que hacer clase para conseguir la ubicacion.
            Console.WriteLine("¿Posee alguna habilitacion?");
            string habilitacion = Console.ReadLine();
            Console.WriteLine("¿En qué se especializa?");
            string especializaciones = Console.ReadLine();

            Emprendedor emprendedor = new Emprendedor(mensaje.Id, nombre, rubro, ubicacion, habilitacion, especializaciones);

        }
    }
}
