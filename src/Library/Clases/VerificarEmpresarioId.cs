using System;
using System.Collections.Generic;

namespace Library
{
    public class VerificarEmpresarioId
    {
        public bool Verificar(int id)
        {
            int i = 0;
            while (i<ListaEmpresa.Empresas.Count)
            {
                if (ListaEmpresa.Empresas[i].ListaIdEmpresarios.Contains(id))
                {
                    return true;
                }
                else
                {
                    i++;
                }
            }
            return false;
        }
    }
}