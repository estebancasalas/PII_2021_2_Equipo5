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
            if (mensaje.Text.ToLower() == "/emprendedor")
            {
                string nombre = Input.GetInput("¿Cuál es su nombre?");
                string rubro = Input.GetInput("¿Cuál es su rubro?");
                string ubicacion = Input.GetInput("¿Cuál es la direccion de su domicilio?");
                string habilitacion = Input.GetInput("¿Posee alguna habilitacion?");
                string especializaciones = Input.GetInput("¿En qué se especializa?");
                Emprendedor emprendedor = new Emprendedor(mensaje.Id, nombre, rubro, ubicacion, habilitacion, especializaciones);
            }
            this.GetNext().Handle(mensaje);
        }
    }
}
