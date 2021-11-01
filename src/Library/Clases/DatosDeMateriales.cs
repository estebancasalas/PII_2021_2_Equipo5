
using System;

namespace Library
{
    /// <summary>
    /// Clase con los datos del material. Incluye:
    /// -nombre
    /// -costo
    /// -cantidad
    /// -ubicacion
    /// -unidad
    /// -habilitaciones
    /// </summary>
        public class DatosDeMateriales
        {
            /// <summary>
            /// Nombre del material
            /// </summary>
            /// <value></value>
            private string nombre {get;}
            /// <summary>
            /// Costo del material
            /// </summary>
            /// <value></value>
            private double costo {get;}
            /// <summary>
            /// Cantidad de material
            /// </summary>
            /// <value></value>
            private double cantidad {get;}
            /// <summary>
            /// ubicación del material
            /// </summary>
            /// <value></value>
            private string ubicacion {get;}
            /// <summary>
            /// Unidad (Kg, L, etc) del material
            /// </summary>
            /// <value></value>
            private string unidad {get;}
            /// <summary>
            /// Habilitaciónes del material
            /// </summary>
            /// <value></value>
            private string habilitaciones {get;}
            private string categoria {get;}
        }
}