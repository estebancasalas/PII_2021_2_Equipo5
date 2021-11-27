// -----------------------------------------------------------------------
// <copyright file="InvitarHandler.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    /// <summary>
    /// Handler para crear una invitacion. Implementa AbstractHandler porque la interacción es
    /// con el usuario.
    /// </summary>
    public class InvitarHandler : AbstractHandler
    {
        /// <summary>
        /// Nombre de la emrpesa.
        /// </summary>
        private string nombre;

        /// <summary>
        /// Ubicación de la empresa.
        /// </summary>
        private string ubicacion;

        /// <summary>
        /// Rubro de la empresa.
        /// </summary>
        private string rubro;

        /// <summary>
        /// Token de invitación.
        /// </summary>
        private string token;

        /// <summary>
        /// Obtiene o establece la ubicacion.
        /// </summary>
        /// <value>Ubicacion.</value>
        public string Ubicacion { get => this.ubicacion; set => this.ubicacion = value; }

        /// <summary>
        /// Obtiene o establece el nombre.
        /// </summary>
        /// <value>Nombre.</value>
        public string Nombre { get => this.nombre; set => this.nombre = value; }

        /// <summary>
        /// Obtiene o establece el token para la invitacion.
        /// </summary>
        /// <value>Token.</value>
        public string Token { get => this.token; set => this.token = value; }

        /// <summary>
        /// Obtiene o establece el rubro.
        /// </summary>
        /// <value>Rubro.</value>
        public string Rubro { get => this.rubro; set => this.rubro = value; }

        /// <summary>
        /// Método para invitar a un usuario. Pide el nombre de un usuario y crea una invitación
        /// para el mismo?.
        /// </summary>
        /// <param name="mensaje">Indica que se quiere crear una invitación.</param>
        /// <returns>Retorna la espuesta a la peticion del usuario.</returns>
        public override string Handle(Mensaje mensaje)
        {
            ListaDeUsuario listaUsuario = new ListaDeUsuario();
            int indice = listaUsuario.Buscar(mensaje.Id);
            EstadoUsuario estado = listaUsuario.ListaUsuarios[indice].Estado;

            if (mensaje.Text.ToLower() == "/crearinvitacion" || estado.Handler == "/crearinvitacion")
            {
                ListaAdministradores listaAdministradores = new ListaAdministradores();
                if (listaAdministradores.Verificar(mensaje.Id))
                {
                    estado.Handler = "/crearinvitacion";
                    switch (estado.Step)
                    {
                        case 0:
                            this.TextResult = new StringBuilder();
                            this.TextResult.Append("¿Cuál es el nombre de la empresa?");
                            estado.Step++;
                            break;

                        case 1:
                            this.TextResult = new StringBuilder();
                            this.Nombre = mensaje.Text;
                            this.TextResult.Append("¿Cuál es la ubicación de la empresa?");
                            estado.Step++;
                            break;

                        case 2:
                            this.TextResult = new StringBuilder();
                            this.Ubicacion = mensaje.Text;
                            this.TextResult.Append("¿Cuál es el rubro de la empresa?");
                            estado.Step++;
                            break;

                        case 3:
                            this.TextResult = new StringBuilder();
                            this.Rubro = mensaje.Text;
                            this.TextResult.Append("¿Qué codigo de invitación desea asignarle?");
                            estado.Step++;
                            break;

                        case 4:
                            this.TextResult = new StringBuilder();
                            this.Token = mensaje.Text;
                            Administrador.CrearInvitacion(this.Nombre, this.Ubicacion, this.Rubro, this.Token);
                            estado = new EstadoUsuario();
                            this.TextResult.Append($"Empresa registrada con los siguientes datos:\nNombre: {this.nombre}\nUbicacion: {this.ubicacion}\nRubro: {this.rubro}\nInvitación: {this.token}");
                            break;
                    }
                }
                else
                {
                    this.TextResult.Append("Usted no es un administrador.");
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