using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Library
{
    /// <summary>
    /// Clase la cual contiene una lista en la cual estaran todos los emprendedores. 
    /// Cumple con el principio SRP ya que su única responsabilidad es conocer los 
    /// emprendedores.
    /// </summary>
    public class ListaEmprendedores: IJsonConvertible
    {
        public string ConvertToJson()
        {
            return JsonSerializer.Serialize(this);
        }
        public void LoadFromJson(string json)
        {
            ListaEmprendedores listaEmprs = new ListaEmprendedores();
            listaEmprs = JsonSerializer.Deserialize<ListaEmprendedores>(json);
            this.Emprendedores = listaEmprs.Emprendedores;
        }
        /// <summary>
        /// Lista que contiene todos los emprendedores registrados.
        /// </summary>
        /// <returns></returns>
        public List<Emprendedor> Emprendedores = Singleton<List<Emprendedor>>.Instance;
        /// <summary>
        /// Se crea el método Add para añadir un Emprendedor a la ListaEmprendedores
        /// ya existente. 
        /// Se pone en esta clase para cumplir el patrón Expert ya que es la que conoce
        /// a todos los Emprendedores.
        /// </summary>
        /// <param name="emprendedor"></param>
        public void Add(Emprendedor emprendedor)
        {
            this.Emprendedores.Add(emprendedor);
        }
    }
}