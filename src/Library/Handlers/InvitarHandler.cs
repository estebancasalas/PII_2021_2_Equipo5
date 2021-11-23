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
                        this.nombre = this.Input.GetInput("nombre empresa");
                        this.ubicacion = this.Input.GetInput("ubicacion de la empresa");
                        this.rubro = this.Input.GetInput("rubro de la empresa");
                        this.token = this.Input.GetInput("Codigo de invitacion");
                        Administrador.CrearInvitacion(this.nombre, this.ubicacion, this.rubro, this.token);
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