using System;
using System.Collections.Generic;


namespace Library
{

    /// <summary>
    /// La clase conversación se encarga de llevar el conteo de mensajes de cada 
    /// uno de los ususarios
    /// </summary>
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