using System; 

// IEntradaDeLaCadena y IEntradaInt cumplen con el patrón de ISP ya que se utilizan interfaces chicas para implementar solo el comportamiento
//que las clases necesiten, para de esa forma no acumular todo en IFormatoDeEntrada. 
//Cumple también con el principio DIP ya que la comunicación de los mismos es con las clases de alto nivel.  
namespace Library
{
    public interface IEntradaInt : IFormatoDeEntrada
    {
        int GetInput (string message);
    }
}