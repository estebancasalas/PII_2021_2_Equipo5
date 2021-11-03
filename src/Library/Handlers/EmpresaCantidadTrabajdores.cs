using System;
using System.Text;

namespace Library
{
    /// <summary>
    /// Handler que muestra la cantidad de trabajadores que hay en una empresa. Implementa IHandler
    /// porque no interactúa con el usuario, solo muestra en pantalla.
    /// </summary>
    public class EmpresaCantidadTrabajadores : IHandler //devuelve cantidad de trabajadores
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
            int i = 0;
            while (i < ListaEmpresa.Empresas.Count && ListaEmpresa.Empresas[i].ListaIdEmpresarios[0] != mensaje.Id)
            {
                i = i + 1;
            }
            Console.WriteLine($"La cantidad de trabajadores de la empresa es: {ListaEmpresa.Empresas[i].ListaIdEmpresarios.Count}");
            mensaje.Text = Console.ReadLine();
            this.Next.Handle(mensaje);
        }
    }
}