using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// ListaAdministradores es quien se encarga de tener la lista con todos los 
    /// Administradores registrados. 
    /// Se cumple principio SRP ya que libra al administrador de tener que crearse a él mismo 
    /// y al mismo tiempo conocer todos los Administradores registrados. 
    /// </summary>
    public class ListaAdminastradores
    {
        /// <summary>
        /// Lista que contiene todos los administradores registrados.
        /// </summary>
        /// <returns></returns>
        public static List<Administrador> administradores = new List<Administrador>();

    }
}