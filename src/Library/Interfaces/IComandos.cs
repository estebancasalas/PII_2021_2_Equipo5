using System;

namespace Library
{
    public interface IComandos
    {
        string nombre {get; set;}
        
        void EjecutarComando();
        
    }
}