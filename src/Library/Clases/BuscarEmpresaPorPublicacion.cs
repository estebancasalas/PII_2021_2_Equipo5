using System;
using System.Collections.Generic;

namespace Library
{
    
    /// <summary>
    /// Clase que sirve para buscar empresas. Cumple con SRP, ya que hay una clase encargada de
    /// conocer todas las empresas que no tiene la responsabilidad de buscarlas.
    /// </summary>
    public class BuscarEmpresaPorPublicacion : AbstractBuscar
    {
        
        /// <summary>
        /// Método para buscar una empresa a partir de una publicación.
        /// </summary>
        /// <param name="nombrePublicacion">Se pasa el nombre de la publicación para buscar la empresa.</param>
        /// <returns></returns>
        public Empresa Buscar(string nombrePublicacion)
        {
            int i = 0;
            while ( i< RegistroPublicaciones.Activas.Count && RegistroPublicaciones.Activas[i].Titulo != nombrePublicacion)
            {
                i++;
            }
            if (i > RegistroPublicaciones.Activas.Count)
            {
                return null;
            }
            else
            {
            int j = 0;
            while (j<ListaEmpresa.Empresas.Count && ListaEmpresa.Empresas[i].Nombre !=RegistroPublicaciones.Activas[i].NombreEmpresa)
            {
                j++;
            }
            return ListaEmpresa.Empresas[j];
            }
        }
    }
}