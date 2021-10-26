using System;

namespace ConsoleApplication
{
    public interface IComandos
    {
        string nombre {get; set;}
        
        void EjecutarComando();
        
    }
}