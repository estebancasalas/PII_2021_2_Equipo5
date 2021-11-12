using System;
using System.Collections.Generic;


namespace Library
{
    public class BuscarEmpresaId
    {
        public Empresa Buscar(int id)
        {
            Empresa empresa = ListaEmpresa.Empresas.Find(x => x.ListaIdEmpresarios.Contains(id));
            return empresa;
        }
    }
}