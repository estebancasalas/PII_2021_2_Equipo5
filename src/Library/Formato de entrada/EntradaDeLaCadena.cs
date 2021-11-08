using System;
using System.Collections.Generic;
 
namespace Library
{
    /// <summary>
    /// IEntradaDeLaCadena y IEntradaInt cumplen con el patrón de ISP ya que se utilizan interfaces chicas para implementar solo el comportamiento
    /// que las clases necesiten, para de esa forma no acumular todo en IFormatoDeEntrada.
    /// </summary>
    public abstract class EntaradaDeLaCadena 
    {
        /// <summary>
        /// El GetInput es método el cúal despliega un mensaje en consola y recibe su respuesta. 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public abstract string GetInput (string message);
    }
}