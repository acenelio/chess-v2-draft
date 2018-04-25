using System;
using System.Collections.Generic;
using Chess;

namespace ChessConsole {
    class Program {
        static void Main(string[] args) {

            ChessMatch chessMatch = new ChessMatch();
            List<ChessPiece> captured = new List<ChessPiece>();

            while (!chessMatch.Checkmate) {
                try {
                    Console.Clear();
                    UI.PrintMatch(chessMatch, captured);
                    Console.WriteLine();
                    Console.Write("Source: ");
                    ChessPosition source = UI.ReadChessPosition();

                    bool[,] possibleMoves = chessMatch.PossibleMoves(source);
                    Console.Clear();
                    UI.PrintBoard(chessMatch.Pieces, possibleMoves);
                    Console.WriteLine();
                    Console.Write("Target: ");
                    ChessPosition target = UI.ReadChessPosition();

                    ChessPiece capturedPiece = chessMatch.PerformChessMove(source, target);

                    if (capturedPiece != null) {
                        captured.Add(capturedPiece);
                    }

                    if (chessMatch.Promoted != null) {
                        Console.Write("Enter piece for promotion (B/N/R/Q): ");
                        string type = Console.ReadLine();
                        chessMatch.ReplacePromotedPiece(type);
                    }
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
            Console.Clear();
            UI.PrintMatch(chessMatch, captured);
        }
    }
}
