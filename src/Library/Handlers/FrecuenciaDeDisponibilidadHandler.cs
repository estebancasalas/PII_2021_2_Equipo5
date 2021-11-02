using System;
using System.Text;

namespace Library
{
    public class FrecuenciaDeDisponibilidadHandler : AbstarctHandler
    {
        public override void Handle (Mensaje mensaje)
        {
            
            if (mensaje.Text == "/FrecuenciaDeDisponibilidad")
            {
                Output.PrintLine("De material desea conocer su Frecuencia de disponibilidad");
                if (mensaje.Text == "madera")
                {
                    //...
                }
                else if (mensaje.Text == "plastico")
                {
                    //...
                }
                else
                {
                    Output.PrintLine("No conocemos ese material.");
                }
            }
            else
            {
                this.Next.Handle(mensaje);
            }
        }
    }
}
