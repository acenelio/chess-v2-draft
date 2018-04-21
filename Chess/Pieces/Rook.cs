using BoardGame;

namespace Chess.Pieces {
    public class Rook : ChessPiece {

        public Rook(Board board, Color color) : base(board, color) {
        }

        public override string ToString() {
            return "R";
        }
    }
}
