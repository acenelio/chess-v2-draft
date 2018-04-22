using System;
using System.Collections.Generic;
using Chess;

namespace ChessConsole {
    class UI {

        public static ChessPosition ReadChessPosition() {
            try {
                string s = Console.ReadLine();
                char column = s[0];
                int row = int.Parse(s.Substring(1, 1));
                return new ChessPosition(column, row);
            }
            catch (SystemException) {
                throw new FormatException("Error reading ChessPosition. Valid values are from a1 to h8.");
            }
        }

        public static void PrintMatch(ChessMatch chessMatch, List<ChessPiece> captured) {
            PrintBoard(chessMatch.Pieces);
            Console.WriteLine();
            PrintCapturedPieces(captured);
            Console.WriteLine();
            Console.WriteLine("Turn: " + chessMatch.Turn);
            if (!chessMatch.Checkmate) {
                Console.WriteLine("Waiting player: " + chessMatch.CurrentPlayer);
                if (chessMatch.Check) {
                    Console.WriteLine("CHECK!");
                }
            }
            else {
                Console.WriteLine("CHECKMATE!");
                Console.WriteLine("Winner: " + chessMatch.CurrentPlayer);
            }
        }

        public static void PrintBoard(ChessPiece[,] pieces) {

            for (int i = 0; i < pieces.GetLength(0); i++) {
                Console.Write(8 - i + " ");
                for (int j = 0; j < pieces.GetLength(1); j++) {
                    PrintPiece(pieces[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void PrintBoard(ChessPiece[,] pieces, bool[,] possibleMoves) {

            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor greyBackground = ConsoleColor.DarkGray;

            for (int i = 0; i < pieces.GetLength(0); i++) {
                Console.Write(8 - i + " ");
                for (int j = 0; j < pieces.GetLength(1); j++) {
                    if (possibleMoves[i, j]) {
                        Console.BackgroundColor = greyBackground;
                        PrintPiece(pieces[i, j]);
                        Console.BackgroundColor = originalBackground;
                    }
                    else {
                        PrintPiece(pieces[i, j]);
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = originalBackground;
        }

        private static void PrintPiece(ChessPiece piece) {
            if (piece == null) {
                Console.Write("-");
            }
            else {
                if (piece.Color == Color.White) {
                    Console.Write(piece);
                }
                else {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
            }
            Console.Write(" ");
        }

        private static void PrintCapturedPieces(List<ChessPiece> captured) {
            List<ChessPiece> white = captured.FindAll(item => item.Color == Color.White);
            List<ChessPiece> black = captured.FindAll(item => item.Color == Color.Black);
            Console.WriteLine("Captured pieces:");
            Console.Write("White: ");
            PrintList(white);
            Console.WriteLine();
            Console.Write("Black: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintList(black);
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        private static void PrintList(List<ChessPiece> list) {
            Console.Write("[");
            foreach (ChessPiece x in list) {
                Console.Write(x + " ");
            }
            Console.Write("]");
        }
    }
}
