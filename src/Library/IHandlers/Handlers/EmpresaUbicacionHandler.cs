using System;
using System.Text;

namespace Library
{
    public class EmpresaUbicacionHandler : IHandler
    {
        public void Handle(Mensaje mensaje)
        {
            if (!mensaje.Text.Contains('/'))
            {
                Empresa.ubicacion = mensaje;
            }
            else
            {
                this.Next.Handle(mensaje);
            } 
        }
    }
}