using System.Collections.Generic;
using System;

namespace Library
{
    
    /// <summary>
    /// La clase BuscarEmpresa se encarga de buscar un empresa en la lista de empresas.
    /// Creada por el patrón SRP ya que hay clases que necesitan conocer una empresa en base a su nombre.
    /// </summary>
    public class BuscarEmpresa : AbstractBuscar
    {
        
        /// <summary>
        /// Método Buscar, recorre la lista de empresas y retorna la empresa deseada.
        /// </summary>
        /// <param name="nombre">Nombre de le empresa</param>
        /// <returns></returns>
        public Empresa Buscar(string nombre)
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
