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
                Output.PrintLine($"Tu historial es {}.");
            }
            else
            {
                this.Next.Handle(mensaje);
            }
        }
}