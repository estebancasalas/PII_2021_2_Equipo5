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
        /// <summary>
        /// Contiene el tipo de búsqueda que se va a realizar
        /// </summary>
        public string TipoBusqueda;
        /// <summary>
        /// Lo que se desea buscar.
        /// </summary>
        public string Busqueda;
        /// <summary>
        /// Lista de coincidencias de la búsqueda.
        /// </summary>
        /// <returns></returns>
        public List<Publicacion> result = Singleton<List<Publicacion>>.Instance;
        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="tipobusqueda"></param>
        /// <param name="busqueda"></param>
        public BuscarPublicacion(string tipobusqueda, string busqueda)
        {
            this.TipoBusqueda = tipobusqueda;
            this.Busqueda = busqueda;
        }
        /// <summary>
        /// EjecutarComando se encarga de decidir qué tipo de búsqueda se va a realizar(categoría, zona y 
        /// palabras claves). Luego las delega a cada una de las clases que se encargan de 
        /// búsqueda, para cumplir con SRP. 
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
            else if (TipoBusqueda.ToLower() == "/ciudad")
            {
                BusquedaZonaCiudad buscador = new BusquedaZonaCiudad();
                result = buscador.Buscar(this.TipoBusqueda, this.Busqueda); 
            }
            /*
            else if (TipoBusqueda.ToLower() == "/departamento")
            {
                BusquedaZonaDepartamento buscador = new BusquedaZonaDepartamento();
                result = buscador.Buscar(this.TipoBusqueda, this.Busqueda);
            }
            */
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