using System;
using System.Text;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Handler para crear una publicación. Implementa AbstractHandler porque interactúa
    /// con el usuario.
    /// </summary>
    public class CrearPublicacionHandler : AbstractHandler
    {
        /// <summary>
        /// Método que interpreta el mensaje. Si el mensaje es "/CrearPublicación", el método pide los
        /// datos de materiales y llama a la clase CrearMaterial para cumplir con el SRP. Luego, se
        /// llama a la clase CrearPublicacion por la misma razón.
        /// </summary>
        /// <param name="mensaje">Mensaje recibido como parámetro. Contiene Id y el texto a evaluar.</param>
        public override void Handle(Mensaje mensaje)
        {
            //base.Handle(mensaje);
            VerificarEmpresarioId verif = new VerificarEmpresarioId();
            if (mensaje.Text == "/CrearPublicación" && verif.Verificar(mensaje.Id))
            {
                string nombreDelMaterial = Input.GetInput("Ingrese el material:");
                string categoria = Input.GetInput("Ingrese la categoria:");
                string unidad = Input.GetInput("Ingrese la unidad con la que cuantifica el material:");
                double costo = Convert.ToDouble(Input.GetInput("Ingrese el precio por unidad:"));
                double cantidad = Convert.ToDouble(Input.GetInput("Ingrese la cantidad:"));
                string habilitaciones = Input.GetInput("Ingrese habilitaciones necesarias para manipular el material:");
                CrearMaterial materializador = new CrearMaterial();
                Material material = materializador.Crear(nombreDelMaterial, costo, cantidad, unidad, habilitaciones, categoria);
                               
                string titulo = Input.GetInput("Ingrese el título:");
                string palabrasClave = Input.GetInput("Ingrese palabras claves separadas con ',' : ");
                string frecuencia = Input.GetInput("Ingrese frequencia de disponibilidad: ");
                string localizacion = Input.GetInput("Ingrese dónde se encuentra: ");
                string nombreEmpresa = Input.GetInput("Ingrese nombre de la empresa: ");
                CrearPublicacion publicacioncreada = new CrearPublicacion ();
                publicacioncreada.EjecutarComando(material, titulo, palabrasClave, frecuencia, localizacion, nombreEmpresa);
            }
            else
            {
                this.Next.Handle(mensaje);
            }
        }
    }
}