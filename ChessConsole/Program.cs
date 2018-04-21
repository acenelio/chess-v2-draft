using System;
using Chess;

namespace ChessConsole {
    class Program {
        static void Main(string[] args) {

            ChessMatch chessMatch = new ChessMatch();

            UI.PrintBoard(chessMatch.Pieces);
        }
    }
}
