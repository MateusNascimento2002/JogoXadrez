using xadrez;
using tabuleiro;
namespace JogoXadrez
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PosicaoXadrez pos = new PosicaoXadrez('c', 7);

            Console.WriteLine(pos.toPosicao());






            Console.ReadLine();
        }
    }
}