using System;
namespace Library
{
    public class LeerConsola : IEntaradaDeLaCadena
    {
        public string GetInput (string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
    }
}