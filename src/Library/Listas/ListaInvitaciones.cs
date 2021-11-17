using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Library
{
    /// <summary>
    /// ListaInvitaciones es quien se encarga de tener la lista con todas las 
    /// invitaciones que fueron hechas. 
    /// Se cumple principio SRP ya que libra al administrador de conocer todas las
    /// invitaciones.
    /// </summary>
    public class ListaInvitaciones : IJsonConvertible
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
        public string ConvertToJson()
        {
            return JsonSerializer.Serialize(this);
        }
        public void LoadFromJson(string json)
        {
            ListaInvitaciones listaInvs = new ListaInvitaciones();
            listaInvs = JsonSerializer.Deserialize<ListaInvitaciones>(json);
            this.Invitaciones = listaInvs.Invitaciones;
        }
        /// <summary>
        /// Se crea el método Add para añadir las Invitaciones a la ListaInvitaciones
        /// ya existente. 
        /// Se pone en esta clase para cumplir el patrón Expert ya que es la que conoce
        /// todas las invitaciones que existen.
        /// </summary>
        /// <param name="Invitacion"></param>
        public void Add(string Invitacion)
        {
            this.Invitaciones.Add(Invitacion);
        }
    }
}