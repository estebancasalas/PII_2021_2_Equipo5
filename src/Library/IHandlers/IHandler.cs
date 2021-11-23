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
        private IHandler Next
        {
            get 
            {
                return this.Next;
            } 
            set 
            {
                this.Next = value;
            }
        }  
        /// <summary>
        /// Todos los handlers deben tener un metodo para pasar al siguiente si no existe un comando que actualmente no esté apuntando.
        /// </summary>
        /// <param name="mensaje">Mensaje escrito por usuario</param>
        string Handle(Mensaje mensaje);
        /// <summary>
        /// Método set para indicar el siguiente handler en la cadena.
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        IHandler SetNext(IHandler handler);
        /// <summary>
        /// Método get para obtener el siguiente handler en la cadena.
        /// </summary>
        /// <returns></returns>
        IHandler GetNext();
    }
}