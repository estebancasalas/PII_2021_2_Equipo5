using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Pregunta por el tipo de busqueda, pide a la clase correspondiente que la realice y devuelve una lista con las coincidencias.
    /// Ademas, se debera preguntar por los parametros necesarios para la busqueda.
    /// En caso de una busqueda por mas de un tipo, se realizan todas las busquedas y de devuelve las coincidencias comunes a todas las busquedas.
    /// </summary>
    public class BuscarPublicacion //: IComandos
    {
        public string nombre { get; set;}
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
                    string flag = ""; //Puede inicializarse una unica vez fuera de los if?
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
                    Console.WriteLine("Ingresar zona.");
                    string zona = Console.ReadLine();
                    BusquedaZona buscador = new BusquedaZona();
                    result = buscador.Buscar(zona);
                    opcionValida = true;
                }
                //Pide las palabras clave y realiza la busqueda.
                else if (mensaje == "3")
                {
                    string flag = ""; //Puede inicializarse una unica vez fuera de los if?
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