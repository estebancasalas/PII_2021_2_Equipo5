using System;
using LocationApi;
using System.Threading.Tasks;


namespace Library
{
    /// <summary>
    /// Interfaz para implementar el método encargado de obtener una ubicación. Creada para aplicar DIP y
    /// Polymorphism en caso de que hayan otras formas de encontrar una ubicación (actualmente solo hay una).
    /// </summary>
    public interface IUbicacion
    {
        /// <summary>
        /// Método para obtener la ubicación en coordenadas a partir de un string.
        /// </summary>
        /// <param name="ubicacion">Dirección de la que se desea obtener las coordenadas</param>
        /// <returns></returns>
        Task <Location> GetUbicacion(string ubicacion);
        
    }

}