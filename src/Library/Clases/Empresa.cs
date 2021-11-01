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
        public List<int> ListaIdEmpresarios {get;}
        public string NombreDeLaEmpresa {get;}
        public string Ubicacion {get;}
        public string Rubro {get;}

        public Empresa(string nombre, string ubicacion, string rubro)
        {
            this.ListaIdEmpresarios = new List<int>();
            this.NombreDeLaEmpresa = nombre;
            this.Ubicacion = ubicacion;
            this.Rubro = rubro;

            // borrar ---> "this.listaIdEmpresarios = new List<int>();" 


        }
    }
}