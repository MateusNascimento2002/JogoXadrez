using xadrez;
using tabuleiro;
using System;

namespace JogoXadrez
{
    internal class Program
    {
        static void Main(string[] args)
        {

            try
            {
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.terminada)
                {
                    try
                    {
                        Console.Clear();
                        Tela.imprimirTabuleiro(partida.tab);
                        Console.WriteLine();
                        Console.WriteLine($"Turno: {partida.turno}");
                        Console.WriteLine($"Aguardando jogada: {partida.jogadorAtual}");

                        Console.WriteLine();
                        Console.WriteLine("Origem: ");
                        Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaodeDeOrigem(origem);
                        bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis();

                        Console.Clear();
                        Tela.imprimirTabuleiro(partida.tab, posicoesPossiveis);


                        Console.WriteLine("Destino: ");
                        Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaodeDeDestino(origem,destino);
                        partida.realizaJogada(origem, destino);
                    }
                    catch (TabuleiroException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                    
                }



                
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }




            Console.ReadLine();
        }
    }
}