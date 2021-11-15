namespace Library
{
    // Esta bien asi el comentario?
    /// <summary>
    /// Interfaz que modela una ubicación.
    /// Creada por DIP. Las clases que necesitan trabajar con una o varias ubicaciones ahora dependen de esta abstracción y no de una clase concreta(como podría ser la clase Location
    /// en LocationApi).
    /// </summary>
    public interface IUbicacion
    {

        /// <summary>
        /// Pais en el que se encuentra la ubicación.
        /// </summary>
        /// <value>string</value>
        string Pais { get; set;}

        /// <summary>
        /// Ciudad en la que se encuentra la ubicación.
        /// </summary>
        /// <value></value>
        string Ciudad { get; set;}

        /// <summary>
        /// Direccion de la ubicación.
        /// </summary>
        /// <value></value>
        string Direccion { get; set;}

        /// <summary>
        /// Codigo postal de la ubicación.
        /// </summary>
        /// <value></value>
        string CodigoPostal { get; set;}

        /// <summary>
        /// Latitud de las coordenadas de la ubicación.
        /// </summary>
        /// <value></value>
        string Latitud { get; set;}

        /// <summary>
        /// Longitud de las coordenadas de la ubicación
        /// </summary>
        /// <value></value>
        string Longitud { get; set;}
    }
}