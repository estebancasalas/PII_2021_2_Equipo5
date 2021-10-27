using System;
// IEntradaDeLaCadena y IEntradaInt cumplen con el patrón de ISP ya que se utilizan interfaces chicas para implementar solo el comportamiento
//que las clases necesiten, para de esa forma no acumular todo en IFormatoDeEntrada. 
namespace Library
{
    public interface IEntaradaDeLaCadena : IFormatoDeEntrada
    {
        string GetInput (string message);
    }

}