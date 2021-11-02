using System;

namespace Library
{
    /// <summary>
    /// Esta clase se encarga de verificar que las invitaciones de los trabajadores de 
    /// la empresa son válidas. 
    /// Patrón SRP para que el Administrador solo tenga que crear la invitación, y que 
    /// al mismo tiempo no tenga que verificarla. 
    /// </summary>
    public class VerificarInvitacion
    {
        /// <summary>
        /// valido es el atributo que indica si la invitación es válida o no. 
        /// </summary>
        public bool valido;
        /// <summary>
        /// Es quien se encarga de verificar que la invitación pasada como parámetro sea
        /// válida o no. 
        /// Esto lo realiza recorriendo la lista con invitaciones válidas.
        /// </summary>
        /// <param name="invitacion"></param>
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