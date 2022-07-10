using board;
using chess;
using chessConsole;

namespace Course
{
    class ChessMain
    {
        public ChessMain()
        {
            Run();
        }
        private void Run()
        {
            try
            {
                ChessMatch match = new ChessMatch();

                while (!match.gameOver)
                {
                    try
                    {
                        Console.Clear();
                        Screen.printMatch(match);

                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Position origin = Screen.readChessPosition().toPosition();
                        match.validateOriginPosition(origin);

                        bool[,] possiblePositions = match.tab.piece(origin).possibleMovments();
                        Console.Clear();
                        Screen.printBoard(match.tab, possiblePositions);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Position destiny = Screen.readChessPosition().toPosition();
                        match.validateDestinyPosition(origin, destiny);

                        match.performPlay(origin, destiny);
                    } catch (BoardException e) {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                } 
                Console.Clear();
                Screen.printMatch(match);               
            } catch (BoardException e) {
                Console.WriteLine(e.Message);
            } // */
        }
    }
}