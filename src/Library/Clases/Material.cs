
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
        public class Material
        {
            /// <summary>
            /// Nombre del material
            /// </summary>
            /// <value></value>
            public string nombre {get;}
            /// <summary>
            /// Costo del material
            /// </summary>
            /// <value></value>
            public double costo {get;}
            /// <summary>
            /// Cantidad de material
            /// </summary>
            /// <value></value>
            public double cantidad {get;}
            /// <summary>
            /// ubicación del material
            /// </summary>
            /// <value></value>
            public string ubicacion {get;}
            /// <summary>
            /// Unidad (Kg, L, etc) del material
            /// </summary>
            /// <value></value>
            public string unidad {get;}
            /// <summary>
            /// Habilitaciónes del material
            /// </summary>
            /// <value></value>
            public string habilitaciones {get;}
            public string categoria {get;}

            public Material(string nombre, double costo, double cantiadad, string ubicacion, string unidad, string habilitaciones, string categoria)
        {
            this.nombre = nombre;
            this.costo = costo;
            this.cantidad = cantidad;
            this.ubicacion = ubicacion;
            this.unidad = unidad;
            this.habilitaciones = habilitaciones;
            this.categoria = categoria;
        }
        }
}