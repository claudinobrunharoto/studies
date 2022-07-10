using board;

namespace chess
{
    class Pawn: Piece
    {
        private ChessMatch match;

        public Pawn(Board tab, Color color, ChessMatch match): base (tab, color)
        {
            this.match = match;
        }

        public override string ToString()
        {
            return "P";
        }

        private bool isThereAdversary(Position pos)
        {
            Piece p = tab.piece(pos);
            return p != null && p.color != color;
        }

        private bool free(Position pos)
        {
            return tab.piece(pos) == null;
        }

        public override bool[,] possibleMovments()
        {
            bool[,] mat = new bool[tab.rows, tab.cols];
            Position pos = new Position(0, 0);

            if (color == Color.White)
            {
                pos.setValues(position.row - 1, position.col);
                if (tab.isValidPosition(pos) && free(pos))
                {
                    mat[pos.row, pos.col] = true;
                }
                pos.setValues(position.row - 2, position.col);
                if (tab.isValidPosition(pos) && free(pos) && movAmount == 0)
                {
                    mat[pos.row, pos.col] = true;
                }
                pos.setValues(position.row - 1, position.col - 1);
                if (tab.isValidPosition(pos) && isThereAdversary(pos))
                {
                    mat[pos.row, pos.col] = true;
                }
                pos.setValues(position.row - 1, position.col + 1);
                if (tab.isValidPosition(pos) && isThereAdversary(pos))
                {
                    mat[pos.row, pos.col] = true;
                }

                // #specialMoves -> En Passant (white)
                if (position.row == 3)
                {
                    Position left = new Position(position.row, position.col - 1);
                    if (tab.isValidPosition(left) && isThereAdversary(left) && tab.piece(left) == match.vulnerableEnPassant)
                    {
                        mat[left.row - 1, left.col] = true;
                    }
                    Position right = new Position(position.row, position.col + 1);
                    if (tab.isValidPosition(right) && isThereAdversary(right) && tab.piece(right) == match.vulnerableEnPassant)
                    {
                        mat[right.row - 1, right.col] = true;
                    }
                }
            } else {
                pos.setValues(position.row + 1, position.col);
                if (tab.isValidPosition(pos) && free(pos))
                {
                    mat[pos.row, pos.col] = true;
                }
                pos.setValues(position.row + 2, position.col);
                if (tab.isValidPosition(pos) && free(pos) && movAmount == 0)
                {
                    mat[pos.row, pos.col] = true;
                }
                pos.setValues(position.row + 1, position.col - 1);
                if (tab.isValidPosition(pos) && isThereAdversary(pos))
                {
                    mat[pos.row, pos.col] = true;
                }
                pos.setValues(position.row + 1, position.col + 1);
                if (tab.isValidPosition(pos) && isThereAdversary(pos))
                {
                    mat[pos.row, pos.col] = true;
                }

                // #specialMoves -> En Passant (black)
                if (position.row == 4)
                {
                    Position left = new Position(position.row, position.col - 1);
                    if (tab.isValidPosition(left) && isThereAdversary(left) && tab.piece(left) == match.vulnerableEnPassant)
                    {
                        mat[left.row + 1, left.col] = true;
                    }
                    Position right = new Position(position.row, position.col + 1);
                    if (tab.isValidPosition(right) && isThereAdversary(right) && tab.piece(right) == match.vulnerableEnPassant)
                    {
                        mat[right.row + 1, right.col] = true;
                    }
                }
            }

            return mat;
        }
    }
}