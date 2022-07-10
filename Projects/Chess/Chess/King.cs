using board;

namespace chess
{
    class King: Piece
    {
        private ChessMatch match;

        public King(Board tab, Color color, ChessMatch match): base (tab, color)
        {
            this.match = match;
        }        

        public override string ToString()
        {
            return "R";
        }

        private bool testRookCastling(Position pos)
        {
            Piece p = tab.piece(pos);
            return p != null && p is Rook && p.color == color && p.movAmount == 0;
        }   

        public override bool[,] possibleMovments()
        {
            bool[,] mat = new bool[tab.rows, tab.cols];
            Position pos = new Position(0, 0);

            // acima
            pos.setValues(position.row - 1, position.col);
            if (tab.isValidPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.col] = true;
            }
            // nordeste
            pos.setValues(position.row - 1, position.col + 1);
            if (tab.isValidPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.col] = true;
            }
            // direita
            pos.setValues(position.row, position.col + 1);
            if (tab.isValidPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.col] = true;
            }
            // sudeste
            pos.setValues(position.row + 1, position.col + 1);
            if (tab.isValidPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.col] = true;
            }
            // abaixo
            pos.setValues(position.row + 1, position.col);
            if (tab.isValidPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.col] = true;
            }
            // sudoeste
            pos.setValues(position.row + 1, position.col - 1);
            if (tab.isValidPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.col] = true;
            }
            // esquerda
            pos.setValues(position.row, position.col - 1);
            if (tab.isValidPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.col] = true;
            }
            // noroeste
            pos.setValues(position.row - 1, position.col - 1);
            if (tab.isValidPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.col] = true;
            }

            // #specialMoves -> Castling (roque)
            if (movAmount == 0 && !match.check)
            {
                // #specialMoves -> kingside castling (roque pequeno)
                Position posRook1 = new Position(position.row, position.col + 3);
                if (testRookCastling(posRook1))
                {
                    Position p1 = new Position(position.row, position.col + 1);
                    Position p2 = new Position(position.row, position.col + 2);
                    if (tab.piece(p1) == null && tab.piece(p2) == null)
                    {
                        mat[position.row, position.col + 2] = true;
                    }
                }

                // #specialMoves -> queenside castling (roque grande)
                Position posRook2 = new Position(position.row, position.col - 4);
                if (testRookCastling(posRook2))
                {
                    Position p1 = new Position(position.row, position.col - 1);
                    Position p2 = new Position(position.row, position.col - 2);
                    Position p3 = new Position(position.row, position.col - 2);
                    if (tab.piece(p1) == null && tab.piece(p2) == null && tab.piece(p3) == null)
                    {
                        mat[position.row, position.col - 2] = true;
                    }
                }
            }

            return mat;
        }
    }
}