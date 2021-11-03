using System;
using System.Text;

namespace Library
{
    /// <summary>
    /// Clase encargadad de crear un Material. Creada con SRP para que CrearPublicacionHandler no tenga
    /// la responsabilidad de crear una instancia de Material.
    /// </summary>
    public class CrearMaterial

    {
        /// <summary>
        /// Método que crea el objeto Material, recibe como parámetros los datos del objeto.
        /// </summary>
        /// <param name="nombre">Nombre del material.</param>
        /// <param name="costo">Costo por unidad del material.</param>
        /// <param name="cantidad">Cantidad del material.</param>
        /// <param name="unidad">Unidad con la que se cuantifica el material.</param>
        /// <param name="habilitacion">Habilitaciones del material.</param>
        /// <param name="categoria">Categoría del material.</param>
        /// <returns></returns>
        public Material Crear(string nombre, double costo, double cantidad, string unidad, string habilitacion, string categoria)
        {

            Material material = new Material(nombre, costo, cantidad, unidad, habilitacion, categoria);
            return material;
        }
    }
}