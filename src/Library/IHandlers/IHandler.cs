using System;

namespace Library
{
    /// <summary>
    /// Interfaz para la creación de los handlers
    /// </summary>
    public interface IHandler
    {
        IHandler Next {get;}
        void Handle(Mensaje mensaje);
    }
}