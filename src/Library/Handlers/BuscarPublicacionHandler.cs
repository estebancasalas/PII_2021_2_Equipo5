using System;
using System.Text;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Este handler te dirrecciona a la clase BuscarPublicación, implementa AbstractHandler porque 
    /// interactúa con el usuario.
    /// </summary>
    public class BuscarPublicacionHandler : AbstractHandler
    {
        /// <summary>
        /// Atributo donde se guarda el resultado.
        /// </summary>
        string tipobusqueda;

        string busqueda;
        public List<Publicacion> result;
        /// <summary>
        /// Método para buscar en la lista de publicaciones.
        /// </summary>
        /// <param name="mensaje">Mensaje recibido como parámetro. Contiene Id y el texto a evaluar.</param>
        public override void Handle(Mensaje mensaje)
        {
            ListaDeUsuario listaUsuario = new ListaDeUsuario();
            if (mensaje.Text.ToLower() == "/buscarpublicacion")
            {
                int indice = listaUsuario.Buscar(mensaje.Id);
                EstadoUsuario estado = listaUsuario.ListaUsuarios[indice].Estado;
                estado.handler = this;
                switch (estado.step)
                {
                    case 0 :
                    Console.WriteLine("Que tipo de busqueda desea realizar? /categoria, /ciudad, /palabrasclave");
                    estado.step = estado.step + 1;
                    break;

                    case 1 :
                    this.tipobusqueda = mensaje.Text;
                    Console.WriteLine("Que desea buscar?");
                    estado.step = estado.step + 1;
                    break;

                    case 2:
                    this.busqueda = mensaje.Text;
                    BuscarPublicacion buscarPublicacion = new BuscarPublicacion(this.tipobusqueda, this.busqueda);
                    // hacer metodo mostrar en pantalla y agregarlo aca.
                    estado = new EstadoUsuario();
                    break;
                } 
            }               
            else
            {
                this.GetNext().Handle(mensaje);
            }             
            
        }
    }
}