using System.Collections.Generic;

namespace Library
{
    ///<summary>
    /// Interfaz con los datos de usuario
    ///</summary>
    public interface IUsuario

    {
        
        /// <summary>
        /// nombre del usuario
        /// </summary>
        /// <value></value>
        string Nombre {get; set;}
        string Rubro {get; set;} 
        string Ubicacion {get; set;}
    }

}