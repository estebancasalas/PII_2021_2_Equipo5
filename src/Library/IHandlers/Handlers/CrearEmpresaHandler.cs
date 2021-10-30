using System;
using System.Text;
using System.Collections.Generic;

namespace Library
{
    public class CrearPublicacionHandler : AbstarctHandler
    {
        public override void Handle(Mensaje mensaje)
        {
            base.Handle(mensaje);
            if (mensaje.Text == "/CrearPublicación")
            {
                CrearPublicacion publicacioncreada = new CrearPublicacion ();
            }
            else
            {
                this.Next.Handle(mensaje);
            }

            Console.WriteLine("Indique rubro: ");
            rubro = Console.ReadLine();
            Empresa empresa = new Empresa(this.nombreDeLaEmpresa, this.ubicacion, this.rubro);
            ListaEmpresa.Empresas.Add(empresa);
            mensaje.Text = Console.ReadLine();
            this.Next.Handle(mensaje);

            // Cambiar nombre de la clase por crearempresahandler. Poner tipo strring a rubro.
        }
    }
}