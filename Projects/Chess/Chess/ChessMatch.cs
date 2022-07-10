using board;

namespace chess
{
    class ChessMatch
    {
        public Board tab { get; private set; }
        public int turn { get; private set; }
        public Color currentPlayer { get; private set; }
        public bool gameOver { get; private set; }
        private HashSet<Piece> pieces;
        private HashSet<Piece> captured;
        public bool check { get; private set; }
        public Piece vulnerableEnPassant { get; private set; }

        public ChessMatch()
        {
            tab = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            gameOver = false;
            check = false;
            vulnerableEnPassant = null;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            insertPieces();
        }

        private void changePlayer()
        {
            if (currentPlayer == Color.White)
            {
                currentPlayer = Color.Black;
            } else {
                currentPlayer = Color.White;
            }
        }

        public void validateOriginPosition(Position pos)
        {
            if (tab.piece(pos) == null)
            {
                throw new BoardException("Não existe peça na posição de origem escolhida!");
            }
            if (currentPlayer != tab.piece(pos).color)
            {
                throw new BoardException("A peça de origem escolhida não é sua!");
            }
            if (!tab.piece(pos).areTherePossibleMoves())
            {
               throw new BoardException("Não há movimentos possíveis para a pela de origem escolhida!");
            }
        }

        public void validateDestinyPosition(Position origin, Position destiny)
        {
            if (!tab.piece(origin).possibleMovment(destiny))
            {
                throw new BoardException("Posição de destino inválida!");
            }
        }

        private void undoMovment(Position origin, Position destiny, Piece capturedPiece)
        {
            Piece p = tab.removePiece(destiny);
            p.decreeMovAmount();
            if (capturedPiece != null)
            {
                tab.putPiece(capturedPiece, destiny);
                captured.Remove(capturedPiece);
            }
            tab.putPiece(p, origin);

            // #specialMoves -> kingside castling (roque pequeno)
            if (p is King && destiny.col == origin.col + 2)
            {
                Position origenRook = new Position(origin.row, origin.col + 3);
                Position destinyRook = new Position(origin.row, origin.col + 1);
                Piece rook = tab.removePiece(destinyRook);
                rook.decreeMovAmount();
                tab.putPiece(rook, origenRook);
            }

            // #specialMoves -> queenside castling (roque grande)
            if (p is King && destiny.col == origin.col - 2)
            {
                Position origenRook = new Position(origin.row, origin.col - 4);
                Position destinyRook = new Position(origin.row, origin.col - 1);
                Piece rook = tab.removePiece(destinyRook);
                rook.decreeMovAmount();
                tab.putPiece(rook, origenRook);
            }

            // #specialMoves -> En Passant
            if (p is Pawn)
            {
                if (origin.col != destiny.col && capturedPiece == vulnerableEnPassant)
                {
                    Piece pawn = tab.removePiece(destiny);
                    Position posPawn = (p.color == Color.White) ? new Position(3, destiny.col) : new Position(4, destiny.col);
                    tab.putPiece(pawn, posPawn);
                }
            }
        }

        private Piece movimentExecution(Position origin, Position destiny)
        {
            Piece p = tab.removePiece(origin);
            p.incMovAmount();
            Piece capturedPiece = tab.removePiece(destiny);
            tab.putPiece(p, destiny);
            if (capturedPiece != null)
            {
                captured.Add(capturedPiece);
            }

            // #specialMoves -> kingside castling (roque pequeno)
            if (p is King && destiny.col == origin.col + 2)
            {
                Position origenRook = new Position(origin.row, origin.col + 3);
                Position destinyRook = new Position(origin.row, origin.col + 1);
                Piece rook = tab.removePiece(origenRook);
                rook.incMovAmount();
                tab.putPiece(rook, destinyRook);
            }

            // #specialMoves -> queenside castling (roque grande)
            if (p is King && destiny.col == origin.col - 2)
            {
                Position origenRook = new Position(origin.row, origin.col - 4);
                Position destinyRook = new Position(origin.row, origin.col - 1);
                Piece rook = tab.removePiece(origenRook);
                rook.incMovAmount();
                tab.putPiece(rook, destinyRook);
            }

            // #specialMoves -> En Passant
            if (p is Pawn)
            {
                if (origin.col != destiny.col && capturedPiece == null)
                {
                    Position posPawn = (p.color == Color.White) ? new Position(destiny.row + 1, destiny.col) : new Position(destiny.row - 1, destiny.col);
                    capturedPiece = tab.removePiece(posPawn);
                    captured.Add(capturedPiece);
                }
            }

            return capturedPiece;
        }

