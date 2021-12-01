// -----------------------------------------------------------------------
// <copyright file="BuscarPublicacion.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Pregunta por el tipo de búsqueda, pide a la clase correspondiente que la realice y
    /// devuelve una lista con las coincidencias.
    /// Además, se deberá preguntar por los parámetros necesarios para la búsqueda.
    /// En caso de una búsqueda por más de un tipo, se realizan todas las búsquedas y,
    /// devuelve las coincidencias comunes a todas las búsquedas.
    /// Esta clase además cumple con el principio SRP, ya que tiene como responsabilidad
    /// devolver una lista de publicaciones que cumplen con lo buscado, pero delega
    /// la responsabilidad de buscar a otras clases.
    /// Esta clase utiliza delegación ya que, cuando recibe un mensaje para buscar una publicación, delega la tarea a otras clases.
    /// Al delegar aumenta la cohesión y también el acoplamiento pero es el mejor balance que puede ocurrir.
    /// </summary>
    public class BuscarPublicacion
    {
        /// <summary>
        /// Contiene el tipo de búsqueda que se va a realizar.
        /// </summary>
        public string TipoBusqueda;

        /// <summary>
        /// Lo que se desea buscar.
        /// </summary>
        public string Busqueda;

        /// <summary>
        /// Lista de coincidencias de la búsqueda.
        /// </summary>
        public List<Publicacion> Result = new List<Publicacion>();

        /// <summary>
        /// Initializes a new instance of the <see cref="BuscarPublicacion"/> class.
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
        /// EjecutarComando se encarga de decidir qué tipo de búsqueda se va a realizar(categoría, zona y,
        /// palabras claves). Luego las delega a cada una de las clases que se encargan de,
        /// búsqueda, para cumplir con SRP.
        /// Finalmente, devuelve una lista con todas la publicaciones encontradas, de la búsqueda
        /// que se realizó.
        /// </summary>
        /// <returns>Lista con las publicaciones encontradas.</returns>
        public List<Publicacion> EjecutarComando()
        {
            if (this.TipoBusqueda.ToLower() == "/categoria")
            {
                BusquedaCategoria buscador = new BusquedaCategoria();
                this.Result = buscador.Buscar(this.Busqueda);
            }
            else if (this.TipoBusqueda.ToLower() == "/ciudad")
            {
                BusquedaZonaCiudad buscador = new BusquedaZonaCiudad();
                this.Result = buscador.Buscar(this.TipoBusqueda, this.Busqueda);
            }
            else if (this.TipoBusqueda == "/palabrasclave")
            {
                BusquedaKeyWord buscador = new BusquedaKeyWord();
                this.Result = buscador.Buscar(this.Busqueda);
            }
            else
            {
                Console.WriteLine("Usted no ingreso una opcion valida. Intente nuevamente.");
            }

            return this.Result;
        }
    }
}