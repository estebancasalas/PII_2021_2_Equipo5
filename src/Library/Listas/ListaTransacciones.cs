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

        public List<Transaccion> Buscar(int id)
        {
            List<Transaccion> resultado = new List<Transaccion>();
            foreach (Transaccion transaccion in this.Transacciones)
            {
                if (transaccion.Vendedor.ListaIdEmpresarios.Contains(id) || transaccion.Comprador.Id == id) 
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
            return JsonSerializer.Serialize(this);
        }
        /// <summary>
        /// LoadFromJson se encarga de cargar los datos guardados creando los objetos 
        /// a partir de el archivo json. 
        /// </summary>
        /// <param name="json"></param>
        public void LoadFromJson(string json)
        {
            ListaTransacciones listaTrans = new ListaTransacciones();
            listaTrans = JsonSerializer.Deserialize<ListaTransacciones>(json);
            this.Transacciones = listaTrans.Transacciones;
        }
    }

}