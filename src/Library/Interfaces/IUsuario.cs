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
        string nombre {get; set;}
        string rubro {get; set;}
        string ubicacion {get; set;}

    }
}