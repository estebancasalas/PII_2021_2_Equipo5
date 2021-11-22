namespace Library
{
    public class EstadoUsuario
    {
        public IHandler handler;
        public int step;

        public EstadoUsuario()
        {
            this.handler = new NullHandler();
            this.step = 0;
        }
    }   
}