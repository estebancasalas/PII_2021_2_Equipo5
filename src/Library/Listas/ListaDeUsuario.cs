using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// ListaDeUsuario es quien se encarga de tener la lista con todos los 
    /// usuarios registrados, siendo los usuarios las empresas y emprendedores.  
    /// Se implementa esta lista con un tipo genérico para expandir los usos en otras clases.
    /// </summary>
    public class ListaDeUsuario
    {
        /// <summary>
        /// Lista que contiene a todos los ususarios.
        /// </summary>
        /// <returns></returns>
        public static List<int> IdUsuarios = Singleton<List<int>>.Instance; 

        public bool EstaRegistrado(int id)
        {
            return IdUsuarios.Contains(id);
        }
    }
    // Checkear si cuando se registran se agregan idSSS.
}