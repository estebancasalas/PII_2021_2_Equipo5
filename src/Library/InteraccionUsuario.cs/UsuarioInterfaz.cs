using System;
using System.Collections.Generic;

namespace Library
{
    //borrar clase?
    public class UsuarioInterfaz
    {
        public EntaradaDeLaCadena StringInput = Singleton<LeerConsola>.Instance;
        public IFormatoSalida OutPut = Singleton<Traductor>.Instance;

    }
}