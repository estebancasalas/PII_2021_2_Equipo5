using System;

namespace Library
{
    public class Empresario : IUsuario
    {
        public int Id { get; set;}
        public EstadoUsuario Estado { get; set;}
        public string Nombre;
        public Empresario(int num, EstadoUsuario estado, string nombre)
        {
            this.Id = num;
            this.Estado = estado;
            this.Nombre = nombre;
        }
    }
}