using Library;
namespace Library 
{
    public class AbstarctHandler : IHandler
    {
        public IHandler Next {get; set;}
        public IFormato Output = Singleton<Traductor>.Instance;

        public virtual void Handle(Mensaje mensaje)
        {
            if (this.Next != null)
            {
                this.Next.Handle(mensaje);
            }
        }
    }
}