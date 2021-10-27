using System;
using System.Collections.Generic;


namespace Library
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