using System;

namespace Library
{
    public class VerificarInvitacion
    {
        public bool valido;
        
        public VerificarInvitacion(string invitacion)
        {
             if (ListaInvitaciones.ListInvitaciones.Contains(invitacion))
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