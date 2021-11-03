using System;

namespace Library
{
    /// <summary>
    /// Clase para usar en otras clases que requieran el envio y la recepción de mensajes.
    /// Es una clase con patron Mediator ya que los mensajes generados están restringidos a un formato especifico.
    /// </summary>
    public class Mensaje
    {
        /// <summary>
        /// Se guarda una Id en forma de un entero.
        /// </summary>
        /// <value></value>
        public int Id{ get; set;}
        /// <summary>
        /// String que guarda un mensaje en forma de texto.
        /// </summary>
        /// <value></value>
        public string Text {get; set;}
        /// <summary>
        /// El metodo permite crear un mensaje con una cierta Id y un cierto mensaje.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="text"></param>
        public Mensaje(int id, string text)
        {
            this.Id = id;
            this.Text = text;
        }
    }
}