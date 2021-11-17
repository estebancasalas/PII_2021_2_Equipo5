using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// ListaConversaciones es quien se encarga de tener la lista con todos los 
    /// mensajes enviados.
    /// Cumple con el principio SRP ya que cada objeto de la lista tiene los mensajes
    /// entre un usuario y el bot, y la lista contiene todas las conversaciones
    /// los usuarios y el bot.
    /// </summary>
    public class ListaConversaciones 
    {
        /// <summary>
        /// Lista que contiene las conversaciones entre todos los usuarios y el bot.
        /// </summary>
        /// <returns></returns>
        public List<Conversacion> Conversaciones = Singleton<List<Conversacion>>.Instance;
        public void Add(Conversacion conversacion)
        {
            this.Conversaciones.Add(conversacion);
        }
    }
}