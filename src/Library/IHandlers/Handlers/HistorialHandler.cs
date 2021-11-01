using System;
using System.Text;

namespace Library
{
    public class HistorialHandler : AbstarctHandler
    {
        public override void Handle (Mensaje mensaje)
        {
                   
            if (mensaje.Text == "/historial")
            {
                // VerHistorial historial = new VerHistorial();
                Output.PrintLine($"Tu historial es {historial}."); //Arreglar error.
            }
            else
            {
                this.Next.Handle(mensaje);
            }
        }
    }
}  //Llama a VerHistorial.