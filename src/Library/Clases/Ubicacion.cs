namespace Library
{
    /// <summary>
    /// Clase que modela una ubicación.
    /// Implementa IUbicacion.
    /// Colabora con: UbicacionProvider,
    /// </summary>
    public class Ubicacion : IUbicacion
    {
        /// <summary>
        /// Propiedad que almacena el País.
        /// </summary>
        /// <value></value>
        public string Pais { get; set;} = "Uruguay";

        /// <summary>
        /// Propiedad que almacena la Ciudad.
        /// </summary>
        /// <value></value>
        public string Ciudad { get; set;} = "Montevideo";

        /// <summary>
        /// Propiedad que almacena la dirección.
        /// </summary>
        /// <value></value>
        public string Direccion { get; set;} = "";

        /// <summary>
        /// Propiedad que almacena el código postal. 
        /// </summary>
        /// <value></value>
        public string CodigoPostal { get; set;} = "";

        /// <summary>
        /// Propiedad que almacena la Latitud de las coordenadas.
        /// </summary>
        /// <value></value>
        public string Latitud { get; set;} = "";

        /// <summary>
        /// Propiedad que almacena la Longitud de las coordenadas.
        /// </summary>
        /// <value></value>
        public string Longitud { get; set;} = "";

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="pais"></param>
        /// <param name="ciudad"></param>
        /// <param name="direccion"></param>
        /// <param name="codigoPostal"></param>
        /// <param name="latitud"></param>
        /// <param name="longitud"></param>
        public Ubicacion(string pais, string ciudad, string direccion, string codigoPostal, string latitud, string longitud)
        {
            this.Pais = pais;
            this.Ciudad = ciudad;
            this.Direccion = direccion;
            this.CodigoPostal = codigoPostal;
            this.Latitud = latitud;
            this.Longitud = longitud;
        }



    }
}
