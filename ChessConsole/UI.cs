﻿using System;
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
    }
}
