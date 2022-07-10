using board;

namespace chess
{
    class Rook: Piece
    {
        public Rook(Board tab, Color color): base (tab, color)
        {

        }

        public override string ToString()
        {
            return "T";
        }

        public override bool[,] possibleMovments()
        {
            bool[,] mat = new bool[tab.rows, tab.cols];
            Position pos = new Position(0, 0);

            // acima
            pos.setValues(position.row - 1, position.col);
            while (tab.isValidPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.col] = true;
                if (tab.piece(pos) != null && tab.piece(pos).color != color)
                {
                    break;
                }
                pos.row--;
            }
            // abaixo
            pos.setValues(position.row + 1, position.col);
            while (tab.isValidPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.col] = true;
                if (tab.piece(pos) != null && tab.piece(pos).color != color)
                {
                    break;
                }
                pos.row++;
            }         
            // direita
            pos.setValues(position.row, position.col + 1);
            while (tab.isValidPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.col] = true;
                if (tab.piece(pos) != null && tab.piece(pos).color != color)
                {
                    break;
                }
                pos.col++;
            }
            // esquerda
            pos.setValues(position.row, position.col - 1);
            while (tab.isValidPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.col] = true;
                if (tab.piece(pos) != null && tab.piece(pos).color != color)
                {
                    break;
                }
                pos.col--;
            }

            return mat;
        }
    }
}