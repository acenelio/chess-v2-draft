using System;
using Chess;

namespace ChessConsole {
    class UI {

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
        
        private static void PrintPiece(ChessPiece piece) {
            if (piece == null) {
                Console.Write("-");
            }
            else {
                Console.Write(piece);
            }
            Console.Write(" ");
        }
    }
}
