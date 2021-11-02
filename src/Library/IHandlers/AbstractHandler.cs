namespace Library 
{
    public class AbstarctHandler : IHandler
    {
        public IHandler Next {get; set;}
        public IEntaradaDeLaCadena Input = Singleton<LeerConsola>.Instance;
        public IFormatoSalida Output = Singleton<Traductor>.Instance;

        public virtual void Handle(Mensaje mensaje)
        {
            if (this.Next != null)
            {
                this.Next.Handle(mensaje);
            }
        }
    }
}