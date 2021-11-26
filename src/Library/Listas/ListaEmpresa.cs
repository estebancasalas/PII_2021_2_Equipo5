// -----------------------------------------------------------------------
// <copyright file="ListaEmpresa.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Library
{
    /// <summary>
    /// Clase que contiene una lista en la cual están todas las empresas.
    /// Cumple con el principio SRP ya que su única responsabilidad es conocer los empresas.
    /// </summary>
    public class ListaEmpresa : IJsonConvertible
    {

        /// <summary>
        /// Lista que contiene todas las empresas registradas.
        /// Utiliza el patrón de diseño Singleton para que el atributo sea único y global.
        /// </summary>
        /// <returns></returns>
        [JsonInclude]
        public List<Empresa> Empresas = Singleton<List<Empresa>>.Instance;
        /// <summary>
        /// Verifica que existe un empresario con ese id. Se incluye en esta clase ya que es la
        /// que conoce a todas las empresas (patrón Expert).
        /// </summary>
        /// <param name="id">Id del empresario a verificar.</param>
        /// <returns></returns>
        public bool Verificar(long id)
        {
            int i = 0;
            Empresario empresario = null;
            while (i < this.Empresas.Count && empresario == null)
            {
                if (this.Empresas[i].ListaEmpresarios != null)
                {
                    empresario = this.Empresas[i].ListaEmpresarios.Find(x => x.Id == id);
                }

                i++;
            }

            return empresario != null;
        }

        /// <summary>
        /// Método Buscar, recorre la lista de empresas y retorna la empresa deseada. Se incluye en esta
        /// clase ya que es la que conoce a todas las empresas (patrón Expert).
        /// </summary>
        /// <param name="id">id de la empresa deseada.</param>
        /// <returns></returns>
        public Empresa Buscar(long id)
        {
            int i = 0;
            Empresario empresario = null;
            while (i < this.Empresas.Count && empresario == null)
            {
                empresario = this.Empresas[i].ListaEmpresarios.Find(x => x.Id == id);
                i++;
            }
            return this.Empresas[i - 1];
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
            return JsonSerializer.Serialize(Singleton<List<Empresa>>.Instance);
        }

        /// <summary>
        /// LoadFromJson se encarga de cargar los datos guardados creando los objetos
        /// a partir de el archivo json.
        /// </summary>
        /// <param name="json"></param>
        public void LoadFromJson(string json)
        {
            List<Empresa> listaEmprs = new List<Empresa>();
            listaEmprs = JsonSerializer.Deserialize<List<Empresa>>(json);
            this.Empresas = listaEmprs;
        }
    }
}