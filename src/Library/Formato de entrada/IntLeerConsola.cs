using System; 
//IntLeerConosla se encarga de recibir un int dede la consola, para que el usurio pueda interactuar con el menú del bot. 
//Es la impelemntación de una interface, porque la idea es que más adelnate se agregaran más maneras de intercatuar con el usurio.
namespace Library
{
    public class IntLeerConosla : IEntradaInt
    {
        public int GetInput(string message)
        {
            int n; 
            string input; 
            do 
            {
                Console.WriteLine(message);
                input = Console.ReadLine();

            }
            while (int.TryParse(input, out n) == false);
            return n; 
        }
    }
}