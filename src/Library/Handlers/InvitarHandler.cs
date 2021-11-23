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
        public override void Handle(Mensaje mensaje)
        {
            if (mensaje.Text.ToLower() == "/crearinvitacion")
            {
                List<Administrador> lista = Singleton<ListaAdministradores>.Instance.Administradores;
                bool notfound = true;
                int i = 0;
                while (notfound && i < lista.Count)
                {
                    if (lista[i].Id == mensaje.Id)
                    {
                        notfound = false;
                        this.Nombre = this.Input.GetInput("nombre empresa");
                        this.Ubicacion = this.Input.GetInput("ubicacion de la empresa");
                        this.Rubro = this.Input.GetInput("rubro de la empresa");
                        this.Token = this.Input.GetInput("Codigo de invitacion");
                        Administrador.CrearInvitacion(this.Nombre, this.Ubicacion, this.Rubro, this.Token);
                    }
                    else
                    {
                        i++;
                    }
                }
            }

            this.GetNext().Handle(mensaje);
        }
    }
}