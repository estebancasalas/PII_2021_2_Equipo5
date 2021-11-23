/*/ -----------------------------------------------------------------------
// <copyright file="Conversacion.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// La clase conversación se encarga de llevar el conteo de mensajes de cada uno de los ususarios.
    /// Esta clase está pensada para la proxima entrega, nos va ayudar a poder identificar el estado de la conversación.
    /// </summary>
public class Conversacion
    {
        /// <summary>
        /// Lista donde se guardan los mensajes.
        /// </summary>
        /// <returns></returns>
        private List<string> mensajes = new List<string>();

        /// <summary>
        /// Método encargado de agregar el mensaje enviado como parámetro a la lista de mensajes.
        /// </summary>
        /// <param name="mensaje">Mensaje a agregar en la conversación.</param>
        private void AgregarMensaje(string mensaje)
        {
            this.mensajes.Add(mensaje);
        }
    }
}*/