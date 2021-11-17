using System;
using System.Collections.Generic;


namespace Library
{
    public class BuscarEmpresaId
    {
        /// <summary>
        /// Método Buscar, recorre la lista de empresas y retorna la empresa deseada.
        /// </summary>
        /// <param name="id">id de la empresa deseada</param>
        /// <returns></returns>
        public Empresa Buscar(int id)
        {
            List<Empresa> lista = Singleton<ListaEmpresa>.Instance.Empresas;
            Empresa empresa = lista.Find(x => x.ListaIdEmpresarios.Contains(id));
            return empresa;
        }
    }
}