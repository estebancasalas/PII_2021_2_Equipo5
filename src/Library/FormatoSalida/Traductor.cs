using System;

namespace Library
{
    /// <summary>
    /// Clase encargada de modelar un string para ser mostrado en pantalla. Implementa la interfaz
    /// IFormatoSalida ya que es una de las clases que muestra información en pantalla. 
    /// Al implementar una interfaz, es posible extender los usos sin modificar el programa principal ya que
    /// depende de una abstracción (patrón Polymorphism).
    /// </summary>
    public class Traductor : IFormatoSalida
    {
        /// <summary>
        /// Método encargado de modelar el string pasado como parámetro. Luego, lo muestra en pantalla.
        /// </summary>
        /// <param name="line">Lo que se modela para mostrar en pantalla</param>
        /// <returns></returns>
        public string PrintLine(string line)
        {
            string linea = "";
            int num = 0;
            while (num < line.Length)
            {
                if (line[num] == '#')
                {
                    Console.WriteLine($"{linea}");
                    linea = "";
                }
                else 
                {
                    linea = linea + line[num];
                }
                if (num + 1 == line.Length && (!line[num].Equals("#")))
                {
                    linea = linea + line[num];
                    Console.WriteLine($"{linea}");
                    linea = "";
                }
                num += 1;
            }
            return "No se utiliza";
        }
    }
}