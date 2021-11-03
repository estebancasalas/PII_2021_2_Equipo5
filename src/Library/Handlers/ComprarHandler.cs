using System;
using System.Text;

namespace Library
{
    /// <summary>
    /// Primer Handler de la Chain of Responsibility. Implementa AbstractHandler porque interactúa
    /// con el usuario.
    /// </summary>
    public class ComprarHandler : AbstractHandler
    {
        /// <summary>
        /// Método que verifica el mensaje. Actúa si el mensaje es "/start" y sino lo envía
        /// al siguiente Handler.
        /// </summary>
        /// <param name="mensaje">Mensaje recibido como parámetro. Contiene Id y el texto a evaluar.</param>
        public override void Handle (Mensaje mensaje)
        {
            //En vez de start, que se fije si no tiene / y si es la primera vez que escribe el usuario
            
            if (mensaje.Text == "/comprar")
            {
                string nombrePublicacion = Input.GetInput("Ingrese nombre de la publicación: "); 
                BuscarEmpresaPorPublicacion empresaBuscar = new BuscarEmpresaPorPublicacion(); //BuscarEmpresaPorPublicacion devuelve empresa
                Empresa empresa = empresaBuscar.Buscar(nombrePublicacion);  //creo objeto tipo empresa y le asigno el BuscarEmpresaPorPublicacion. Lo mismo emprendedor
                BuscarEmprendedorId emprendedorBuscar = new BuscarEmprendedorId();
                Emprendedor emprendedor = emprendedorBuscar.Buscar(mensaje.Id);
                double cantidad = Convert.ToDouble(Input.GetInput("Ingrese cantidad que desea comrpar: "));
                Transaccion transaccion = new Transaccion(empresa, emprendedor, nombrePublicacion, cantidad); 
                HistorialTransacciones.Transacciones.Add(transaccion);    
            }
            else
            {
                this.Next.Handle(mensaje);
            }
        }
    }
}