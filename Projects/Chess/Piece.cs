namespace board
{
    abstract class Piece
    {
        public Position position { get; set; }
        public Color color { get; protected set; }
        public int movAmount { get; protected set; }
        public Board tab { get; protected set; }

        public Piece(Board tab, Color color)
        {
            this.position = null;
            this.color = color;
            this.tab = tab;
            movAmount = 0;
        }

        public void incMovAmount()
        {
            movAmount++;
        }

        public void decreeMovAmount()
        {
            movAmount--;
        }

        public abstract bool[,] possibleMovments();

        protected bool canMove(Position pos)
        {
            Piece p = tab.piece(pos);
            return p == null || p.color != color;
        }

        public bool areTherePossibleMoves()
        {
            bool[,] mat = possibleMovments();
            for (int i = 0; i < tab.rows; i++)
            {
                for (int j = 0; j < tab.cols; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }                
            }
            return false;
        }

        public bool possibleMovment(Position pos)
        {
            return possibleMovments()[pos.row, pos.col];
        }
    }
}