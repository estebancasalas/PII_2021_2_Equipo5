// -----------------------------------------------------------------------
// <copyright file="ComprarHandler.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    /// <summary>
    /// Primer Handler de la Chain of Responsibility. Implementa AbstractHandler porque interactúa
    /// con el usuario.
    /// </summary>
    public class ComprarHandler : AbstractHandler
    {
        /// <summary>
        /// Método que verifica el mensaje. Actúa si el mensaje es "/start" y sino lo envía
        /// al siguiente Handler.
        /// </summary>
        /// <param name="mensaje">Mensaje recibido como parámetro. Contiene Id y el texto a evaluar.</param>
        public override string Handle(Mensaje mensaje)
        {
            // En vez de start, que se fije si no tiene / y si es la primera vez que escribe el usuario
            if (mensaje.Text.ToLower() == "/comprar")
            {
                string nombrePublicacion = this.Input.GetInput("Ingrese nombre de la publicación: ");
                Empresa empresa = BuscarEmpresaPorPublicacion.Buscar(nombrePublicacion);  // creo objeto tipo empresa y le asigno el BuscarEmpresaPorPublicacion. Lo mismo emprendedor
                ListaEmprendedores listemp = new ListaEmprendedores();
                Emprendedor emprendedor = listemp.Buscar(mensaje.Id);
                double cantidad = Convert.ToDouble(Input.GetInput("Ingrese cantidad que desea comrpar: "));
                Transaccion transaccion = new Transaccion(empresa, emprendedor, nombrePublicacion, cantidad);
                List<Transaccion> lista = Singleton<ListaTransacciones>.Instance.Transacciones;
                lista.Add(transaccion);
                return this.TextResult.ToString();
            }
            else
            {
                return this.GetNext().Handle(mensaje);
            }
        }
    }
}