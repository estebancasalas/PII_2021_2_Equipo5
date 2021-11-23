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
        bool invitacionValida;
        string invitacion;
        string nombre;
        Empresa empresa;
    
        /// <summary>
        /// Método encargado de verificar si la invitación es válida. En caso de que lo sea y el 
        /// empresario no esté registrado, lo registra. En caso contrario, le avisa al usuario que no
        /// es una invitación válida.S
        /// </summary>
        /// <param name="mensaje">Indica que se quiere registrar un empresario</param>
        public override string Handle(Mensaje mensaje)
        {
            ListaDeUsuario listaUsuarios = new ListaDeUsuario();
            if (mensaje.Text.ToLower() == "/empresario" && listaUsuarios.EstaRegistrado(mensaje.Id))
            {
                int indice = listaUsuarios.Buscar(mensaje.Id);
                EstadoUsuario estado = listaUsuarios.ListaUsuarios[indice].Estado;
                estado.handler = this;
                switch(estado.step)
                {
                    case 0 :
                    Console.WriteLine("Ingrese su código de invitación: ");
                    estado.step = estado.step + 1;
                    
                    break;

                    case 1 :
                    invitacion = mensaje.Text;
                    ListaInvitaciones verificador = new ListaInvitaciones();
                    invitacionValida = verificador.VerificarInvitacion(invitacion);
                    if (invitacionValida)
                    {
                        List<Empresa> lista = Singleton<List<Empresa>>.Instance;
                        empresa = lista.Find(x => x.Invitacion == invitacion);
                        Console.WriteLine("Ingrese nombre: ");
                    }
                    else
                    {
                        Console.WriteLine("Lo siento, su invitacion no es valida. El proceso se ha finalizado.");
                    }
                    estado.step = estado.step + 1;
                    break;

                    case 2 :
                    nombre = mensaje.Text;
                    Empresario empresario = new Empresario(mensaje.Id, new EstadoUsuario(), nombre);
                    empresa.ListaEmpresarios.Add(empresario);
                    break;
                }
            }
            else
            {
                this.GetNext().Handle(mensaje);
            }
            return this.TextResult.ToString();
            
        }
    }
}