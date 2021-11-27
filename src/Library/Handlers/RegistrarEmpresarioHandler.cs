// -----------------------------------------------------------------------
// <copyright file="RegistrarEmpresarioHandler.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    /// <summary>
    /// Handler para registrar un empresario en una empresa. Implementa AbstractHandler
    /// porque interactúa con el usuario.
    /// </summary>
    public class RegistrarEmpresarioHandler : AbstractHandler
    {
        private bool invitacionValida;

        private string invitacion;

        private string nombre;
        private Empresa empresa;

        /// <summary>
        /// Método encargado de verificar si la invitación es válida. En caso de que lo sea y el
        /// empresario no esté registrado, lo registra. En caso contrario, le avisa al usuario que no
        /// es una invitación válida.
        /// </summary>
        /// <param name="mensaje">Mensaje recibido como parámetro. Contiene Id y el texto a evaluar.</param>
        /// <returns>Returna respuesta a la peticion del usuario.</returns>
        public override string Handle(Mensaje mensaje)
        {
            ListaDeUsuario listaUsuarios = new ListaDeUsuario();
            int indice = listaUsuarios.Buscar(mensaje.Id);
            EstadoUsuario estado = listaUsuarios.ListaUsuarios[indice].Estado;
            if (mensaje.Text.ToLower() == "/empresario" || estado.Handler == "/empresario")
            {
                if (!listaUsuarios.EstaRegistrado(mensaje.Id))
                {
                    estado.Handler = "/empresario";
                    switch (estado.Step)
                    {
                        case 0:
                        this.TextResult = new StringBuilder();
                        this.TextResult.Append("Ingrese su código de invitación: ");
                        estado.Step++;
                        break;

                        case 1:
                        this.TextResult = new StringBuilder();
                        this.invitacion = mensaje.Text;
                        ListaInvitaciones verificador = Singleton<ListaInvitaciones>.Instance;
                        this.invitacionValida = verificador.VerificarInvitacion(this.invitacion);
                        if (this.invitacionValida)
                        {
                            List<Empresa> lista = Singleton<ListaEmpresa>.Instance.Empresas;
                            this.empresa = lista.Find(x => x.Invitacion == this.invitacion);
                            this.TextResult.Append("Ingrese nombre: ");
                        }
                        else
                        {
                            this.TextResult.Append("Lo siento, su invitacion no es valida. El proceso se ha finalizado.");
                        }

                        estado.Step++;
                        break;

                        case 2:
                        this.TextResult = new StringBuilder();
                        this.nombre = mensaje.Text;
                        Empresario empresario = new Empresario(mensaje.Id, new EstadoUsuario(), this.nombre);
                        this.empresa.ListaEmpresarios.Add(empresario);
                        estado.Step = 0;
                        estado.Handler = null;
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