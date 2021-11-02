using System;
using LocationApi;


namespace Library
{
    /// <summary>
    /// CearPublicacion es la clase que se encarga del modelado de la publicación.
    /// </summary>
    public class CrearPublicacion 
    {

        /// <summary>
        /// DatosDeMateriales es el objeto que se utiliza en publicación para luego poder
        /// adquirir los datos del material que se encuentran/pide en la clase Material.
        /// </summary>
        public Material DatosDeMateriales {get; set;}
        /// <summary>
        /// Método que pide los datos necesarios para crear una publicación. Deriva la
        /// responsabilidad de crear la publicación a la clase Publicacion para cumplir
        /// con el principio SRP.
        /// </summary>
        /// <returns></returns>
        public async void EjecutarComando(Material material, string titulo, string PalabrasClave, string frecuencia, string ubicacion)
        { 
            IUbicacion localizador = new Ubicacion();
            Location Localizacion = await localizador.GetUbicacion(ubicacion);
            Publicacion publicacion = new Publicacion(titulo, DatosDeMateriales, PalabrasClave, frecuencia, Localizacion);
        }
    }
}
