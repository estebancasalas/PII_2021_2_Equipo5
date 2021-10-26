using System;
using System.Text;

namespace Library
{
    public class ComienzoHandler : AbstarctHandler
    {
        public override void Handle (Mensaje mensaje)
        {
            if (mensaje.Text == "/start")
            {
                Output.PrintLine("Bienvenido al Bot de materiales reciclables, te ayudare a encontrar el material que quieras para tu emprendimiento, para eso escribe /comandos y veras todas tus opciones");
            }
            else
            {
                this.Next.Handle(mensaje);
            }
        }
    }
}