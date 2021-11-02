using System;

namespace Library
{   
    /// <summary>
    /// 
    /// Clase que modela el rol de administrador.
    /// Es el encargado de generar las invitaciones para las empresas.
    /// </summary>
    class Administrador
    { 
        public string id {get; set;}
        public string nombre {get; set;}
        /// <summary>
        /// Método que crea el objeto empresa y su token de invitación.
        /// </summary>
        /// <param name="nombre"></param>Nombre de la empresa.
        /// <param name="ubicacion"></param>Ubicación de la empresa.
        /// <param name="rubro"></param>Rubro de la empresa.
        /// <param name="token"></param>Token de invitación creada por el administrador.
        public void CrearInvitacion(string nombre, string ubicacion, string rubro, string token)
        {
            Empresa empresa = new Empresa(nombre, ubicacion, rubro);
            ListaInvitaciones.Invitaciones.Add(token);
        } 
    }

}
