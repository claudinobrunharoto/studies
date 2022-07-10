namespace board
{
    class Board
    {
        public int rows { get; set; }
        public int cols { get; set; }
        private Piece[,] pieces;

        public Board(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            pieces = new Piece[rows, cols];
        }

        public Piece piece(int row, int col)
        {
            return pieces[row, col];
        }

        public Piece piece(Position pos)
        {
            return pieces[pos.row, pos.col];
        }

        public bool emptyPosition(Position pos)
        {
            validatePosition(pos);
            return piece(pos) == null;
        }

        public void putPiece(Piece p, Position pos)
        {
            if (!emptyPosition(pos))
            {
                throw new BoardException("There is already a piece in this position!");
            }
            pieces[pos.row, pos.col] = p;
            p.position = pos;
        }

        public Piece removePiece(Position pos)
        {
            if (emptyPosition(pos))
            {
                return null;
            }
            Piece aux = piece(pos);
            aux.position = null;
            pieces[pos.row, pos.col] = null;
            return aux;
        }

        public bool isValidPosition(Position pos)
        {
            if (pos.row < 0 || pos.row >= rows || pos.col < 0 || pos.col >= cols)
            {
                return false;
            }
            return true;
        }

        public void validatePosition(Position pos)
        {
            if (!isValidPosition(pos))
            {
                throw new BoardException("Invalid position!");
            }
        }
    }
}