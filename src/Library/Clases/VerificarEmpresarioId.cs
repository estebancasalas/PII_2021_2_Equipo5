using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// La clase VerificarEmpresarioID tiene la responsabilidad de verificar si el id está registrado en alguna empresa.
    /// </summary>
    public class VerificarEmpresarioId
    {
        /// <summary>
        /// Método verificar recibe como parámetro un id y recorre la lista de empresas buscando algún empresario con ese id.
        /// </summary>
        /// <param name="id">id del empresario de tipo entero.</param>
        /// <returns></returns>
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