using System.Collections.Generic;

namespace Library
{
    ///<summary>
    /// Interfaz que contiene los datos utilizados por empresas y emprendedores.
    /// Al ser una interfaz, se busca (a través del principio LSP) tener un programa que cumpla con el
    /// principio OCP. Esto se logra al tener clases que implementen la interfaz, permitiendo extender
    /// las capacidades del programa sin modificarlo. Se extienden al agregar otras clases que implementen
    /// la interfaz y sustituyendo en el programa principal.
    ///</summary>

    public interface IUsuario
    {
        /// <summary>
        /// Nombre de la empresa o emprendedor.
        /// </summary>
        /// <value></value>
        string Nombre {get; set;}
        /// <summary>
        /// Rubro de la empresa o emprendedor.
        /// </summary>
        /// <value></value>
        string Rubro {get; set;} 
        /// <summary>
        /// Ubicación de la empresa o emprendedor.
        /// </summary>
        /// <value></value>
        string Ubicacion {get; set;}
    }
}