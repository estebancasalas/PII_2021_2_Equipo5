using System;
using System.Text;

namespace Library
{
    public class EmpresaCantidadTrabajadores : IHandler //devuelve cantidad de trabajadores
    {
        public IHandler Next {get; set;}
        public void Handle(Mensaje mensaje)
        {
            int i = 0;
            while (i < ListaEmpresa.Empresas.Count && ListaEmpresa.Empresas[i].listaIdEmpresarios[0] != mensaje.Id)
            {
                i = i + 1;
            }
            Console.WriteLine($"La cantidad de trabajadores de la empresa es: {ListaEmpresa.Empresas[i].listaIdEmpresarios.Count}");
            mensaje.Text = Console.ReadLine();
            this.Next.Handle(mensaje);
        }
    }
}