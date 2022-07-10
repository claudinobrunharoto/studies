using board;
using chess;

namespace chessConsole
{
    class Screen
    {
        public static void printMatch(ChessMatch match)
        {
            printBoard(match.tab);
            Console.WriteLine();
            printCapturedPieces(match);
            Console.WriteLine();
            Console.WriteLine("Turno: " + match.turn);
            if (match.gameOver)
            {
                Console.WriteLine("XEQUEMATE!");
                Console.WriteLine("Vencedor: " + match.currentPlayer);
            } else {
                Console.WriteLine("Aguardando jogada: " + match.currentPlayer);
                if (match.check)
                {
                    Console.WriteLine("XEQUE!");
                }
            }
        }

        private static void printCapturedPieces(ChessMatch match)
        {
            Console.WriteLine("Peças capturadas:");
            Console.Write("Brancas: ");
            printJoint(match.capturedPieces(Color.White));
            Console.WriteLine();
            Console.Write("Pretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            printJoint(match.capturedPieces(Color.Black));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        private static void printJoint(HashSet<Piece> joint)
        {
            Console.Write("[");
            foreach (Piece x in joint)
            {
                Console.Write(x + " ");
            }
            Console.Write("]");
        }

        public static void printBoard(Board tab)
        {
            for (int i = 0; i < tab.rows; i++)
            {
                Console.Write(8 - i + " ");

                for (int j = 0; j < tab.cols; j++)
                {
                    printPiece(tab.piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void printBoard(Board tab, bool[,] possiblePositions)
        {
            ConsoleColor originBackground = Console.BackgroundColor;
            ConsoleColor alteredBackground = ConsoleColor.DarkGray;

            for (int i = 0; i < tab.rows; i++)
            {
                Console.Write(8 - i + " ");

                for (int j = 0; j < tab.cols; j++)
                {
                    if (possiblePositions[i, j])
                    {
                        Console.BackgroundColor = alteredBackground;
                    } else {
                        Console.BackgroundColor = originBackground;
                    }
                    printPiece(tab.piece(i, j));
                    Console.BackgroundColor = originBackground;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static ChessPosition readChessPosition()
        {
            string s = Console.ReadLine();
            char col = s[0];
            int row = int.Parse(s[1] + "");
            return new ChessPosition(col, row);
        }

        public static void printPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            } else {
                if (piece.color == Color.White)
                {
                    Console.Write(piece);
                } else {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }
    }
}