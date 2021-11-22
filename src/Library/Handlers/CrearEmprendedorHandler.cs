using System;

namespace Library
{
    /// <summary>
    /// Handler encargado de crear un emprendedor. Implementa AbstractHandler porque interactúa con el
    /// usuario.
    /// </summary>
    public class CrearEmprendedorHandler : AbstractHandler
    {
        string nombre;
        string rubro;
        string ubicacion;
        string habilitacion;
        string especializaciones;
        /// <summary>
        /// Método encargado de crear un emprendedor. El mismo interactúa con el usuario para que le
        /// dé los datos para crear un emprendedor. Colabora con la clase Emprendedor.
        /// </summary>
        /// <param name="mensaje">Indica que se quiere crear un emprendedor</param>
        public override void Handle(Mensaje mensaje)
        {
            ListaDeUsuario listaUsuario = new ListaDeUsuario();
            if (mensaje.Text.ToLower() == "/emprendedor" && !listaUsuario.EstaRegistrado(mensaje.Id))
            {
                int indice = listaUsuario.Buscar(mensaje.Id);
                EstadoUsuario estado = listaUsuario.ListaUsuarios[indice].Estado;
                estado.handler = this;
                switch(estado.step)
                {
                    case 0 :
                    Console.WriteLine("¿Cuál es su nombre?");
                    estado.step = estado.step + 1;
                    break;

                    case 1 :
                    this.nombre = mensaje.Text;
                    Console.WriteLine("¿Cuál es su rubro?");
                    break;

                    case 2 :
                    this.rubro = mensaje.Text;
                    Console.WriteLine("¿Cuál es la direccion de su domicilio?");
                    break;

                    case 3 :
                    this.ubicacion = mensaje.Text;
                    Console.WriteLine("¿Posee alguna habilitacion?");
                    break;

                    case 4 :
                    this.habilitacion = mensaje.Text;
                    string especializaciones = Input.GetInput("¿En qué se especializa?");
                    break;

                    case 5 :
                    this.especializaciones = mensaje.Text;
                    Emprendedor emprendedor = new Emprendedor(mensaje.Id, this.nombre, this.rubro, this.ubicacion, this.habilitacion, this.especializaciones);
                    estado = new EstadoUsuario();
                    break;
                }
                
                
            }
            this.GetNext().Handle(mensaje);
        }
    }
}
