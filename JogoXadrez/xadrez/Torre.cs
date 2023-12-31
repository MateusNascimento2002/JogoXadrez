﻿using tabuleiro;

namespace xadrez {
    class Torre : Peca {

        public Torre(Tabuleiro tab, Cor cor) : base(tab, cor) {
        }

        public override string ToString() {
            return "T";
        }

        private bool _podeMover(Posicao pos) {
            Peca p = Tab.peca(pos);
            return p == null || p.cor != cor;
        }

        public override bool[,] MovimentosPossiveis() {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            // acima
            pos.DefinirValores(Pos.Linha - 1, Pos.Coluna);
            while (Tab.PosicaoValida(pos) && _podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.peca(pos) != null && Tab.peca(pos).cor != cor) {
                    break;
                }
                pos.Linha = pos.Linha - 1;
            }

            // abaixo
            pos.DefinirValores(Pos.Linha + 1, Pos.Coluna);
            while (Tab.PosicaoValida(pos) && _podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.peca(pos) != null && Tab.peca(pos).cor != cor) {
                    break;
                }
                pos.Linha = pos.Linha + 1;
            }

            // direita
            pos.DefinirValores(Pos.Linha, Pos.Coluna + 1);
            while (Tab.PosicaoValida(pos) && _podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.peca(pos) != null && Tab.peca(pos).cor != cor) {
                    break;
                }
                pos.Coluna = pos.Coluna + 1;
            }

            // esquerda
            pos.DefinirValores(Pos.Linha, Pos.Coluna - 1);
            while (Tab.PosicaoValida(pos) && _podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.peca(pos) != null && Tab.peca(pos).cor != cor) {
                    break;
                }
                pos.Coluna = pos.Coluna - 1;
            }

            return mat;
        }
    }
}
