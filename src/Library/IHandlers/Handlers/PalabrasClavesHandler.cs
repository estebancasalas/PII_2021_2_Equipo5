using System;
using System.Text;

namespace Library
{
    public class PalabrasClavesHandler :IHandler
    {
        public IHandler Next {get; set;}
        public void Handle(Mensaje mensaje)
        {}
    }
}