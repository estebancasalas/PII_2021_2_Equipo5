using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// ListaInvitaciones es quien se encarga de tener la lista con todas las 
    /// invitaciones que fueron hechas. 
    /// Se cumple principio SRP ya que libra al administrador de conocer todas las
    /// invitaciones.
    /// </summary>
    public class ListaInvitaciones
    {
        /// <summary>
        /// Lista que contiene todas las invtiaciones.
        /// </summary>
        /// <returns></returns>
        public static List <string> Invitaciones = new List<string> (); 
    }
}