using BoardGame;

namespace Chess.Pieces {
    public class Pawn : ChessPiece {

        public Pawn(Board board, Color color) : base(board, color) {
        }

        public override bool[,] PossibleMoves() {
            bool[,] mat = new bool[Board.Rows, Board.Columns];

            Position p = new Position(0, 0);

            if (Color == Color.White) {
                p.SetValues(Position.Row - 1, Position.Column);
                if (Board.PositionExists(p) && !Board.ThereIsAPiece(p)) {
                    mat[p.Row, p.Column] = true;
                }
                p.SetValues(Position.Row - 2, Position.Column);
                Position p2 = new Position(Position.Row - 1, Position.Column);
                if (Board.PositionExists(p2) && !Board.ThereIsAPiece(p2) && Board.PositionExists(p) && !Board.ThereIsAPiece(p) && MoveCount == 0) {
                    mat[p.Row, p.Column] = true;
                }
                p.SetValues(Position.Row - 1, Position.Column - 1);
                if (Board.PositionExists(p) && IsThereOpponentPiece(p)) {
                    mat[p.Row, p.Column] = true;
                }
                p.SetValues(Position.Row - 1, Position.Column + 1);
                if (Board.PositionExists(p) && IsThereOpponentPiece(p)) {
                    mat[p.Row, p.Column] = true;
                }
            }
            else {
                p.SetValues(Position.Row + 1, Position.Column);
                if (Board.PositionExists(p) && !Board.ThereIsAPiece(p)) {
                    mat[p.Row, p.Column] = true;
                }
                p.SetValues(Position.Row + 2, Position.Column);
                Position p2 = new Position(Position.Row + 1, Position.Column);
                if (Board.PositionExists(p2) && !Board.ThereIsAPiece(p2) && Board.PositionExists(p) && !Board.ThereIsAPiece(p) && MoveCount == 0) {
                    mat[p.Row, p.Column] = true;
                }
                p.SetValues(Position.Row + 1, Position.Column - 1);
                if (Board.PositionExists(p) && IsThereOpponentPiece(p)) {
                    mat[p.Row, p.Column] = true;
                }
                p.SetValues(Position.Row + 1, Position.Column + 1);
                if (Board.PositionExists(p) && IsThereOpponentPiece(p)) {
                    mat[p.Row, p.Column] = true;
                }
            }

            return mat;
        }

        public override string ToString() {
            return "P";
        }
    }
}