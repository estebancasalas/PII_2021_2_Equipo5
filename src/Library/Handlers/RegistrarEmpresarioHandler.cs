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
            if (mensaje.Text == "/empresa")
            {
                token = Input.GetInput("Ingrese su código de invitación: ");
                ListaInvitaciones verificador = new ListaInvitaciones(); //Qué pasa si no ingresa nada?
                if (verificador.VerificarInvitacion(token))
                {
                    bool notfound = true;
                    int i = 0;
                    while (notfound)
                    {
                        if (ListaEmpresa.Empresas[i].Invitacion == token)
                        {
                            ListaEmpresa.Empresas[i].ListaIdEmpresarios.Add(mensaje.Id);
                            ListaDeUsuario.IdUsuarios.Add(mensaje.Id); //Crear un metodo de agregar empresario?
                            notfound = false;
                        }
                        else
                        {
                            i++;
                        }
                    }
                }
                else
                {
                    Output.PrintLine("Lo siento, la invitación no es válida.");
                }
            }
        }
    }
}