using System.Collections.Generic;
using System;

namespace Library
{
    /// <summary>
    /// La clase BuscarEmprendedor se encarga de buscar un emprendedor en la lista de emprendedores.
    /// Creada por el patrón SRP ya que hay clases que necesitan conocer un emprendedor en base a su nombre.
    /// </summary>
    public class BuscarEmprendedor
    {

        /// <summary>
        /// Método Buscar, recorre la lista de emprendedores y retorna el emprendedor deseado.
        /// </summary>
        /// <param name="nombre">Nombre del emprendedor que se desea buscar.</param>
        /// <returns></returns>
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