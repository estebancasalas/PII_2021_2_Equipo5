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
            ListaAdminastradores listaEmprs = new ListaAdminastradores();
            listaEmprs = JsonSerializer.Deserialize<ListaAdminastradores>(json);
        }
        public void Add(Empresa empresa)
        {
            this.Empresas.Add(empresa);
        }
    }
}