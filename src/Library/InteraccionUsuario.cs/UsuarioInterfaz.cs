using System;
using System.Collections.Generic;

namespace Library
{
    public class UsuarioInterfaz
    {
        public IEntaradaDeLaCadena StringInput = Singleton<LeerConsola>.Instance;
        public IEntradaInt IntInput = Singleton<IntLeerConosla>.Instance;
        public IFormatoSalida OutPut = Singleton<Traductor>.Instance;

    }
}