using System;
using System.Text;

namespace Library
{
    public class EmpresaNombreHandler : IHandler
    {
        public void Handle(Mensaje mensaje)
        {
            if (!mensaje.Text.Contains('/'))
            {
                Empresa.nombreDeLaEmpresa = mensaje;
            }
            else
            {
                this.Next.Handle(mensaje);
            }
        }
    }
}