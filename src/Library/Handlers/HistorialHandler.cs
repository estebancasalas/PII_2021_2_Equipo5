using System;
using System.Text;

namespace Library
{
    /// <summary>
    /// Handler para verificar el historial de un usuario. Implementa AbstractHandler porque
    /// interactúa con el usuario.
    /// </summary>
    public class HistorialHandler : AbstractHandler
    {
        /// <summary>
        /// Método que evalúa el mensaje. Si el mensaje es "/historial", el Handler le pide el nombre 
        /// al usuario y devuelve el historial de compras/ventas con ese nombre. Si el mensaje es otro,
        /// se envía al siguiente Handler.
        /// </summary>
        /// <param name="mensaje"></param>
        public override void Handle (Mensaje mensaje)
        {
                   
            if (mensaje.Text == "/historial")
            {
                Console.WriteLine("¿Cuál es tu nombre?");
                string nombre = Console.ReadLine();
                VerHistorial historial = new VerHistorial();
                nombre = historial.EjecutarComando(nombre);
                Console.WriteLine(nombre);
            }
            else
            {
                this.Next.Handle(mensaje);
            }
        }
    }
}  