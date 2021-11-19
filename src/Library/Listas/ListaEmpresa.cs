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
        /// Utiliza el patrón de diseño Singleton para que el atributo sea único y global.
        /// </summary>
        /// <returns></returns>
        public List<Empresa> Empresas = Singleton<List<Empresa>>.Instance; 

        public bool Verificar(int id)
        {
            return Empresas.Find(x => x.ListaIdEmpresarios.Contains(id)) != null;
        }
        /// <summary>
        /// Método Buscar, recorre la lista de empresas y retorna la empresa deseada.
        /// </summary>
        /// <param name="id">id de la empresa deseada</param>
        /// <returns></returns>
        public Empresa Buscar(int id)
        {
            Empresa empresa = this.Empresas.Find(x => x.ListaIdEmpresarios.Contains(id));
            return empresa;
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
        /// <summary>
        /// El CovertToJson es el método por el cual se guardan los datos dentro de un archivo
        /// json.
        /// </summary>
        /// <returns></returns>
        public string ConvertToJson()
        {
            return JsonSerializer.Serialize(this);
        }
        /// <summary>
        /// LoadFromJson se encarga de cargar los datos guardados creando los objetos 
        /// a partir de el archivo json. 
        /// </summary>
        /// <param name="json"></param>
        public void LoadFromJson(string json)
        {
            ListaEmpresa listaEmprs = new ListaEmpresa();
            listaEmprs = JsonSerializer.Deserialize<ListaEmpresa>(json);
            this.Empresas = listaEmprs.Empresas;
        }
    }
}