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
    public class Empresa // : IUsuario
    {
        // public List <Transacciones> Transacciones = new List<Transacciones>();
        public List<int> listaIdEmpresarios {get;}
        public string nombreDeLaEmpresa {get;}
        public string ubicacion {get;}
        public string rubro {get;}

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