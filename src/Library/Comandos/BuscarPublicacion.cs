using System;

namespace ConsoleApplication
{
    /// <summary>
    /// Pregunta por el tipo de busqueda, pide a la clase correspondiente que la realice y devuelve una lista con las coincidencias.
    /// Ademas, se debera preguntar por los parametros necesarios para la busqueda.
    /// En caso de una busqueda por mas de un tipo, se realizan todas las busquedas y de devuelve las coincidencias comunes a todas las busquedas.
    /// </summary>
    public class BuscarPublicacion : IComandos
    {
        private List<string> tiposBusqueda = new List<string>();
        private List<Publicacion> resultado = new List<Publicacion>();
        public EjecutarComando()
        {

        }
    }
}