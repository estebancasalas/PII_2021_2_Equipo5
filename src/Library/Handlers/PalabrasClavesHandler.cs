using System;
using System.Text;

namespace Library
{
    /// <summary>
    /// Handler para las palabras clave
    /// </summary>
    public class PalabrasClavesHandler :IHandler
    {
        public IHandler Next {get; set;}
        public void Handle(Mensaje mensaje)
        {
            /*if (mensaje.Text.Contains("/"))
            {}
            else
            {
                this.Next.Handle(mensaje);
            }*/

            Console.WriteLine("Añadir Palabra clave: ");
            string palabraclave = Console.ReadLine();
        }
    }
}