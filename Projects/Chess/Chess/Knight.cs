using board;

namespace chess
{
    class Knight: Piece
    {
        public Knight(Board tab, Color color): base (tab, color)
        {

        }

        public override string ToString()
        {
            return "C";
        }

        public override bool[,] possibleMovments()
        {
            bool[,] mat = new bool[tab.rows, tab.cols];
            Position pos = new Position(0, 0);

            pos.setValues(position.row - 1, position.col - 2);
            if (tab.isValidPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.col] = true;
            }

            pos.setValues(position.row - 2, position.col - 1);
            if (tab.isValidPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.col] = true;
            }       

            pos.setValues(position.row - 2, position.col + 1);
            if (tab.isValidPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.col] = true;
            }

            pos.setValues(position.row - 1, position.col + 2);
            if (tab.isValidPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.col] = true;
            } 

            pos.setValues(position.row + 1, position.col + 2);
            if (tab.isValidPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.col] = true;
            }

            pos.setValues(position.row + 2, position.col + 1);
            if (tab.isValidPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.col] = true;
            }       

            pos.setValues(position.row + 2, position.col - 1);
            if (tab.isValidPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.col] = true;
            }

            pos.setValues(position.row + 1, position.col - 2);
            if (tab.isValidPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.col] = true;
            } 

            return mat;
        }
    }
}