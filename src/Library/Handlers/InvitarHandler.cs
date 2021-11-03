using System;
using System.Text;

namespace Library
{
    /// <summary>
    /// Handler para crear una invitacion. Implementa AbstractHandler porque la interacción es
    /// con el usuario.
    /// </summary>

    public class InvitarHandler : AbstractHandler
    {
        public string nombre;
        public string ubicacion;
        public string rubro;
        public string token;
        /// <summary>
        /// Método para invitar a un usuario. Pide el nombre de un usuario y crea una invitación 
        /// para el mismo?
        /// </summary>
        /// <param name="mensaje"></param>
        public void Handle(Mensaje mensaje)
        {
            if (mensaje.Text == "/crearinvitacion")
            {
                bool notfound = true;
                int i = 0;
                while (notfound && i<ListaAdminastradores.administradores.Count)
                {
                    if (ListaAdminastradores.administradores[i].Id == mensaje.Id)
                    {
                        notfound = false;
                        //nombre = Input.GetInput("nombre empresa");
                        //ubicacion = Input.GetInput("ubicacion de la empresa");
                        //rubro = Input.GetInput("rubro de la empresa");
                        //token = Input.GetInput("Codigo de invitacion");
                        ListaAdminastradores.administradores[i].CrearInvitacion(nombre, ubicacion, rubro, token);
                    }
                    else
                    {
                        i++;
                    }
                }
            }

        }
    }
}