using BoardGame;

namespace Chess.Pieces {
    public class Rook : ChessPiece {

        public Rook(Board board, Color color) : base(board, color) {
        }

        public override bool[,] PossibleMoves() {
            bool[,] mat = new bool[Board.Rows, Board.Columns];

            Position p = new Position(0, 0);

            // above
            p.setValues(Position.Row - 1, Position.Column);
            while (Board.PositionExists(p) && !Board.ThereIsAPiece(p)) {
                mat[p.Row, p.Column] = true;
                p.Row = p.Row - 1;
            }
            if (Board.PositionExists(p) && IsThereOpponentPiece(p)) {
                mat[p.Row, p.Column] = true;
            }

            // below
            p.setValues(Position.Row + 1, Position.Column);
            while (Board.PositionExists(p) && !Board.ThereIsAPiece(p)) {
                mat[p.Row, p.Column] = true;
                p.Row = p.Row + 1;
            }
            if (Board.PositionExists(p) && IsThereOpponentPiece(p)) {
                mat[p.Row, p.Column] = true;
            }

            // right
            p.setValues(Position.Row, Position.Column + 1);
            while (Board.PositionExists(p) && !Board.ThereIsAPiece(p)) {
                mat[p.Row, p.Column] = true;
                p.Column = p.Column + 1;
            }
            if (Board.PositionExists(p) && IsThereOpponentPiece(p)) {
                mat[p.Row, p.Column] = true;
            }

            // left
            p.setValues(Position.Row, Position.Column - 1);
            while (Board.PositionExists(p) && !Board.ThereIsAPiece(p)) {
                mat[p.Row, p.Column] = true;
                p.Column = p.Column - 1;
            }
            if (Board.PositionExists(p) && IsThereOpponentPiece(p)) {
                mat[p.Row, p.Column] = true;
            }

            return mat;
        }

        public override string ToString() {
            return "R";
        }
    }
}
