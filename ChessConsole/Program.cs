using System;
using Chess;

namespace ChessConsole {
    class Program {
        static void Main(string[] args) {

            ChessMatch chessMatch = new ChessMatch();

            while (true) {
                try {
                    Console.Clear();
                    UI.PrintBoard(chessMatch.Pieces);
                    Console.WriteLine();
                    Console.Write("Source: ");
                    ChessPosition source = UI.ReadChessPosition();

                    Console.Write("Target: ");
                    ChessPosition target = UI.ReadChessPosition();

                    ChessPiece capturedPiece = chessMatch.PerformChessMove(source, target);
                }
                catch (ChessException e) {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
                catch (FormatException e) {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
            }
        }
    }
}
