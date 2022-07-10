using board;

namespace chess
{
    class ChessPosition
    {
        public char col { get; set; }
        public int row { get; set; }

        public ChessPosition(char col, int row)
        {
            this.col = col;
            this.row = row;
        }

        public Position toPosition()
        {
            return new Position(8 - row, col - 'a');
        }

        public override string ToString()
        {
            return "" + col + row;
        }
    }
}