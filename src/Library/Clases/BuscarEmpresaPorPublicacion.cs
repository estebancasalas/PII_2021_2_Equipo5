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
            List<Publicacion> lista = Singleton<RegistroPublicaciones>.Instance.Activas;
            Publicacion publicacion = lista.Find(x => x.Titulo == nombrePublicacion);
            return publicacion.Vendedor;            
        }
    }
}