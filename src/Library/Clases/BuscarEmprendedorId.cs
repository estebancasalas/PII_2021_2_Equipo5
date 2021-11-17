using System;
using System.Collections.Generic;

namespace Library
{
    
    /// <summary>
    /// Clase para buscar un emprendedor por su id. Cumple con SRP, ya que existe una clase que conoce
    /// todas las instancias de emprendedor pero no tiene la responsabilidad de buscar.
    /// </summary>
    public class BuscarEmprendedorId : AbstractBuscar  
    {
        
        /// <summary>
        /// Método que busca un emprendedor por su Id.
        /// </summary>
        /// <param name="id">Id para buscar el emprendedor</param>
        /// <returns></returns>
        public Emprendedor Buscar(int id)
        {
            List<Emprendedor> lista = Singleton<ListaEmprendedores>.Instance.Emprendedores;
            Emprendedor resultado = lista.Find(x => x.Id == id);
            return resultado;
        }
    }
}