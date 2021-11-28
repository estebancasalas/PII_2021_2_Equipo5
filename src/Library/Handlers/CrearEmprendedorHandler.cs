// -----------------------------------------------------------------------
// <copyright file="CrearEmprendedorHandler.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Text;

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
            ListaDeUsuario listaUsuario = Singleton<ListaDeUsuario>.Instance;
            int indice = listaUsuario.Buscar(mensaje.Id);
            EstadoUsuario estado = listaUsuario.ListaUsuarios[indice].Estado;
            ListaEmprendedores listaEmprendedores = Singleton<ListaEmprendedores>.Instance;

            if (mensaje.Text.ToLower() == "/emprendedor" || estado.Handler == "/emprendedor")
            {
                if (listaEmprendedores.Buscar(mensaje.Id) == null)
                {
                    estado.Handler = "/emprendedor";
                    switch (estado.Step)
                    {
                        case 0:
                            this.TextResult = new StringBuilder();
                            this.TextResult.Append("¿Cuál es su nombre?");
                            estado.Step++;
                            break;

                        case 1:
                            this.TextResult = new StringBuilder();
                            this.nombre = mensaje.Text;
                            this.TextResult.Append("¿Cuál es su rubro?");
                            estado.Step++;
                            break;

                        case 2:
                            this.TextResult = new StringBuilder();
                            this.rubro = mensaje.Text;
                            this.TextResult.Append("¿Cuál es la direccion de su domicilio?");
                            estado.Step++;
                            break;

                        case 3:
                            this.TextResult = new StringBuilder();
                            this.ubicacion = mensaje.Text;
                            this.TextResult.Append("¿Posee alguna habilitacion?");
                            estado.Step++;
                            break;

                        case 4:
                            this.TextResult = new StringBuilder();
                            this.habilitacion = mensaje.Text;
                            this.TextResult.Append("¿En qué se especializa?");
                            estado.Step++;
                            break;

                        case 5:
                            this.TextResult = new StringBuilder();
                            this.especializaciones = mensaje.Text;
                            Emprendedor emprendedor = new Emprendedor(mensaje.Id, this.nombre, this.ubicacion, this.rubro, this.habilitacion, this.especializaciones);
                            this.TextResult.Append($"Usted ha sido registrado con los siguientes datos:\n{this.nombre}\n{this.rubro}\n{this.ubicacion}\n{this.habilitacion}\n{this.especializaciones}");
                            estado = new EstadoUsuario();
                            break;
                    }
                }
                else
                {
                    this.TextResult.Append("Usted ya esta registrado.");
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
