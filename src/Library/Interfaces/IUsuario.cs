namespace ConsoleApplication
{
    ///<summary>
    /// Interfaz con los datos de usuario
    ///</summary>
    public interface IUsuario

    {
        /// <summary>
        /// id del usuario
        /// </summary>
        /// <value></value>
        string id {get; set;}
        /// <summary>
        /// nombre del usuario
        /// </summary>
        /// <value></value>
        string nombre {get; set;}


    }
}