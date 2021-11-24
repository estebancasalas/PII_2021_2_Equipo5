using System;
using System.Text;
using System.Collections.Generic;

namespace Library
{
    public class MostrarLista
    {
        public void Mostrar(List<IStringbuilder> lista)
        {
            StringBuilder resultado = new StringBuilder();
            foreach (IStringbuilder item in lista)
            {
                resultado.Append(item.ConvertToString());
            }
            Console.WriteLine(resultado);
        }
    }
}