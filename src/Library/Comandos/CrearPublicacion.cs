using System;
using LocationApi;
using System.Threading.Tasks;


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
        public void EjecutarComando(Material material, string titulo, string PalabrasClave, string frecuencia, string ubicacion, string nombreEmpresa)
        { 
            IUbicacion localizador = new Ubicacion();
            Location Localizacion = new Location(); //await localizador.GetUbicacion(ubicacion);
            Publicacion publicacion = new Publicacion(titulo, material, PalabrasClave, frecuencia, Localizacion, nombreEmpresa);
        }
    }
}
