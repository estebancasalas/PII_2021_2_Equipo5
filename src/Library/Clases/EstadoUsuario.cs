namespace Library
{
    /// <summary>
    /// Clase que modela el estado en el que se encuentra un usuario. El estado refiere dentro de los
    /// handlers, ya que algunos handlers tienen varios pasos en su ejecución y es necesario ver en qué
    /// paso se encuentra el usuario.
    /// </summary>
    public class EstadoUsuario
    {
        /// <summary>
        /// Handler que se está ejecutando.
        /// </summary>
        public IHandler handler;
        /// <summary>
        /// Paso en el que se encuentra. Se modela con un número entero.
        /// </summary>
        public int step;
        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public EstadoUsuario()
        {
            this.handler = new NullHandler();
            this.step = 0;
        }
    }   
}