using System;

namespace Library
{   
    /// <summary>
    /// Clase que modela el rol de administrador.
    /// Es el encargado de generar las invitaciones para las empresas.
    /// </summary>
    public class Administrador
    { 
        /// <summary>
        /// Guarda el id de el administrador al registrarse 
        /// </summary>
        /// <value></value>
        public string Id {get; set;}
        /// <summary>
        /// Guarda el nombre que pone el administrador al registrarse 
        /// </summary>
        /// <value></value>
        public string Nombre {get; set;}
        /// <summary>
        /// Constructor de la clase Administrador
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Nombre"></param>
        public Administrador(string Id, string Nombre)
        {
            this.Id = Id;
            this.Nombre = Nombre;
        }
        /// <summary>
        /// Método que crea el objeto empresa y su token de invitación.
        /// </summary>
        /// <param name="nombre"></param>Nombre de la empresa.
        /// <param name="ubicacion"></param>Ubicación de la empresa.
        /// <param name="rubro"></param>Rubro de la empresa.
        /// <param name="token"></param>Token de invitación creada por el administrador.
               
        public void CrearInvitacion(string nombre, string ubicacion, string rubro, string token)
        {
            Empresa empresa = new Empresa(nombre, ubicacion, rubro, token);
            ListaInvitaciones.Invitaciones.Add(token);
        } 
    }

}
