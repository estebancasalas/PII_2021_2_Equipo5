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
        public List <string> Invitaciones = Singleton<List<string>>.Instance; 

        public bool VerificarInvitacion(string invitacion)
        {
            return Invitaciones.Contains(invitacion);
        }
        public void Add(string Invitacion)
        {
            this.Invitaciones.Add(Invitacion);
        }
    }
}