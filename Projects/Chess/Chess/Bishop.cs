using board;

namespace chess
{
    class Bishop: Piece
    {
        public Bishop(Board tab, Color color): base (tab, color)
        {

        }

        public override string ToString()
        {
            return "B";
        }

        public override bool[,] possibleMovments()
        {
            bool[,] mat = new bool[tab.rows, tab.cols];
            Position pos = new Position(0, 0);

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