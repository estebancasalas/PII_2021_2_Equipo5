using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ConsoleApplication
{
    public class SignUp

    {
        public string Nombre = "/Registrarse";
        public Usuario EjecutarComando(string comando)
        {
            if (comando == "emprendedor")
            {
                Console.WriteLine("Ingrese su nombre: ");
                string nombre = Console.ReadLine();
                Console.WriteLine("Ingrese su apellido: ");
                string apellido = Console.ReadLine();
                Emprendedor result = new Emprendedor(nombre , apellido);
                return result;
            }
            if (comando == "empresa")
            {
                   
            }
        }
    }
}