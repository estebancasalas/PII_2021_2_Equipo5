namespace Library
{
    public class OutputTest : IFormatoSalida
    {
        public string PrintLine(string line)
        {
            return line.ToString();
        }
    }
}