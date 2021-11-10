using System;

namespace Library
{
    
    /// <summary>
    /// Esta clase tiene la responsabilidad de verificar si un id ya esta registrado.
    /// Creada por SRP, para que CrearUsuarioHandler no tenga que verificar esto.
    /// </summary>
    public class VerificadorUsuario
    {

        /// <summary>
        /// Método que recorre las listas de empresas y emprendedore buscando un id. Si encuentra el id retorna true, en caso 
        /// contrario retorna false. 
        /// </summary>
        /// <param name="id">Es el id que se desea saber si esta registrado o no.</param> 
        /// <returns></returns>
        public bool EstaRegistrado(int id)
        {
            Empresa empresa = ListaEmpresa.Empresas.Find(x => x.ListaIdEmpresarios.Contains(id));      
            /*while (!found && ListaEmpresa.Empresas.Count>i)
            {
                if (ListaEmpresa.Empresas[i].ListaIdEmpresarios.Contains(id))
                {
                    found = true;
                }
                i++;
            }*/
            Emprendedor emprendedor = ListaEmprendedores.Emprendedores.Find(x => x.Id == id);
            //guardarlo en variable y fijarse que sea diferente de null 
            /*while (!found && ListaEmprendedores.Emprendedores.Count>i)
            {
                if (ListaEmprendedores.Emprendedores[i].Id == id)
                {
                    found = true;
                }
                i++;
            }*/
            if (empresa != null || emprendedor != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
//Find buscar 