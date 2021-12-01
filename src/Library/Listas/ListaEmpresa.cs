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
    /// Clase que modela un contenedor de las empresas registradas.
    /// Tiene la responsabilidad de conocer todas las empresas, buscar una empresa a partir del Id de un empresario retornando
    /// un valor booleano, y tambien realizar la misma busqueda pero retornando un objeto de tipo Empresa.
    /// Depende de la Clase Empresa.
    /// Implementa IJsonConvertible para depender de una abstracción y no directamente de los metodos de Json.Serialization. (DIP).
    /// </summary>
    public class ListaEmpresa : IJsonConvertible
    {
        /// <summary>
        /// Obtiene o establece la lista que contiene las empresas registradas
        /// Utiliza el patrón de diseño Singleton para que el atributo sea único y global.
        /// No es readonly para facilitar el testing.
        /// </summary>
        /// <returns>Lista que contiene las empresas registradas.</returns>
        [JsonInclude]
        public List<Empresa> Empresas { get; set; } = Singleton<List<Empresa>>.Instance;

        /// <summary>
        /// Verifica que existe un empresario con ese id.
        /// Método creado por expert, ya que esta es la clase que conoce todas las empresas, y tambien tiene acesso a todos sus empresarios.
        /// </summary>
        /// <param name="id">Id del empresario a verificar.</param>
        /// <returns>Devuelve true si el id está registrado en alguna empresa, false en otro caso.</returns>
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
        /// <param name="id">Id de un empresario de la empresa.</param>
        /// <returns>Devuelve la empresa que contiene el id pasado por parámetro.</returns>
        public Empresa Buscar(long id)
        {
            if (this.Empresas.Count > 0 && this.Empresas != null)
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
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Se crea el método Add para añadir una Empresa a la Lista evitando duplicados.
        /// Se pone en esta clase para cumplir el patrón Expert ya que es la que conoce
        /// a todas las Empresas.
        /// </summary>
        /// <param name="empresa">Empresa que se va a agregar a la lista.</param>
        public void Add(Empresa empresa)
        {
            if (!this.Empresas.Contains(empresa))
            {
                this.Empresas.Add(empresa);
            }
        }

        /// <summary>
        /// Método que crea una instancia de esta clase y convierte su atributo Empresas en un string
        /// en formato json.
        /// </summary>
        /// <returns>String de objeto en formato json.</returns>
        public string ConvertToJson()
        {
            return JsonSerializer.Serialize(Singleton<List<Empresa>>.Instance);
        }

        /// <summary>
        /// Método que crea una instancia de esta clase y, a partir de un string en formato json, carga las empresas al
        /// atributo Empresas del objeto.
        /// </summary>
        /// <param name="json">String en formato json.</param>
        public void LoadFromJson(string json)
        {
            List<Empresa> listaEmprs = new List<Empresa>();
            listaEmprs = JsonSerializer.Deserialize<List<Empresa>>(json);
            this.Empresas = listaEmprs;
        }
    }
}