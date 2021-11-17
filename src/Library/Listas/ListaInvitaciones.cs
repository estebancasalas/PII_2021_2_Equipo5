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
<<<<<<< HEAD
        public string ConvertToJson()
        {
            return JsonSerializer.Serialize(this);
        }
        public void LoadFromJson(string json)
        {
            ListaAdminastradores listaInvs = new ListaAdminastradores();
            listaInvs = JsonSerializer.Deserialize<ListaAdminastradores>(json);
=======
        public void Add(string Invitacion)
        {
            this.Invitaciones.Add(Invitacion);
>>>>>>> e2afae5dc9bdaa4d1226ed589788ac2b4ddaf4d7
        }
    }
}