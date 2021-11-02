using System; 

  
namespace Library
{
    /// <summary>
    ///IEntradaDeLaCadena y IEntradaInt cumplen con el patrón de ISP ya que se utilizan interfaces chicas para implementar solo el comportamiento
    ///que las clases necesiten, para de esa forma no acumular todo en IFormatoDeEntrada. 
    ///Cumple también con el principio DIP ya que la comunicación de los mismos es con las clases de alto nivel.
    /// </summary>
    public interface IEntradaInt : IFormatoDeEntrada
    {
        /// <summary>
        /// El GetInput es método el cúal despliega un mensaje en consola y recibe su respuesta. 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        int GetInput (string message);
    }
}