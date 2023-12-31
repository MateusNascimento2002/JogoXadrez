﻿using tabuleiro;

namespace xadrez {

    class Cavalo : Peca {

        public Cavalo(Tabuleiro tab, Cor cor) : base(tab, cor) {
        }

        public override string ToString() {
            return "C";
        }

        private bool _podeMover(Posicao pos) {
            Peca p = Tab.peca(pos);
            return p == null || p.cor != cor;
        }

        public override bool[,] MovimentosPossiveis() {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            pos.DefinirValores(Pos.Linha - 1, Pos.Coluna - 2);
            if (Tab.PosicaoValida(pos) && _podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Pos.Linha - 2, Pos.Coluna - 1);
            if (Tab.PosicaoValida(pos) && _podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Pos.Linha - 2, Pos.Coluna + 1);
            if (Tab.PosicaoValida(pos) && _podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Pos.Linha - 1, Pos.Coluna + 2);
            if (Tab.PosicaoValida(pos) && _podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Pos.Linha + 1, Pos.Coluna + 2);
            if (Tab.PosicaoValida(pos) && _podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Pos.Linha + 2, Pos.Coluna + 1);
            if (Tab.PosicaoValida(pos) && _podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Pos.Linha + 2, Pos.Coluna - 1);
            if (Tab.PosicaoValida(pos) && _podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Pos.Linha + 1, Pos.Coluna - 2);
            if (Tab.PosicaoValida(pos) && _podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }

            return mat;
        }
    }
}
