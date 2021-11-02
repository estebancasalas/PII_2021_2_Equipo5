using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// ListaCodigosValidos es quien se encarga de tener la lista con todos los 
    /// códigos válidos para registrar una empresa. 
    /// Se cumple principio SRP ya que libra al administrador de tener que crear los
    /// códigos y conocerlos. 
    /// </summary>
    public  class ListaCodigosValidos
    {
        /// <summary>
        /// Lista con todos los códigos válidos para registrar una empresa.
        /// </summary>
        /// <returns></returns>
        public static List<string> CodigosValidos = new List<string> (); 
    
    }





}