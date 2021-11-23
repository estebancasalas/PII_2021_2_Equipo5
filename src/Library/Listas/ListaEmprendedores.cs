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
        /// <summary>
        /// El CovertToJson es el método por el cual se guardan los datos dentro de un archivo
        /// json.
        /// </summary>
        /// <returns></returns>
        public string ConvertToJson()
        {
            return JsonSerializer.Serialize(Singleton<List<Emprendedor>>.Instance);
        }
        /// <summary>
        /// LoadFromJson se encarga de cargar los datos guardados creando los objetos 
        /// a partir de el archivo json. 
        /// </summary>
        /// <param name="json"></param>
        public void LoadFromJson(string json)
        {
            List<Emprendedor> listaEmprs = new List<Emprendedor>();
            listaEmprs = JsonSerializer.Deserialize<List<Emprendedor>>(json);
            this.Emprendedores = listaEmprs;
        }
        /// <summary>
        /// Lista que contiene todos los emprendedores registrados.
        /// Utiliza el patrón de diseño Singleton para que el atributo sea único y global.
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
        /// <summary>
        /// Método que sirve para buscar un emprendedor por su id. Se incluye en esta clase ya que es la
        /// que conoce la información de todos los emprendedores (patrón Expert).
        /// </summary>
        /// <param name="id">Id del emprendedor a buscar</param>
        /// <returns></returns>
        public Emprendedor Buscar(long id)
        {
            return this.Emprendedores.Find(x => x.Id == id);
        }
    }
}