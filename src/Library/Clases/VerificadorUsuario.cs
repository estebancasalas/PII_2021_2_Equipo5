using System;


namespace Library
{
    /// <summary>
    /// Esta clase tiene la responsabilidad de verificar si un id ya esta registrado.
    /// Creada por SRP, ya que colaborará con CrearUsuarioHandler
    /// </summary>
    public class VerificadorUsuario
    {
        bool found = false;

        /// <summary>
        /// Método que recorre las listas de empresas y emprendedore buscando un id. Si encuentra el id retorna true, en caso 
        /// contrario retorna false. 
        /// </summary>
        /// <param name="ubicacion"></param>Es el id que se desea saber si esta registrado o no. 
        /// <returns></returns>
        public bool EstaRegistrado(int id)
        {
            int i = 0;
            int j = 0;           
            while (!found && ListaEmpresa.Empresas.Count>i)
            {
                while (!found && ListaEmpresa.Empresas[i].ListaIdEmpresarios.Count>j)
                {
                    if (ListaEmpresa.Empresas[i].ListaIdEmpresarios[j] == id)
                    {
                        found = true;
                    }
                    else
                    {
                        j++;
                    }
                }
                j=0;
                i++;
            }
            i=0;
            while (!found && ListaEmprendedores.Emprendedores.Count>i)
            {
                if (ListaEmprendedores.Emprendedores[i].Id == id)
                {
                    found = true;
                }
                i++;
            }

            return found;
            
        }


    }
}