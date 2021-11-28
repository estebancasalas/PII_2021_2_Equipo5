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
        /// Obtiene o establece atributo donde se guarda el resultado.
        /// </summary>
        private string Resultado { get; set; }

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
<<<<<<< HEAD
                VerHistorial historial = new VerHistorial();
                this.Resultado = historial.EjecutarComando(mensaje.Id);
<<<<<<< HEAD
                Output.PrintLine($"{this.Resultado}\n");
=======
                this.Output.PrintLine(this.Resultado);
>>>>>>> b3c1787aa5c2fae09ec6b49d3133773d300b81e2
                return this.TextResult.ToString();
                
=======
                ListaTransacciones listaTransacciones = new ListaTransacciones();
                List<IConversorTexto> listaTexto = new List<IConversorTexto>();
                List<Transaccion> transacciones = listaTransacciones.Buscar(mensaje.Id);
                foreach (Transaccion transaccion in transacciones)
                {
                    listaTexto.Add(transaccion);
                }

                IMostrar conversor = new ListaTransacciones();
                this.TextResult = conversor.Mostrar(listaTexto);
>>>>>>> 4a0edb3b1935ffca5d9bb6f5546c37a6e83b61a7
            }

            return this.GetNext().Handle(mensaje);
        }
    }
}