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
        /// <summary>
        /// Nombre de la emrpesa.
        /// </summary>
        public string nombre;
        /// <summary>
        /// Ubicación de la empresa.
        /// </summary>
        public string ubicacion;
        /// <summary>
        /// Rubro de la empresa.
        /// </summary>
        public string rubro;
        /// <summary>
        /// Token de invitación.
        /// </summary>
        public string token;
        /// <summary>
        /// Método para invitar a un usuario. Pide el nombre de un usuario y crea una invitación 
        /// para el mismo?
        /// </summary>
        /// <param name="mensaje">Indica que se quiere crear una invitación</param>
        public override void Handle(Mensaje mensaje)
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
                        nombre = Input.GetInput("nombre empresa");
                        ubicacion = Input.GetInput("ubicacion de la empresa");
                        rubro = Input.GetInput("rubro de la empresa");
                        token = Input.GetInput("Codigo de invitacion");
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