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
        /// <summary>
        /// Obtiene o establece un valor que indica si la invitación es válida.
        /// Debería ser privada pero esta publica ya que la nesecitamos utilizar en los tests.
        /// </summary>
        /// <value>Booleano que es resultado de la verificación de la invitación.</value>
        public bool InvitacionValida { get; set; }

        /// <summary>
        /// Obtiene o establece la propiedad en donde se guarda la invitación.
        /// Debería ser privada pero esta publica ya que la nesecitamos utilizar en los tests.
        /// </summary>
        /// <value>Código de invitación que introduce el usuario.</value>
        public string Invitacion { get; set; }

        /// <summary>
        /// Obtiene o establece la propiedad en donde se guarda el nombre.
        /// Debería ser privada pero esta publica ya que la nesecitamos utilizar en los tests.
        /// </summary>
        /// <value>Nombre que ingresa el usuario al interactuar con el bot.</value>
        public string Nombre { get; set; }

        /// <summary>
        /// Obtiene o establece la propiedad en donde se guarda o establece la empresa en donde se registro el empresario..
        /// Debería ser privada pero esta publica ya que la nesecitamos utilizar en los tests.
        /// </summary>
        /// <value>Empresa donde se registra el empresario.</value>
        public Empresa Empresa { get; set; }

        /// <summary>
        /// Método encargado de verificar si la invitación es válida. En caso de que lo sea y el
        /// empresario no esté registrado, lo registra. En caso contrario, le avisa al usuario que no
        /// es una invitación válida.
        /// </summary>
        /// <param name="mensaje">Mensaje recibido como parámetro. Contiene Id y el texto a evaluar.</param>
        /// <returns>Returna respuesta a la peticion del usuario.</returns>
        public override string Handle(Mensaje mensaje)
        {
            ListaEmpresa listaEmpresa = new ListaEmpresa();
            ListaEmprendedores listaEmprendedores = new ListaEmprendedores();
            ListaDeUsuario listaUsuarios = new ListaDeUsuario();
            int indice = listaUsuarios.Buscar(mensaje.Id);
            EstadoUsuario estado = listaUsuarios.ListaUsuarios[indice].Estado;
            if (mensaje.Text.ToLower() == "/empresario" || estado.Handler.ToLower() == "/empresario")
            {
                if (!listaEmpresa.Verificar(mensaje.Id) && (listaEmprendedores.Buscar(mensaje.Id) == null))
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
                        this.Invitacion = mensaje.Text;
                        ListaInvitaciones verificador = Singleton<ListaInvitaciones>.Instance;
                        this.InvitacionValida = verificador.VerificarInvitacion(this.Invitacion);
                        if (this.InvitacionValida)
                        {
                            List<Empresa> lista = Singleton<ListaEmpresa>.Instance.Empresas;
                            this.Empresa = lista.Find(x => x.Invitacion == this.Invitacion);
                            this.TextResult.Append("Ingrese su nombre: ");
                        }
                        else
                        {
                            this.TextResult.Append("Lo siento, su invitacion no es valida. El proceso se ha finalizado.");
                        }

                        estado.Step++;
                        break;

                        case 2:
                        this.TextResult = new StringBuilder();
                        this.Nombre = mensaje.Text;
                        Empresario empresario = new Empresario(mensaje.Id, new EstadoUsuario(), this.Nombre);
                        this.Empresa.listaEmpresarios.Add(empresario);
                        estado.Step = 0;
                        estado.Handler = string.Empty;
                        this.TextResult.Append($"{this.Nombre}, te has registrado a {this.Empresa.Nombre} correctamente");
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