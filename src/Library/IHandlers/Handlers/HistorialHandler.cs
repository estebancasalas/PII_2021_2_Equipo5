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