// -----------------------------------------------------------------------
// <copyright file="HistorialHandler.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Library
{
    /// <summary>
    /// Handler para verificar el historial de un usuario. Implementa AbstractHandler porque
    /// interactúa con el usuario.
    /// </summary>
    public class HistorialHandler : AbstractHandler
    {
        /// <summary>
        /// Método que evalúa el mensaje. Si el mensaje es "/historial", el Handler le pide el nombre
        /// al usuario y devuelve el historial de compras/ventas con ese nombre. Si el mensaje es otro,
        /// se envía al siguiente Handler.
        /// </summary>
        /// <param name="mensaje">Indica que se quiere ver el historial.</param>
        /// <returns>El mensaje que el handler le envía al usuario.</returns>
        public override string Handle(Mensaje mensaje)
        {
            if (mensaje.Text.ToLowerInvariant() == "/historial")
            {
                ListaTransacciones listaTransacciones = new ListaTransacciones();
                List<IConversorTexto> listaTexto = new List<IConversorTexto>();
                List<Transaccion> transacciones = listaTransacciones.Buscar(mensaje.Id);
                foreach (Transaccion transaccion in transacciones)
                {
                    listaTexto.Add(transaccion);
                }

                IMostrar conversor = new ListaTransacciones();
                this.TextResult = conversor.Mostrar(listaTexto);
                return this.TextResult.ToString();
            }

            return this.GetNext().Handle(mensaje);
        }
    }
}