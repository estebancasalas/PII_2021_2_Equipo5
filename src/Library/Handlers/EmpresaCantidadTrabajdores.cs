using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    /// <summary>
    /// Handler que muestra la cantidad de trabajadores que hay en una empresa. Implementa IHandler
    /// porque no interactúa con el usuario, solo muestra en pantalla.
    /// </summary>
    public class EmpresaCantidadTrabajadores : AbstractHandler //devuelve cantidad de trabajadores
    {
        /// <summary>
        /// Siguiente Handler en la cadena.
        /// </summary>
        /// <value></value>
        public IHandler Next {get; set;}
        /// <summary>
        /// Método que evalúa el mensaje. Busca la empresa y muestra la cantidad de trabajadores que tiene.
        /// </summary>
        /// <param name="mensaje">Contiene el Id con el que se encuentra la empresa deseada.</param>
        public void Handle(Mensaje mensaje)
        {
            if (mensaje.Text.ToLower() == "/cantidadtrabajadores")
            {
                List<Empresa> lista = Singleton<ListaEmpresa>.Instance.Empresas;
                int i = 0;
                while (i < lista.Count && lista[i].ListaIdEmpresarios.Contains(mensaje.Id))
                {
                    i = i + 1;
                }
                Console.WriteLine($"La cantidad de trabajadores de la empresa es: {lista[i].ListaIdEmpresarios.Count}");
                mensaje.Text = Console.ReadLine();
            }
            this.GetNext().Handle(mensaje);
        }
    }
}