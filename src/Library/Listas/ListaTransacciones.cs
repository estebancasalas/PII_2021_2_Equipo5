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

        public string ConvertToJson()
        {
            return JsonSerializer.Serialize(this);
        }
        public void LoadFromJson(string json)
        {
            ListaTransacciones listaTrans = new ListaTransacciones();
            listaTrans = JsonSerializer.Deserialize<ListaTransacciones>(json);
            this.Transacciones = listaTrans.Transacciones;
        }
    }

}