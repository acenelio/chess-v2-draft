using BoardGame;

namespace Chess.Pieces {
    public class Knight : ChessPiece {

        public Knight(Board board, Color color) : base(board, color) {
        }

        private bool CanMove(Position position) {
            ChessPiece p = (ChessPiece)Board.Piece(position);
            return p == null || p.Color != Color;
        }

        public override bool[,] PossibleMoves() {
            bool[,] mat = new bool[Board.Rows, Board.Columns];

            Position p = new Position(0, 0);

            p.SetValues(Position.Row - 1, Position.Column - 2);
            if (Board.PositionExists(p) && CanMove(p)) {
                mat[p.Row, p.Column] = true;
            }
            p.SetValues(Position.Row - 2, Position.Column - 1);
            if (Board.PositionExists(p) && CanMove(p)) {
                mat[p.Row, p.Column] = true;
            }
            p.SetValues(Position.Row - 2, Position.Column + 1);
            if (Board.PositionExists(p) && CanMove(p)) {
                mat[p.Row, p.Column] = true;
            }
            p.SetValues(Position.Row - 1, Position.Column + 2);
            if (Board.PositionExists(p) && CanMove(p)) {
                mat[p.Row, p.Column] = true;
            }
            p.SetValues(Position.Row + 1, Position.Column + 2);
            if (Board.PositionExists(p) && CanMove(p)) {
                mat[p.Row, p.Column] = true;
            }
            p.SetValues(Position.Row + 2, Position.Column + 1);
            if (Board.PositionExists(p) && CanMove(p)) {
                mat[p.Row, p.Column] = true;
            }
            p.SetValues(Position.Row + 2, Position.Column - 1);
            if (Board.PositionExists(p) && CanMove(p)) {
                mat[p.Row, p.Column] = true;
            }
            p.SetValues(Position.Row + 1, Position.Column - 2);
            if (Board.PositionExists(p) && CanMove(p)) {
                mat[p.Row, p.Column] = true;
            }

            return mat;
        }

        public override string ToString() {
            return "N";
        }
    }
}
