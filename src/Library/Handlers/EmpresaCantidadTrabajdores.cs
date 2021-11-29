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
        /// Gets or sets siguiente Handler en la cadena. Obtiene o establece.
        /// </summary>
        /// <value>Guarda el handler que sigue.</value>
        public IHandler HandlerNext { get; set; }

        /// <summary>
        /// Método que evalúa el mensaje. Busca la empresa y muestra la cantidad de trabajadores que tiene.
        /// </summary>
        /// <param name="mensaje">Contiene el Id con el que se encuentra la empresa deseada.</param>
        /// <returns>Retorna la respuesta a la petición del usuario.</returns>
        public override string Handle(Mensaje mensaje)
        {
            ListaEmpresa listaEmpresa = Singleton<ListaEmpresa>.Instance;
            ListaDeUsuario listaUsuario = Singleton<ListaDeUsuario>.Instance;
            int indice = listaUsuario.Buscar(mensaje.Id);
            EstadoUsuario estado = listaUsuario.ListaUsuarios[indice].Estado;
            if (mensaje.Text.ToLower() == "/cantidadtrabajadores" || estado.Handler == "/cantidadtrabajadores")
            {
                if (listaEmpresa.Verificar(mensaje.Id))
                {
                    this.TextResult = new StringBuilder();
                    List<Empresa> lista = Singleton<ListaEmpresa>.Instance.Empresas;
                    int i = 0;
                    bool notfound = true;
                    while (i < lista.Count && notfound)
                    {
                        Empresario empresario = lista[i].ListaEmpresarios.Find(x => x.Id == mensaje.Id);
                        if (empresario != null)
                        {
                            notfound = false;
                        }
                    }

                    this.TextResult.Append($"La cantidad de trabajadores de la empresa es: {lista[i].ListaEmpresarios.Count}");
                    estado.Step = 0;
                    estado.Handler = null;
                }
                else
                {
                    this.TextResult.Append("Lo siento, para utilizar este comando debe pertenecer a una empresa.");
                }

                return this.TextResult.ToString();
            }
            else
            {
                return this.GetNext().Handle(mensaje);
            }
        }
    }
}