using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Clase con los datos de la empresa. Incluye:
    /// -id (private string)
    /// -nombre (private string)
    /// -ubicacion (private string)
    /// -rubro (private string)
    /// </summary>
    public class Empresa
    {
        public List<int> listaIdEmpresarios {get;}
        private string nombreDeLaEmpresa {get;}
        private string ubicacion {get;}
        private string rubro {get;}

        public Empresa(string nombre, string ubicacion, string rubro)
        {
            this.listaIdEmpresarios = new List<int>();
            this.nombreDeLaEmpresa = nombre;
            this.ubicacion = ubicacion;
            this.rubro = rubro;

            // borrar ---> "this.listaIdEmpresarios = new List<int>();" 
        }
    }
}