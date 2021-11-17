using System;
using System.Collections.Generic;


namespace Library
{
    public class BuscarEmpresaId
    {
        public Empresa Buscar(int id)
        {
            List<Empresa> lista = Singleton<ListaEmpresa>.Instance.Empresas;
            Empresa empresa = lista.Find(x => x.ListaIdEmpresarios.Contains(id));
            return empresa;
        }
    }
}