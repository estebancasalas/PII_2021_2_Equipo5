namespace Library
{
    /// <summary>
    /// Clase que modela un usuario no registrado en el bot.
    /// Depende de la abstracción IUsuario para cumplir con el principio DIP.
    /// El objetivo de esta clase es proveer una forma de almacenar el Id y Estado de la conversación de usuarios que están.
    /// interactuando con el bot pero aún no se han registrado como empresario o emprendedor.
    /// Instancias de este objeto son almacenadas en ListaDeUsiarios y, a medida que completan el registro, irán siendo removidas de la
    /// lista.
    /// </summary>
    public class Usuario : IUsuario
    {
        /// <summary>
        /// Inicializa una nueva instancia de Usuario.
        /// </summary>
        /// <param name="id">Id del usuario.</param>
        /// <param name="estado">Estado del usuario.</param>
        public Usuario(long id, EstadoUsuario estado)
        {
            this.Id = id;
            this.Estado = estado;
            ListaDeUsuario listaUsuario = new ListaDeUsuario();
            listaUsuario.Add(this);
        }

        /// <summary>
        /// Obtiene el Id del usuario.
        /// </summary>
        /// <value>Id del usuario.</value>
        public long Id { get; }

        /// <summary>
        /// Obtiene o Establece el valor del Estado.
        /// </summary>
        /// <value>EstadoUsuario que contiene el handler y el paso del mismo en el que se encuentra.</value>
        public EstadoUsuario Estado { get; set; }
    }
}