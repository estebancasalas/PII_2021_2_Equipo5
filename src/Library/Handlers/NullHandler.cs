// -----------------------------------------------------------------------
// <copyright file="NullHandler.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Library
{
    /// <summary>
    /// Handler vacío, para ser utilizado al final de la cadena y en tests.
    /// </summary>
    public class NullHandler : AbstractHandler
    {
        public override string Handle(Mensaje mensaje)
        {
            return "Lo siento, no puedo procesar ese mensaje.\nPara ver la lista de comandos ingrese /comandos.";
        }
    }
}