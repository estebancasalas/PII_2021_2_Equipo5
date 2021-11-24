// -----------------------------------------------------------------------
// <copyright file="CrearEmprendedorHandler.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace Library
{
    /// <summary>
    /// Handler encargado de crear un emprendedor. Implementa AbstractHandler porque interactúa con el
    /// usuario.
    /// </summary>
    public class CrearEmprendedorHandler : AbstractHandler
    {
        private string nombre;
        private string rubro;
        private string ubicacion;
        private string habilitacion;
        private string especializaciones;
        
        /// <summary>
        /// Método encargado de crear un emprendedor. El mismo interactúa con el usuario para que le
        /// dé los datos para crear un emprendedor. Colabora con la clase Emprendedor.
        /// </summary>
        /// <param name="mensaje">Indica que se quiere crear un emprendedor.</param>
        /// <returns>Retorna la respuesta a la petición del usuario.</returns>
        public override string Handle(Mensaje mensaje)
        {
            ListaDeUsuario listaUsuario = new ListaDeUsuario();
            int indice = listaUsuario.Buscar(mensaje.Id);
            EstadoUsuario estado = listaUsuario.ListaUsuarios[indice].Estado;

            if (mensaje.Text.ToLower() == "/emprendedor" || estado.Handler == "/emprendedor" )
            {
                if (!listaUsuario.EstaRegistrado(mensaje.Id))
                {
                    estado.Handler = "/emprendedor";
                    switch (estado.Step)
                    {
                        case 0:
                        Console.WriteLine("¿Cuál es su nombre?");
                        estado.Step++;
                        break;

                        case 1:
                        this.nombre = mensaje.Text;
                        Console.WriteLine("¿Cuál es su rubro?");
                        estado.Step++;
                        break;

                        case 2:
                        this.rubro = mensaje.Text;
                        Console.WriteLine("¿Cuál es la direccion de su domicilio?");
                        estado.Step++;
                        break;

                        case 3:
                        this.ubicacion = mensaje.Text;
                        Console.WriteLine("¿Posee alguna habilitacion?");
                        estado.Step++;
                        break;

                        case 4:
                        this.habilitacion = mensaje.Text;
                        string especializaciones = Input.GetInput("¿En qué se especializa?");
                        estado.Step++;
                        break;

                        case 5:
                        this.especializaciones = mensaje.Text;
                        Emprendedor emprendedor = new Emprendedor(mensaje.Id, this.nombre, this.rubro, this.ubicacion, this.habilitacion, this.especializaciones);
                        estado = new EstadoUsuario();
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Usted ya esta registrado.");
                }
                
                return this.TextResult.ToString();
            }
            else
            {   

                return this.GetNext().Handle(mensaje);
            }
        }
    }
}
