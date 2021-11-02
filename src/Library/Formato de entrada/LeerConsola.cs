using System;
namespace Library
{
    /// <summary>
    ///LeerConsola es una implementación de la interface IEntaradaDeLaCadena para interactuar con el usuario a través de la
    ///consola. Cumple con DIP pues la comunicación es a través de clases de alto nivel y abstracciones (Interfaces).
    ///Cumple SRP pues su unica razon de cambio es recibir una linea de la consola.
    /// </summary>
    public class LeerConsola : IEntaradaDeLaCadena
    {
        /// <summary>
        /// El GetInput es método el cúal despliega un mensaje en consola y recibe su respuesta.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public string GetInput (string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
    }
}