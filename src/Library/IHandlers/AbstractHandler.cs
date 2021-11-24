using System;
using System.Text;

// -----------------------------------------------------------------------
// <copyright file="AbstractHandler.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Library
{
    /// <summary>
    /// Una clase que implementa un metodo para recorrer los distintos handler existentes en busca de un comando escrito por el usuario.
    /// Como depende de la interfaz IHandler también usa Chain of Resposibility para que los handlers que usen AbstractHandler permitan que se recorran otros handlers.
    /// También usa singleton porque todos los handlers consultan esta clase para recorrer los handlers.
    /// </summary>
    public abstract class AbstractHandler : IHandler
    {
        public StringBuilder TextResult = new StringBuilder();
        /// <summary>
        /// Gets or sets las clases que apliquen AbstractHandler pueden tambien pasar el Next para que se recorran el resto de los handlers.
        /// </summary>
        /// <value>Se guarda el next handler.</value>
        private IHandler Next { get; set; }

        /// <summary>
        /// Recibe una cadena, siempre en formato string.
        /// </summary>
        public EntaradaDeLaCadena Input = Singleton<LeerConsola>.Instance;

        /// <summary>
        /// Se envia la cadena recibida tal como está o con algun tipo de cambio implicito o explicito.
        /// </summary>
        public IFormatoSalida Output = Singleton<Traductor>.Instance;

        /// <summary>
        /// El metodo se fija si no hay ningun comando apuntando al handler. si no hay se pasa al siguiente.
        /// </summary>
        /// <param name="mensaje">El emensaje escrito por el usuario.</param>
        public virtual string Handle(Mensaje mensaje)
        {
            if (this.Next != null)
            {
                return this.GetNext().Handle(mensaje);
            }
            return null;
        }

        /// <summary>
        /// Setter para el siguiente handler en la cadena.
        /// </summary>
        /// <param name="handler">Se recibe por parámetro el siguiente handler.</param>
        /// <returns>retorna el handler.</returns>
        public virtual IHandler SetNext(IHandler handler)
        {
            this.Next = handler;
            return handler;
        }

        /// <summary>
        /// Getter para el siguiente handler en la cadena.
        /// </summary>
        /// <returns>retorna el handler que sigue.</returns>
        public virtual IHandler GetNext()
        {
            return this.Next;
        }
    }
}