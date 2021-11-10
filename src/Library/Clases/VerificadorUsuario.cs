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
            Emprendedor emprendedor = ListaEmprendedores.Emprendedores.Find(x => x.Id == id);
            return (empresa != null || emprendedor != null);
        }
    }
}