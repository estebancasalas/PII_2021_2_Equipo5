// -----------------------------------------------------------------------
// <copyright file="EmpresaCantidadTrabajdores.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    /// <summary>
    /// Handler que muestra la cantidad de trabajadores que hay en una empresa. Implementa IHandler
    /// porque no interactúa con el usuario, solo muestra en pantalla.
    /// </summary>
    public class EmpresaCantidadTrabajadores : AbstractHandler // devuelve cantidad de trabajadores.
    {
        /// <summary>
        /// Gets or sets siguiente Handler en la cadena.
        /// </summary>
        /// <value>Guarda el handler que sigue.</value>
        public IHandler Next { get; set; }

        /// <summary>
        /// Método que evalúa el mensaje. Busca la empresa y muestra la cantidad de trabajadores que tiene.
        /// </summary>
        /// <param name="mensaje">Contiene el Id con el que se encuentra la empresa deseada.</param>
        public override void Handle(Mensaje mensaje)
        {
            if (mensaje.Text.ToLower() == "/cantidadtrabajadores")
            {
                List<Empresa> lista = Singleton<ListaEmpresa>.Instance.Empresas;
                int i = 0;
                int j = 0;
                bool notfound = false;
                while (i < lista.Count && !notfound)
                {
                    while (j < lista[i].ListaEmpresarios.Count && lista[i].ListaEmpresarios[j].Id != mensaje.Id)
                    {
                        j++;
                    }

                    if (j >= lista[i].ListaEmpresarios.Count)
                    {
                        i++;
                        j = 0;
                    }
                    else
                    {
                        notfound = true;
                    }
                }

                Console.WriteLine($"La cantidad de trabajadores de la empresa es: {lista[i].ListaEmpresarios.Count}");
            }

            ListaDeUsuario listaUsuario = new ListaDeUsuario();
            int indice = listaUsuario.Buscar(mensaje.Id);
            EstadoUsuario estado = listaUsuario.ListaUsuarios[indice].Estado;
            estado = new EstadoUsuario();
            this.GetNext().Handle(mensaje);
        }
    }
}