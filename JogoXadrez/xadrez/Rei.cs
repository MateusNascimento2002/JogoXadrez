using tabuleiro;

namespace xadrez {
    class Rei : Peca {

        private PartidaDeXadrez _partida;

        public Rei(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor) {
            _partida = partida;
        }

        public override string ToString() {
            return "R";
        }

        private bool PodeMover(Posicao pos) {
            Peca p = Tab.peca(pos);
            return p == null || p.cor != cor;
        }

        private bool TesteTorreParaRoque(Posicao pos) {
            Peca p = Tab.peca(pos);
            return p != null && p is Torre && p.cor == cor && p.QteMovimentos == 0;
        }

        public override bool[,] MovimentosPossiveis() {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            // acima
            pos.DefinirValores(Pos.Linha - 1, Pos.Coluna);
            if (Tab.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            // ne
            pos.DefinirValores(Pos.Linha - 1, Pos.Coluna + 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            // direita
            pos.DefinirValores(Pos.Linha, Pos.Coluna + 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            // se
            pos.DefinirValores(Pos.Linha + 1, Pos.Coluna + 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            // abaixo
            pos.DefinirValores(Pos.Linha + 1, Pos.Coluna);
            if (Tab.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            // so
            pos.DefinirValores(Pos.Linha + 1, Pos.Coluna - 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            // esquerda
            pos.DefinirValores(Pos.Linha, Pos.Coluna - 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            // no
            pos.DefinirValores(Pos.Linha - 1, Pos.Coluna - 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }

            // #jogadaespecial roque
            if (QteMovimentos==0 && !_partida.Xeque) {
                // #jogadaespecial roque pequeno
                Posicao posT1 = new Posicao(Pos.Linha, Pos.Coluna + 3);
                if (TesteTorreParaRoque(posT1)) {
                    Posicao p1 = new Posicao(Pos.Linha, Pos.Coluna + 1);
                    Posicao p2 = new Posicao(Pos.Linha, Pos.Coluna + 2);
                    if (Tab.peca(p1)==null && Tab.peca(p2)==null) {
                        mat[Pos.Linha, Pos.Coluna + 2] = true;
                    }
                }
                // #jogadaespecial roque grande
                Posicao posT2 = new Posicao(Pos.Linha, Pos.Coluna - 4);
                if (TesteTorreParaRoque(posT2)) {
                    Posicao p1 = new Posicao(Pos.Linha, Pos.Coluna - 1);
                    Posicao p2 = new Posicao(Pos.Linha, Pos.Coluna - 2);
                    Posicao p3 = new Posicao(Pos.Linha, Pos.Coluna - 3);
                    if (Tab.peca(p1) == null && Tab.peca(p2) == null && Tab.peca(p3) == null) {
                        mat[Pos.Linha, Pos.Coluna - 2] = true;
                    }
                }
            } 


            return mat;
        }
    }
}
