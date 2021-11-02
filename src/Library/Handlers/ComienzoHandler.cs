using System;
using System.Text;

namespace Library
{
    /// <summary>
    /// 
    /// </summary>
    public class ComienzoHandler : AbstractHandler
    {
        public override void Handle (Mensaje mensaje)
        {
            //En vez de start, que se fije si no tiene / y si es la primera vez que escribe el usuario
            
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