using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Library
{
    public class SignUp

    {
        public string Nombre = "\\Registrarse";
        public void EjecutarComando(string comando)
        {
            if (comando == "\\emprendedor")
            {
                Emprendedor result = new Emprendedor();
                //En vez de que SignUp cree el usuario, que llame a un metodo de otra clase para crearlo.
                Console.WriteLine("Ingrese su nombre: ");
                string nombre = Console.ReadLine();
                Console.WriteLine("Ingrese su apellido: ");
                string apellido = Console.ReadLine();
                //return result;
            }
            
            if (comando == "\\empresa")
            {
                Empresa result = new Empresa();

            }
        }
    }
}