using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Handler para registrar un empresario en una empresa. Implementa AbstractHandler
    /// porque interactúa con el usuario.
    /// </summary>
    public class RegistrarEmpresarioHandler : AbstractHandler
    {
        /// <summary>
        /// Token para verificar que es válida la invitación.
        /// </summary>
        public string token;
        /// <summary>
        /// Método encargado de verificar si la invitación es válida. En caso de que lo sea y el 
        /// empresario no esté registrado, lo registra. En caso contrario, le avisa al usuario que no
        /// es una invitación válida.S
        /// </summary>
        /// <param name="mensaje">Indica que se quiere registrar un empresario</param>
        public override void Handle(Mensaje mensaje)
        {
            ListaDeUsuario listaUsuarios = new ListaDeUsuario();
            if (mensaje.Text.ToLower() == "/empresario" && listaUsuarios.EstaRegistrado(mensaje.Id))
            {

                token = Input.GetInput("Ingrese su código de invitación: ");
                ListaInvitaciones verificador = new ListaInvitaciones(); //Qué pasa si no ingresa nada?
                if (verificador.VerificarInvitacion(token))
                {
                    List<Empresa> lista = Singleton<ListaEmpresa>.Instance.Empresas;
                    Empresa empresa = lista.Find(x => x.Invitacion == token);
                    string nombre = Input.GetInput("Ingrese nombre: ");
                    Empresario empresario = new Empresario(mensaje.Id, new EstadoUsuario(), nombre);
                    empresa.ListaEmpresarios.Add(empresario);
                }
                else
                {
                    Output.PrintLine("Lo siento, la invitación no es válida.");
                }
            }
            this.GetNext().Handle(mensaje);
        }
    }
}