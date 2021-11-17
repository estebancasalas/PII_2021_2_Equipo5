using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Clase que contiene una lista en la cual están todas las empresas. 
    /// Cumple con el principio SRP ya que su única responsabilidad es conocer los empresas.
    /// </summary>
    public class ListaEmpresa
    {
        /// <summary>
        /// Lista que contiene todas las empresas registradas.
        /// </summary>
        /// <returns></returns>
        public List<Empresa> Empresas = Singleton<List<Empresa>>.Instance; 

        public bool Verificar(int id)
        {
            return Empresas.Find(x => x.ListaIdEmpresarios.Contains(id)) != null;
        }
        public void Add(Empresa empresa)
        {
            this.Empresas.Add(empresa);
        }
    }
}