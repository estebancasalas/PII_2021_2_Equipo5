using System.Collections.Generic;
using System;

namespace Library
{
    public class BuscarEmpresa
    {

        public Empresa Buscar (string nombre)
        {
            int i = 0; 
            while (i < ListaEmpresa.Empresas.Count)
            {
                if (ListaEmpresa.Empresas[i].Nombre == nombre) 
                {
                    return ListaEmpresa.Empresas[i]; 
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
