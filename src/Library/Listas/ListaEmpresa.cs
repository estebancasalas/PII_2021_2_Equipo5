using System.Collections.Generic;
using System.Text.Json;

namespace Library
{
    /// <summary>
    /// Clase que contiene una lista en la cual están todas las empresas. 
    /// Cumple con el principio SRP ya que su única responsabilidad es conocer los empresas.
    /// </summary>
    public class ListaEmpresa: IJsonConvertible
    {
        /// <summary>
        /// Lista que contiene todas las empresas registradas.
        /// </summary>
        /// <returns></returns>
        public List<Empresa> Empresas = Singleton<List<Empresa>>.Instance; 

        public bool Verificar(int id)
        {
            return Empresas.Find(x => x.ListaIdEmpresarios.Contains(id)) != null;
        }
        public string ConvertToJson()
        {
            return JsonSerializer.Serialize(this);
        }
        public void LoadFromJson(string json)
        {
            ListaEmpresa listaEmprs = new ListaEmpresa();
            listaEmprs = JsonSerializer.Deserialize<ListaEmpresa>(json);
            this.Empresas = listaEmprs.Empresas;
        }
        /// <summary>
        /// Se crea el método Add para añadir una Empresa a la ListaEmpresa ya existente. 
        /// Se pone en esta clase para cumplir el patrón Expert ya que es la que conoce
        /// a todas las Empresas.
        /// </summary>
        /// <param name="empresa"></param>
        public void Add(Empresa empresa)
        {
            this.Empresas.Add(empresa);
        }
    }
}