using System;
using Ucu.Poo.Locations.Client;
using System.Threading.Tasks;


namespace Library
{
    /// <summary>
    /// Clase que se encarga de crear una publicación. 
    /// </summary>
    public class CrearPublicacion 
    {
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
            RegistroPublicaciones.Activas.Add(publicacion);
        }
    }
}
