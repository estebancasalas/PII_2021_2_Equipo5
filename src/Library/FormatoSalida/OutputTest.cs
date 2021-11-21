namespace Library
{
    /// <summary>
    /// Clase utilizada en los tests, para poder mostrar texto en pantalla al usuario. 
    /// </summary>
    public class OutputTest : IFormatoSalida
    {
        /// <summary>
        /// Método encargado de mostrar en pantalla.
        /// </summary>
        /// <param name="line">Lo que se va a mostrar</param>
        /// <returns></returns>
        public string PrintLine(string line)
        {
            return line.ToString();
        }
    }
}