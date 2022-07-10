using board;

namespace chess
{
    class Queen: Piece
    {
        public Queen(Board tab, Color color): base (tab, color)
        {

        }

        public override string ToString()
        {
            return "D"; // Dama
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
            // noroeste
            pos.setValues(position.row - 1, position.col - 1);
            while (tab.isValidPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.col] = true;
                if (tab.piece(pos) != null && tab.piece(pos).color != color)
                {
                    break;
                }
                pos.setValues(pos.row - 1, pos.col - 1);
            }
            // nordeste
            pos.setValues(position.row - 1, position.col + 1);
            while (tab.isValidPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.col] = true;
                if (tab.piece(pos) != null && tab.piece(pos).color != color)
                {
                    break;
                }
                pos.setValues(pos.row - 1, pos.col + 1);
            }         
            // sudeste
            pos.setValues(position.row + 1, position.col + 1);
            while (tab.isValidPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.col] = true;
                if (tab.piece(pos) != null && tab.piece(pos).color != color)
                {
                    break;
                }
                pos.setValues(pos.row + 1, pos.col + 1);;
            }
            // sudoeste
            pos.setValues(position.row + 1, position.col - 1);
            while (tab.isValidPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.col] = true;
                if (tab.piece(pos) != null && tab.piece(pos).color != color)
                {
                    break;
                }
                pos.setValues(pos.row + 1, pos.col - 1);
            }

            return mat;
        }
    }
}