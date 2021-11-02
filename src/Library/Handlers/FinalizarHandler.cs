using System;
using System.Text;

namespace Library
{
    public class FinalizarHandler : AbstractHandler
    {
        public override void Handle (Mensaje mensaje)
        {
                   
            if (mensaje.Text == "/Finalizar")
            {
                Output.PrintLine("Gracias por usar nuestro bot, esperamos que te haya ayuado.");
            }
            else
            {
                this.Next.Handle(mensaje);
            }
        }
    }

}