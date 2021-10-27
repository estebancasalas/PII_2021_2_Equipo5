using System;
using System.Text;

namespace Library
{
    public class EmpresaRubroHandler : IHandler
    {
        public void Handle(Mensaje mensaje)
        {
            if (!mensaje.Text.Contains('/'))
            {
                Empresa.rubro = mensaje;
            }
            else
            {
                this.Next.Handle(mensaje);
            }
        }
    }
}