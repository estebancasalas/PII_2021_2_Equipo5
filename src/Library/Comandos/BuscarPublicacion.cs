using System;
using System.Collections.Generic;

namespace Library
{
    
    /// <summary>
    /// Pregunta por el tipo de búsqueda, pide a la clase correspondiente que la realice y
    /// devuelve una lista con las coincidencias.
    /// Además, se deberá preguntar por los parámetros necesarios para la búsqueda.
    /// En caso de una búsqueda por más de un tipo, se realizan todas las búsquedas y 
    /// devuelve las coincidencias comunes a todas las búsquedas.
    /// Esta clase además cumple con el principio SRP, ya que tiene como responsabilidad
    /// devolver una lista de publicaciones que cumplen con lo buscado, pero delega
    /// la responsabilidad de buscar a otras clases. 
    /// </summary>
    public class BuscarPublicacion
    {
        public string TipoBusqueda;
        public string Busqueda;
        public List<Publicacion> result = new List<Publicacion>();
        public BuscarPublicacion(string tipobusqueda, string busqueda)
        {
            this.TipoBusqueda = tipobusqueda;
            this.Busqueda = busqueda;
        }
        /// <summary>
        /// EjecutarComando se encarga de buscar una publicación por categoría, zona y 
        /// palabras claves. Luego las delega a cada una de las clases que se encargan de 
        /// búsqueda. 
        /// Finalmente, devuelve una lista con todas la publiaciones encontradas, de la búsqueda
        /// que se realizó. 
        /// </summary>
        /// <returns></returns>
        public List<Publicacion> EjecutarComando()
        {
                
            if (TipoBusqueda.ToLower() == "/categoria")
            {   
                BusquedaCategoria buscador = new BusquedaCategoria();
                result = buscador.Buscar(this.Busqueda);
            }
            //Pide la zona y realiza la busqueda
            else if (TipoBusqueda.ToLower() == "/ciudad" || TipoBusqueda.ToLower() == "/departamento")
            {
                BusquedaZona buscador = new BusquedaZona();
                result = buscador.Buscar(this.TipoBusqueda, this.Busqueda); 
            }
            //Pide las palabras clave y realiza la busqueda.
            else if (TipoBusqueda == "/palabrasclave")
            {
                BusquedaKeyWord buscador = new BusquedaKeyWord();
                result = buscador.Buscar(this.Busqueda);
            }
            else
            {
                Console.WriteLine("Usted no ingreso una opcion valida. Intente nuevamente.");
            }
            return result;
        }
    }
}