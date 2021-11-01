using System;

namespace Library
{
    public class VerificarInvitacion
    {
        public bool valido;
        
        public VerificarInvitacion(string invitacion)
        {
             if (ListaInvitaciones.Invitaciones.Contains(invitacion))
            {
                valido = true;
            }
            else
            {
                valido = false;
            }
        }
    }
}