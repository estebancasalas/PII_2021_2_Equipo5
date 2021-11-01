
using System;

namespace Library
{
    class Administrador
    { 
        public string id {get; set;}
        public string nombre {get; set;}


        // Crear método para crear invitaciones. Que sea de tipo string y se agregue a la clase listaDeCodigos.
        public void CrearInvitacion(string nombre, string ubicacion, string rubro, string token)
        {
            Empresa empresa = new Empresa(nombre, ubicacion, rubro);
            ListaInvitaciones.Invitaciones.Add(token);
        } 
        // Administrador implementa IUsuario?


    }

}
