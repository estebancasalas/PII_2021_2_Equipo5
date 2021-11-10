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
        /// Guarda el id de el administrador al registrarse. 
        /// </summary>
        /// <value></value>
        public int Id { get; set; }
        
        /// <summary>
        /// Guarda el nombre que pone el administrador al registrarse 
        /// </summary>
        /// <value></value>
        public string Nombre { get; set; }
        
        /// <summary>
        /// Constructor de la clase Administrador.
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Nombre"></param>
        public Administrador(int Id, string Nombre)
        {
            this.Id = Id;
            this.Nombre = Nombre;
            ListaAdminastradores.Administradores.Add(this);
        }
        
        /// <summary>
        /// Método que crea el objeto empresa y su token de invitación.
        /// </summary>
        /// <param name="nombre">Nombre de la empresa.</param>
        /// <param name="ubicacion">Ubicación de la empresa.</param>
        /// <param name="rubro">Rubro de la empresa.</param>
        /// <param name="token">Token de invitación creada por el administrador.</param>   
        public void CrearInvitacion(string nombre, string ubicacion, string rubro, string token)
        {
            Empresa empresa = new Empresa(nombre, ubicacion, rubro, token);
            ListaInvitaciones.Invitaciones.Add(token);
        } 
    }
}
