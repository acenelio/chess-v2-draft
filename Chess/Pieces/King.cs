using BoardGame;

namespace Chess.Pieces {
    public class King : ChessPiece {

        public King(Board board, Color color) : base(board, color) {
        }

        public override bool[,] PossibleMoves() {
            return new bool[Board.Rows, Board.Columns];
        }

        public override string ToString() {
            return "K";
        }
    }
}
