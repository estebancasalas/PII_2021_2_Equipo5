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
        /// El CovertToJson es el método por el cual se guardan los datos dentro de un archivo
        /// json.
        /// </summary>
        /// <returns></returns>
        public string ConvertToJson()
        {
            return JsonSerializer.Serialize(this);
        }
        /// <summary>
        /// LoadFromJson se encarga de cargar los datos guardados creando los objetos 
        /// a partir de el archivo json. 
        /// </summary>
        /// <param name="json"></param>
        public void LoadFromJson(string json)
        {
            ListaConversaciones listaConvs = new ListaConversaciones();
            listaConvs = JsonSerializer.Deserialize<ListaConversaciones>(json);
            this.Conversaciones = listaConvs.Conversaciones;
        }
        /// <summary>
        /// Lista que contiene las conversaciones entre todos los usuarios y el bot.
        /// Utiliza el patrón de diseño Singleton para que el atributo sea único y global.
        /// </summary>
        /// <returns></returns>
        public List<Conversacion> Conversaciones = Singleton<List<Conversacion>>.Instance;
        /// <summary>
        /// Se crea el método Add para añadir una Conversación a la ListaConversaciones
        /// ya existente. 
        /// Se pone en esta clase para cumplir el patrón Expert ya que es la que conoce
        /// todas las conversaciones.
        /// </summary>
        /// <param name="conversacion"></param>
        public void Add(Conversacion conversacion)
        {
            this.Conversaciones.Add(conversacion);
        }
    }
}