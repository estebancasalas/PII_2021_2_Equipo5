// -----------------------------------------------------------------------
// <copyright file="MostrarLista.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    /// <summary>
    /// Clase que sirve para mostrar una lista. Implementa la interfaz IMostrar para cumplir con DIP.
    /// </summary>
    public class MostrarLista : IMostrar
    {
        /// <summary>
        /// Método para mostrar la lista pasada como parámetro en pantalla.
        /// </summary>
        /// <param name="lista">Lista que se desea mostrar.</param>
        public void Mostrar(List<IStringbuilder> lista)
        {
            StringBuilder resultado = new StringBuilder();
            if (lista != null)
            {
                foreach (IStringbuilder item in lista)
                {
                    resultado.Append(item.ConvertToString());
                }
            }

            Console.WriteLine(resultado);
        }
    }
}