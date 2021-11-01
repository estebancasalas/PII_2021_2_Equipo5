
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
            public string Nombre {get;}
            /// <summary>
            /// Costo del material
            /// </summary>
            /// <value></value>
            public double Costo {get;}
            /// <summary>
            /// Cantidad de material
            /// </summary>
            /// <value></value>
            public double Cantidad {get;}
            /// <summary>
            /// ubicación del material
            /// </summary>
            /// <value></value>
            public string Ubicacion {get;}
            /// <summary>
            /// Unidad (Kg, L, etc) del material
            /// </summary>
            /// <value></value>
            public string Unidad {get;}
            /// <summary>
            /// Habilitaciónes del material
            /// </summary>
            /// <value></value>
            public string Habilitaciones {get;}
            public string Categoria {get;}

            public Material(string Nombre, double Costo, double Cantiadad, string Ubicacion, string Unidad, string Habilitaciones, string Categoria)
        {
            this.Nombre = Nombre;
            this.Costo = Costo;
            this.Cantidad = Cantidad;
            this.Ubicacion = Ubicacion;
            this.Unidad = Unidad;
            this.Habilitaciones = Habilitaciones;
            this.Categoria = Categoria;
        }
        }
}