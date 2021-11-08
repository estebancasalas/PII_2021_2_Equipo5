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
        /// Atributo donde se guarda el resultado.
        /// </summary>
        public string resultado;
        /// <summary>
        /// Método que evalúa el mensaje. Si el mensaje es "/historial", el Handler le pide el nombre 
        /// al usuario y devuelve el historial de compras/ventas con ese nombre. Si el mensaje es otro,
        /// se envía al siguiente Handler.
        /// </summary>
        /// <param name="mensaje">Indica que se quiere ver el historial</param>
        public override void Handle(Mensaje mensaje)
        { 
            if (mensaje.Text == "/historial")
            {
                string nombre = Input.GetInput("¿Cuál es tu nombre?");
                VerHistorial historial = new VerHistorial();
                resultado = historial.EjecutarComando(nombre);
                Output.PrintLine(resultado);
            }
            else
            {
                this.Next.Handle(mensaje);
            }
        }
    }
}