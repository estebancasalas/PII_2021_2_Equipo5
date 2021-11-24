// -----------------------------------------------------------------------
// <copyright file="ComienzoHandler.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Text;

namespace Library
{
    /// <summary>
    /// Primer Handler de la Chain of Responsibility. Implementa AbstractHandler porque interactúa
    /// con el usuario.
    /// </summary>
    public class ComienzoHandler : AbstractHandler
    {
        /// <summary>
        /// Método que verifica el mensaje. Actúa si el mensaje es "/start" y sino lo envía
        /// al siguiente Handler.
        /// </summary>
        /// <param name="mensaje">Mensaje recibido como parámetro. Contiene Id y el texto a evaluar.</param>
        /// <returns>Retorna la respuesta a la petición del usuario.</returns>
        public override string Handle(Mensaje mensaje)
        {
            ListaDeUsuario listaUsuario = new ListaDeUsuario();
            int indice = listaUsuario.Buscar(mensaje.Id);
            EstadoUsuario estado = listaUsuario.ListaUsuarios[indice].Estado;

            if (mensaje.Text.ToLower() == "/comandos" || estado.Handler == "/comandos")
            {
                this.TextResult.Clear();
                this.TextResult.Append("Bienvenido al Bot de materiales reciclables, te ayudaré a encontrar el material que quieras para tu emprendimiento, los comandos disponibles son: ")
                        .Append("/Como empresa tus comandos son: \n")
                        .Append("/empresario\n")
                        .Append("/crearpublicacion\n")
                        .Append("/cantidadtrabajadores\n")
                        .Append("/crearinvitacion\n")
                        .Append("/historial\n")
                        .Append("/finalizar\n")
                        .Append("Como emprendedor tus comandos son: \n")
                        .Append("/emprendedor\n")
                        .Append("/buscarpublicacion\n")
                        .Append("/historial\n")
                        .Append("/comprar\n")
                        .Append("/finalizar\n");
                return this.TextResult.ToString();
            }
            else
            {
                return this.GetNext().Handle(mensaje);
            }
        }
    }
}