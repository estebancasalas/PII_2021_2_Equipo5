namespace Library
{
    /// <summary>
    /// Clase que modela un usuario no registrado en el bot.
    /// Depende de la abstracción IUsuario, para que clases como ListaDeUsuario no dependan de una clase concreta (DIP).
    /// El objetivo de esta clase es proveer una forma de almacenar el Id y Estado de la conversación de usuarios que están
    /// interactuando con el bot pero aun no se han registrado como empresario o emprendedor.
    /// Instancias de este objeto son almacenadas en ListaDeUsiarios y, a medida que completan el registro, iran siendo removidas de la
    /// lista.
    /// </summary>
    public class Usuario : IUsuario
    {
        /// <summary>
        /// Inicializa una nueva instancia de Usuario.
        /// </summary>
        /// <param name="id">Id de tipo long.</param>
        /// <param name="estado">Estado de tipo EstadoUsuario.</param>
        public Usuario(long id, EstadoUsuario estado)
        {
            this.Id = id;
            this.Estado = estado;
        }

        /// <summary>
        /// Obtiene el Id del usuario.
        /// </summary>
        /// <value>Propiedad que almacena el id del usuario.</value>
        public long Id { get; }

        /// <summary>
        /// Obtiene o Establece el valor de Estado.
        /// </summary>
        /// <value>Propiedad de tipo EstadoUsuario que contiene el handler y el paso del mismo en el que se encuentra.</value>
        public EstadoUsuario Estado { get; set; }
    }
}