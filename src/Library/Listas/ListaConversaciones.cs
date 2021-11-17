using System.Collections.Generic;
using System.Text.Json;

namespace Library
{
    /// <summary>
    /// ListaConversaciones es quien se encarga de tener la lista con todos los 
    /// mensajes enviados.
    /// Cumple con el principio SRP ya que cada objeto de la lista tiene los mensajes
    /// entre un usuario y el bot, y la lista contiene todas las conversaciones
    /// los usuarios y el bot.
    /// </summary>
    public class ListaConversaciones: IJsonConvertible 
    {
        /// <summary>
        /// Lista que contiene las conversaciones entre todos los usuarios y el bot.
        /// </summary>
        /// <returns></returns>
        public string ConvertToJson()
        {
            return JsonSerializer.Serialize(this);
        }
        public void LoadFromJson(string json)
        {
            ListaConversaciones listaConvs = new ListaConversaciones();
            listaConvs = JsonSerializer.Deserialize<ListaConversaciones>(json);
         
        public List<Conversacion> Conversaciones = Singleton<List<Conversacion>>.Instance;
        
        public void Add(Conversacion conversacion)
        {
            this.Conversaciones.Add(conversacion);
        }
    }
}