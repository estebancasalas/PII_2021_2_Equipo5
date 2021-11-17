using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Library
{
    
    /// <summary>
    /// ListaAdministradores es quien se encarga de tener la lista con todos los 
    /// Administradores registrados. 
    /// Se cumple principio SRP ya que libra al administrador de tener que crearse a él mismo 
    /// y al mismo tiempo conocer todos los Administradores registrados. 
    /// </summary>
    public class ListaAdminastradores: IJsonConvertible
    {
        
        /// <summary>
        /// Lista que contiene todos los administradores registrados.
        /// </summary>
        /// <returns></returns>
        public static List<Administrador> Administradores = Singleton<List<Administrador>>.Instance;
    
        public string ConvertToJson()
        {
            return JsonSerializer.Serialize(this);
        }
        public void LoadFromJson(string json)
        {
            ListaAdminastradores listaAdms = new ListaAdminastradores();
            listaAdms = JsonSerializer.Deserialize<ListaAdminastradores>(json);
        }
    }    
}