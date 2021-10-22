using System;
using System.Collections.Generic;


namespace ConsoleApplication
{
    public class Conversacion
    {
        private int id {get; set;}

        private List<string> mensajes = new List<string>();

        void AgregarMensaje(string mensaje)
        {
            mensajes.Add(mensaje);
        }
    }
}