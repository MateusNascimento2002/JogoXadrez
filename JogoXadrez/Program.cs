using xadrez;
using tabuleiro;
namespace JogoXadrez
{
    internal class Program
    {
        static void Main(string[] args)
        {

            try
            {
                Tabuleiro tab = new Tabuleiro(8, 8);

                tab.colocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 4));
                tab.colocarPeca(new Rei(tab, Cor.Preta), new Posicao(0, 5));
                tab.colocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 6));

                tab.colocarPeca(new Torre(tab, Cor.Branca), new Posicao(5, 4));
                tab.colocarPeca(new Rei(tab, Cor.Branca), new Posicao(5, 5));
                tab.colocarPeca(new Torre(tab, Cor.Branca), new Posicao(5, 6));

                Tela.imprimirTabuleiro(tab);
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e);
                throw;
            }




            Console.ReadLine();
        }
    }
}