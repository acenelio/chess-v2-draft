using BoardGame;

namespace Chess.Pieces {
    public class Rook : ChessPiece {

        public Rook(Board board, Color color) : base(board, color) {
        }

        public override bool[,] PossibleMoves() {
            return new bool[Board.Rows, Board.Columns];
        }

        public override string ToString() {
            return "R";
        }
    }
}
