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
        /// Método encargado de verificar si la invitación es válida. En caso de que lo sea y el 
        /// empresario no esté registrado, lo registra. En caso contrario, le avisa al usuario que no
        /// es una invitación válida.S
        /// </summary>
        /// <param name="mensaje"></param>
        public void Handle(Mensaje mensaje)
        {
            if (mensaje.Text == "/empresa")
            {
                string token = Input.GetInput("Ingrese su código de invitación.");
                VerificarInvitacion verificador = new VerificarInvitacion(token); //Qué pasa si no ingresa nada?
                if (verificador.valido)
                {
                    bool notfound = true;
                    int i = 0;
                    while (notfound)
                    {
                        if (ListaEmpresa.Empresas[i].Invitacion == token)
                        {
                            ListaEmpresa.Empresas[i].ListaIdEmpresarios.Add(mensaje.Id);
                            notfound = true;
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