using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Library
{
    /// <summary>
    /// Clase que se encarga de conocer todas las transacciones que se realizan 
    /// de una empresa a un emprendedor o viceversa. 
    /// </summary>
    public class ListaTransacciones: IJsonConvertible
    {
        /// <summary>
        /// Transacciones es quien tiene la lista con los objetos de la clase Transaccion.
        /// Utiliza el patrón de diseño Singleton para que el atributo sea único y global.
        /// </summary>
        /// <returns></returns>
        public List <Transaccion> Transacciones = Singleton<List<Transaccion>>.Instance;
        /// <summary>
        /// Se crea el método Add para añadir una Transaccion a la ListaTransacciones
        /// ya existente. 
        /// Se pone en esta clase para cumplir el patrón Expert ya que es la que conoce
        /// todas las transacciones que se realizan.
        /// </summary>
        /// <param name="transaccion"></param>
        public void Add(Transaccion transaccion)
        {
            this.Transacciones.Add(transaccion);
        }
        /// <summary>
        /// Método que devuelve una lista con todas las transacciones hechas con ese id. Se busca cumplir
        /// con Expert, ya que esta clase es la que contiene toda la información de las transacciones.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Transaccion> Buscar(int id)
        {
            List<Transaccion> resultado = new List<Transaccion>();
            ListaEmpresa lista = new ListaEmpresa();
            Empresa empresa = lista.Buscar(id);
            foreach (Transaccion transaccion in this.Transacciones)
            {
                if (transaccion.Vendedor == empresa || transaccion.Comprador.Id == id) 
                {
                    resultado.Add(transaccion);
                }
            }
            return resultado;
        }
        /// <summary>
        /// El CovertToJson es el método por el cual se guardan los datos dentro de un archivo
        /// json.
        /// </summary>
        /// <returns></returns>
        public string ConvertToJson()
        {
            return JsonSerializer.Serialize(Singleton<List<Transaccion>>.Instance);
        }
        /// <summary>
        /// LoadFromJson se encarga de cargar los datos guardados creando los objetos 
        /// a partir de el archivo json. 
        /// </summary>
        /// <param name="json"></param>
        public void LoadFromJson(string json)
        {
            List<Transaccion> listaTrans = new List<Transaccion>();
            listaTrans = JsonSerializer.Deserialize<List<Transaccion>>(json);
            this.Transacciones = listaTrans;
        }
    }

}