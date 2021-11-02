using System.Collections.Generic;

namespace Library
{
    /// <summary>
    ///Clase la cual contiene una lista en la cual estaran todas las empresas. Cumple con el patrón SRP ya que su única responsabilidad es conocer los empresas.
    /// </summary>
    public class ListaEmpresa
    {
        public static List<Empresa> Empresas = new List<Empresa>(); 
    }
    //Falta system.collection.generic
}