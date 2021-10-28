using System;
using System.Collections.Generic;

namespace Library
{
    public class RegistroPublicaciones
    {
        public static List<Publicacion> Activas {get; set;} = new List<Publicacion>();
        public static List<Publicacion> Eliminadas = new List<Publicacion>();
        public static List<Publicacion> Pausadas = new List<Publicacion>();


//Se utilizan estos metodos para lograr una correcta encapsulacion de la clase
//Los métodos nos vana  saervir para poder realizar cambios dentro de las listas 
//sin tener que compartir la infromación de las listas 
//(Buscar patron que habla de encapsulación)

        public void AñadirNuevaPublicacion(Publicacion publi)
        {
            RegistroPublicaciones.Activas.Add(publi);
        }
        public void PausarPublicacion(Publicacion publi)
        {
            foreach (Publicacion publicaciones in Activas)
            {
                if (publicaciones.Equals(publi))
                {
                    RegistroPublicaciones.Pausadas.Add(publicaciones);
                    RegistroPublicaciones.Activas.RemoveAt(Activas.IndexOf(publicaciones));
                }
            }
        }
        public void EliminarPublicacion(Publicacion publi)
        {
            foreach (Publicacion publicaciones in Activas)
            {
                if (publicaciones.Equals(publi))
                {
                    RegistroPublicaciones.Eliminadas.Add(publicaciones);
                    RegistroPublicaciones.Activas.RemoveAt(Activas.IndexOf(publicaciones));
                }
            }

            foreach (Publicacion publicaciones in Pausadas)
            {
                if (publicaciones.Equals(publi))
                {
                    RegistroPublicaciones.Eliminadas.Add(publicaciones);
                    RegistroPublicaciones.Pausadas.RemoveAt(Pausadas.IndexOf(publicaciones));
                }
            }
        }
    }
}