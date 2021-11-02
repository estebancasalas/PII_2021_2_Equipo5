using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// /// Clase la cual contiene una lista en la cual estaran todos los emprendedores. Cumple con el patrón SRP ya que su única responsabilidad es conocer los emprendedores.
    /// </summary>
    public class ListaEmprendedores 
    {
        public static List<Emprendedor> Emprendedores = new List<Emprendedor>();
    }
    //Falta system.collection.generic
}