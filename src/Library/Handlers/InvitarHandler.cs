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

        public string Ubicacion { get => this.ubicacion; set => this.ubicacion = value; }

        public string Nombre { get => this.nombre; set => this.nombre = value; }

        public string Token { get => this.token; set => this.token = value; }

        public string Rubro { get => this.rubro; set => this.rubro = value; }

        /// <summary>
        /// Método para invitar a un usuario. Pide el nombre de un usuario y crea una invitación
        /// para el mismo?.
        /// </summary>
        /// <param name="mensaje">Indica que se quiere crear una invitación.</param>
        public override string Handle(Mensaje mensaje)
        {
            ListaDeUsuario listaUsuario = new ListaDeUsuario();
            int indice = listaUsuario.Buscar(mensaje.Id);
            EstadoUsuario estado = listaUsuario.ListaUsuarios[indice].Estado;

            if (mensaje.Text.ToLower() == "/crearinvitacion" || estado.Handler == "/crearinvitacion")
            {
                ListaAdministradores listaAdministradores = new ListaAdministradores();
                if  (listaAdministradores.Verificar(mensaje.Id))
                {
                    estado.Handler = "/crearinvitacion";
                    switch(estado.Step)
                    {
                        case 0 :
                        Console.WriteLine("¿Cuál es su nombre?");
                        estado.Step++;
                        break;

                        case 1 :
                        this.Nombre = mensaje.Text;
                        Console.WriteLine("¿Cuál es su ubicación?");
                        estado.Step++;
                        break;

                        case 2 :
                        this.Ubicacion = mensaje.Text;
                        Console.WriteLine("¿Cuál es su rubro?");
                        estado.Step++;
                        break;

                        case 3 :
                        this.Rubro = mensaje.Text;
                        Console.WriteLine("¿Cuál es su Token?");
                        estado.Step++;
                        break;

                        case 4 :
                        this.Token = mensaje.Text;
                        Administrador.CrearInvitacion(this.Nombre, this.Ubicacion, this.Rubro, this.Token);
                        estado = new EstadoUsuario();
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Usted no es un administrador.");
                }
            }
            else
            {
                this.GetNext().Handle(mensaje);
            }


            this.GetNext().Handle(mensaje);
            return this.TextResult.ToString();

        }
    }
}