        public void performPlay(Position origin, Position destiny)
        {
            Piece capturedPiece = movimentExecution(origin, destiny);

            if (isInCheck(currentPlayer))
            {
                undoMovment(origin, destiny, capturedPiece);
                throw new BoardException("Você não pode se colocar em xeque!");
            }

            Piece p = tab.piece(destiny);

            // #specialMoves -> Promotion
            if (p is Pawn)
            {
                if ((p.color == Color.White && destiny.row == 0) || (p.color == Color.Black && destiny.row == 7))
                {
                    p = tab.removePiece(destiny);
                    pieces.Remove(p);
                    Piece queen = new Queen(tab, p.color);
                    tab.putPiece(queen, destiny);
                    pieces.Add(queen);
                }
            }

            check = isInCheck(adversary(currentPlayer));

            if (isInCheckmate(adversary(currentPlayer)))
            {
                gameOver = true;
            } else {
                turn++;
                changePlayer();
            }

            // #specialMoves -> En Passant
            if (p is Pawn && (destiny.row == origin.row - 2 || destiny.row == origin.row + 2))
            {
                vulnerableEnPassant = p;
            } else {
                vulnerableEnPassant = null;
            }
        }

        public HashSet<Piece> capturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in captured)
            {
                if (x.color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        private Color adversary(Color color)
        {
            return (color == Color.White) ? Color.Black : Color.White;
        }

        private Piece king(Color color)
        {
            foreach (Piece x in piecesInGame(color))
            {
                if (x is King)
                {
                    return x;
                }
            }
            return null;
        }

        public bool isInCheck(Color color)
        {
            Piece R = king(color);
            if (R == null)
            {
                throw new BoardException("Não há rei na cor " + color + " no tabuleiro!");
            }
            foreach (Piece x in piecesInGame(adversary(color)))
            {
                bool[,] mat = x.possibleMovments();
                if (mat[R.position.row, R.position.col])
                {
                    return true;
                }
            }
            return false;
        }

        public bool isInCheckmate(Color color)
        {
            if (!isInCheck(color))
            {
                return false;
            }

            foreach (Piece x in piecesInGame(color))
            {
                bool[,] mat = x.possibleMovments();
                for (int i = 0; i < tab.rows; i++)
                {
                    for (int j = 0; j < tab.cols; j++)
                    {
                        if (mat[i, j])
                        {
                            Position origen = x.position;
                            Position destiny = new Position(i, j);
                            Piece capturedPiece = movimentExecution(origen, destiny);
                            bool testCheck = isInCheck(color);
                            undoMovment(origen, destiny, capturedPiece);
                            if (!testCheck)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public HashSet<Piece> piecesInGame(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in pieces)
            {
                if (x.color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(capturedPieces(color));
            return aux;
        }

        public void insertNewPiece(char col, int row, Piece piece)
        {
            tab.putPiece(piece, new ChessPosition(col, row).toPosition());
            pieces.Add(piece);
        }

        private void insertPieces()
        {
            insertNewPiece('a', 1, new Rook(tab, Color.White));
            insertNewPiece('b', 1, new Knight(tab, Color.White));
            insertNewPiece('c', 1, new Bishop(tab, Color.White));
            insertNewPiece('d', 1, new Queen(tab, Color.White));
            insertNewPiece('e', 1, new King(tab, Color.White, this));
            insertNewPiece('f', 1, new Bishop(tab, Color.White));
            insertNewPiece('g', 1, new Knight(tab, Color.White));
            insertNewPiece('h', 1, new Rook(tab, Color.White));
            insertNewPiece('a', 2, new Pawn(tab, Color.White, this));
            insertNewPiece('b', 2, new Pawn(tab, Color.White, this));
            insertNewPiece('c', 2, new Pawn(tab, Color.White, this));
            insertNewPiece('d', 2, new Pawn(tab, Color.White, this));
            insertNewPiece('e', 2, new Pawn(tab, Color.White, this));
            insertNewPiece('f', 2, new Pawn(tab, Color.White, this));
            insertNewPiece('g', 2, new Pawn(tab, Color.White, this));
            insertNewPiece('h', 2, new Pawn(tab, Color.White, this));

            insertNewPiece('a', 8, new Rook(tab, Color.Black));
            insertNewPiece('b', 8, new Knight(tab, Color.Black));
            insertNewPiece('c', 8, new Bishop(tab, Color.Black));
            insertNewPiece('d', 8, new Queen(tab, Color.Black));
            insertNewPiece('e', 8, new King(tab, Color.Black, this));
            insertNewPiece('f', 8, new Bishop(tab, Color.Black));
            insertNewPiece('g', 8, new Knight(tab, Color.Black));
            insertNewPiece('h', 8, new Rook(tab, Color.Black));
            insertNewPiece('a', 7, new Pawn(tab, Color.Black, this));
            insertNewPiece('b', 7, new Pawn(tab, Color.Black, this));
            insertNewPiece('c', 7, new Pawn(tab, Color.Black, this));
            insertNewPiece('d', 7, new Pawn(tab, Color.Black, this));
            insertNewPiece('e', 7, new Pawn(tab, Color.Black, this));
            insertNewPiece('f', 7, new Pawn(tab, Color.Black, this));
            insertNewPiece('g', 7, new Pawn(tab, Color.Black, this));
            insertNewPiece('h', 7, new Pawn(tab, Color.Black, this));
        }
    }
}