using System;
using System.Text;
using System.Collections.Generic;

namespace Library
{
    public class CrearPublicacionHandler : AbstractHandler
    {
        public override void Handle(Mensaje mensaje)
        {
            base.Handle(mensaje);
            if (mensaje.Text == "/CrearPublicación")
            {
                string nombreDelMaterial = Input.GetInput("Ingrese el material:");
                string categoria = Input.GetInput("Ingrese la categoria:");
                string unidad = Input.GetInput("Ingrese la unidad con la que cuantifica el material:");
                double costo = Convert.ToDouble(Input.GetInput("Ingrese el precio por unidad:"));
                double cantidad = Convert.ToDouble(Input.GetInput("Ingrese la cantidad:"));
                string habilitaciones = Input.GetInput("Ingrese habilitaciones necesarias para manipular el material:");
                Material material = new Material(nombreDelMaterial, costo, cantidad, unidad, habilitaciones, categoria);
                               
                string titulo = Input.GetInput("Ingrese el título:");
                string palabrasClave = Input.GetInput("Ingrese palabras claves separadas con ',' : ");
                string frecuencia = Input.GetInput("Ingrese frequencia de disponibilidad: ");
                string localizacion = Input.GetInput("Ingrese dónde se encuentra: ");
                CrearPublicacion publicacioncreada = new CrearPublicacion ();
                publicacioncreada.EjecutarComando(material, titulo, palabrasClave, frecuencia, localizacion);

            }
            else
            {
                this.Next.Handle(mensaje);
            }

        }
    }
}