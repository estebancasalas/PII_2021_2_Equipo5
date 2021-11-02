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
        /// EjecutarComando se encarga de buscar una publicación por categoría, zona y 
        /// palabras claves. Luego las delega a cada una de las clases que se encargan de 
        /// búsqueda. 
        /// Finalmente, devuelve una lista con todas la publiaciones encontradas, de la búsqueda
        /// que se realizó. 
        /// </summary>
        /// <returns></returns>
        public List<Publicacion> EjecutarComando()
        {
            List<Publicacion> result = new List<Publicacion>();
            bool opcionValida = false;
            while (!opcionValida)
            {
                Console.WriteLine("Que tipo de busqueda desea realizar?\n1-Categoria\n2-Zona\n3-Palabras Clave");
                string mensaje = Console.ReadLine();
                //Pide las categorias y realiza la busqueda
                if (mensaje == "1")
                {   
                    string flag = ""; 
                    List<string> categorias = new List<string>();
                    while (flag != "0")
                    {
                        categorias.Add(Console.ReadLine());
                    }
                    BusquedaCategoria buscador = new BusquedaCategoria();
                    result = buscador.Buscar(categorias);
                    opcionValida = true;
                }
                //Pide la zona y realiza la busqueda
                else if (mensaje == "2")
                {
                    Console.WriteLine("1-Buscar por cuidad.\n2-Buscar por departamento.");
                    string tipoZona = Console.ReadLine();
                    Console.WriteLine("Donde desea buscar?.");
                    string zona = Console.ReadLine();
                    BusquedaZona buscador = new BusquedaZona();
                    result = buscador.Buscar(tipoZona, zona); 
                    opcionValida = true;
                }
                //Pide las palabras clave y realiza la busqueda.
                else if (mensaje == "3")
                {
                    string flag = ""; 
                    List<string> palabras = new List<string>();
                    while (flag != "0")
                    {
                        palabras.Add(Console.ReadLine());
                    }
                    BusquedaKeyWord buscador = new BusquedaKeyWord();
                    result = buscador.Buscar(palabras);
                    opcionValida = true;
                }
                else
                {
                    Console.WriteLine("Usted no ingreso una opcion valida. Intente nuevamente.");
                }
            }
            return result;
        }
    }
}