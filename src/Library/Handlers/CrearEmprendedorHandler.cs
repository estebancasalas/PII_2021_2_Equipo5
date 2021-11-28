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
        /// <summary>
        /// Obtiene o establece la propiedad en donde se guarda el nombre.
        /// Debería ser privada pero esta publica ya que la nesecitamos utilizar en los tests.
        /// </summary>
        /// <value>Nombre que ingresa el usuario al interactuar con el bot.</value>
        public string Nombre { get; set; }

        /// <summary>
        /// Obtiene o establece la propiedad en donde se guarda el rubro.
        /// Debería ser privada pero esta publica ya que la nesecitamos utilizar en los tests.
        /// </summary>
        /// <value>Rubro que ingresa el usuario al interactuar con el bot.</value>
        public string Rubro { get; set; }

        /// <summary>
        /// Obtiene o establece la propiedad en donde se guarda la ubicacion.
        /// Debería ser privada pero esta publica ya que la nesecitamos utilizar en los tests.
        /// </summary>
        /// <value>Ubicacion que ingresa el usuario al interactuar con el bot.</value>
        public string Ubicacion { get; set; }

        /// <summary>
        /// Obtiene o establece la propiedad en donde se guardan las habilitaciones.
        /// Debería ser privada pero esta publica ya que la nesecitamos utilizar en los tests.
        /// </summary>
        /// <value>Habilitaciones que ingresa el usuario al interactuar con el bot.</value>
        public string Habilitacion { get; set; }

        /// <summary>
        /// Obtiene o establece la propiedad en donde se guardan las especializaciones.
        /// Debería ser privada pero esta publica ya que la nesecitamos utilizar en los tests.
        /// </summary>
        /// <value>Especializaciones que ingresa el usuario al interactuar con el bot.</value>
        public string Especializaciones { get; set; }

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
                            this.Nombre = mensaje.Text;
                            this.TextResult.Append("¿Cuál es su rubro?");
                            estado.Step++;
                            break;

                        case 2:
                            this.TextResult = new StringBuilder();
                            this.Rubro = mensaje.Text;
                            this.TextResult.Append("¿Cuál es la direccion de su domicilio/emprendimiento?");
                            estado.Step++;
                            break;

                        case 3:
                            this.TextResult = new StringBuilder();
                            this.Ubicacion = mensaje.Text;
                            this.TextResult.Append("¿Posee alguna habilitacion?");
                            estado.Step++;
                            break;

                        case 4:
                            this.TextResult = new StringBuilder();
                            this.Habilitacion = mensaje.Text;
                            this.TextResult.Append("¿En qué se especializa?");
                            estado.Step++;
                            break;

                        case 5:
                            this.TextResult = new StringBuilder();
                            this.Especializaciones = mensaje.Text;
                            Emprendedor emprendedor = new Emprendedor(mensaje.Id, this.Nombre, this.Ubicacion, this.Rubro, this.Habilitacion, this.Especializaciones);
                            this.TextResult.Append($"Usted ha sido registrado con los siguientes datos:\n{this.Nombre}\n{this.Rubro}\n{this.Ubicacion}\n{this.Habilitacion}\n{this.Especializaciones}");
                            estado.Step = 0;
                            estado.Handler = null;
                            break;
                    }
                }
                else
                {
                    this.TextResult = new StringBuilder();
                    this.TextResult.Append("Usted ya está registrado.");
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
