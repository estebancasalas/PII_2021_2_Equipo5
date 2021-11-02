
using System;

namespace Library
{
    /// <summary>
    /// Esta clase se encarga del modelado del material.
    /// </summary>
        public class Material
        {
            /// <summary>
            /// Se encarga de guardar el nombre del material dentro del objeto material.
            /// </summary>
            /// <value></value>
            public string Nombre {get;}
            /// <summary>
            /// Se encarga de guardar el costo del material dentro del objeto material.
            /// </summary>
            /// <value></value>
            public double Costo {get;}
            /// <summary>
            /// Se encarga de guardar la cantidad que existe del mismo dentro del objeto material.
            /// </summary>
            /// <value></value>
            public double Cantidad {get;}
            /// <summary>
            /// Se encarga de guardar la unidad en la cual se pesa el material dentro del objeto material.
            /// </summary>
            /// <value></value>
            public string Unidad {get;}
            /// <summary>
            /// Se encarga de guardar las habliitaciones, que se necesitan para obtener el material, dentro del objeto material.
            /// Link al documento.
            /// </summary>
            /// <value></value>
            public string Habilitaciones {get;}
            /// <summary>
            /// Se encarga de guardar la categoría del material dentro del objeto material.
            /// </summary>
            /// <value></value>
            public string Categoria {get;}
            /// <summary>
            /// Constructor del material.
            /// </summary>
            /// <param name="Nombre"></param>El nombre del material.
            /// <param name="Costo"></param>El costo del material.
            /// <param name="Cantiadad"></param>La cantidad del material.
            /// <param name="Unidad"></param>La unidad en la cual se cuantifica el material
            /// <param name="Habilitaciones"></param>Las habliitaciones que se necesitan para el material.
            /// <param name="Categoria"></param>La categoría del material.
            public Material(string Nombre, double Costo, double Cantiadad, string Unidad, string Habilitaciones, string Categoria)
        {
            this.Nombre = Nombre;
            this.Costo = Costo;
            this.Cantidad = Cantidad;
            this.Unidad = Unidad;
            this.Habilitaciones = Habilitaciones;
            this.Categoria = Categoria;
        }
        }
}