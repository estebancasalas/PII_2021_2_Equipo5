using System;
using System.Collections.Generic;

namespace Library
{
    public class RegistroPublicaciones
    {
        public static List<Publicacion> Activas {get; set;} = new List<Publicacion>();
        public static List<Publicacion> aliminadas = new List<Publicacion>();
        public static List<Publicacion> pausadas = new List<Publicacion>();


//Se utilizan estos metodos para lograr una correcta encapsulacion de la clase
//Los métodos nos vana  saervir para poder realizar cambios dentro de las listas 
//sin tener que compartir la infromación de las listas 
//(Buscar patron que habla de encapsulación)

        public void AñadirNuevaPublicacion(Publicacion publi)
        {
            this.activas.Add(publi);
        }
        public void PausarPublicacion(Publicacion publi)
        {
            foreach (Publicacion publicaciones in activas)
            {
                if (publicaciones.Equals(publi))
                {
                    this.pausadas.Add(publicaciones);
                    this.activas.RemoveAt(activas.IndexOf(publicaciones));
                }
            }
        }
        public void EliminarPublicacion(Publicacion publi)
        {
            foreach (Publicacion publicaciones in activas)
            {
                if (publicaciones.Equals(publi))
                {
                    this.eliminadas.Add(publicaciones);
                    this.activas.RemoveAt(activas.IndexOf(publicaciones));
                }
            }

            foreach (Publicacion publicaciones in pausadas)
            {
                if (publicaciones.Equals(publi))
                {
                    this.eliminadas.Add(publicaciones);
                    this.pausadas.RemoveAt(pausadas.IndexOf(publicaciones));
                }
            }
        }
    }
}