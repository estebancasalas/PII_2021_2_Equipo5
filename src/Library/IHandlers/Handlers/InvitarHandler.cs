using System;
using System.Text;

namespace Library
{
    public class InvitarHandler :IHandler
    {
        public IHandler Next {get; set;}
        public void Handle(Mensaje mensaje)
        {}
    }
}