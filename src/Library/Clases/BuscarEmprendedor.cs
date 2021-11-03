using System.Collections.Generic;
using System;

namespace Library
{
    public class BuscarEmprendedor
    {

        public Emprendedor Buscar (string nombre)
        {
            int i = 0; 
            while (i < ListaEmprendedores.Emprendedores.Count)
            {
                if (ListaEmprendedores.Emprendedores[i].Nombre == nombre) 
                {
                    return ListaEmprendedores.Emprendedores[i]; 
                }
                else
                {
                    i++;
                }
            }
            return null; 
        }
    }
} 