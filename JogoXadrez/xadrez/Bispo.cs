using tabuleiro;

namespace xadrez {

    class Bispo : Peca {

        public Bispo(Tabuleiro tab, Cor cor) : base(tab, cor) {
        }

        public override string ToString() {
            return "B";
        }

        private bool _podeMover(Posicao pos) {
            Peca p = Tab.peca(pos);
            return p == null || p.cor != cor;
        }
        
        public override bool[,] MovimentosPossiveis() {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            // NO
            pos.DefinirValores(Pos.Linha - 1, Pos.Coluna - 1);
            while (Tab.PosicaoValida(pos) && _podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.peca(pos) != null && Tab.peca(pos).cor != cor) {
                    break;
                }
                pos.DefinirValores(pos.Linha - 1, pos.Coluna - 1);
            }

            // NE
            pos.DefinirValores(Pos.Linha - 1, Pos.Coluna + 1);
            while (Tab.PosicaoValida(pos) && _podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.peca(pos) != null && Tab.peca(pos).cor != cor) {
                    break;
                }
                pos.DefinirValores(pos.Linha - 1, pos.Coluna + 1);
            }

            // SE
            pos.DefinirValores(Pos.Linha + 1, Pos.Coluna + 1);
            while (Tab.PosicaoValida(pos) && _podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.peca(pos) != null && Tab.peca(pos).cor != cor) {
                    break;
                }
                pos.DefinirValores(pos.Linha + 1, pos.Coluna + 1);
            }

            // SO
            pos.DefinirValores(Pos.Linha + 1, Pos.Coluna - 1);
            while (Tab.PosicaoValida(pos) && _podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.peca(pos) != null && Tab.peca(pos).cor != cor) {
                    break;
                }
                pos.DefinirValores(pos.Linha + 1, pos.Coluna - 1);
            }

            return mat;
        }
    }
}
