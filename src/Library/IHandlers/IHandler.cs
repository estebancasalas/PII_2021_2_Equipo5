using System;

namespace Library
{
    /// <summary>
    /// Interfaz para la creación de los handlers.
    /// Dada la naturaleza de los handlers se usa el patrón Chain of responsibility, asi se puede recorren todos los handlers hasta que se encuentre el que se necesita.
    /// </summary>
    public interface IHandler
    {
        /// <summary>
        /// Las clases que apliquen IHandler pueden tambien pasar el Next para que se recorran el resto de los handlers.
        /// </summary>
        /// <value></value>
        IHandler Next {get;}
        /// <summary>
        /// Todos los handlers deben tener un metodo para pasar al siguiente si no existe un comando que actualmente no esté apuntando.
        /// </summary>
        /// <param name="mensaje"></param>
        void Handle(Mensaje mensaje);
    }
}