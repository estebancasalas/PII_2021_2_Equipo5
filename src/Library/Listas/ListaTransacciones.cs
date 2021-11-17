using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Library
{
    /// <summary>
    /// Clase que se encarga de conocer todas las transacciones que se realizan 
    /// de una empresa a un emprendedor o viceversa. 
    /// </summary>
    public class HistorialTransacciones: IJsonConvertible
    {
        /// <summary>
        /// Transacciones es quien tiene la lista con los objetos de la clase Transaccion. 
        /// </summary>
        /// <returns></returns>
<<<<<<< HEAD
        public static List <Transaccion> Transacciones = Singleton<List<Transaccion>>.Instance;
        public string ConvertToJson()
        {
            return JsonSerializer.Serialize(this);
        }
        public void LoadFromJson(string json)
        {
            ListaAdminastradores listaTrans = new ListaAdminastradores();
            listaTrans = JsonSerializer.Deserialize<ListaAdminastradores>(json);
=======
        public List <Transaccion> Transacciones = Singleton<List<Transaccion>>.Instance;
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
>>>>>>> e2afae5dc9bdaa4d1226ed589788ac2b4ddaf4d7
        }
    }

}