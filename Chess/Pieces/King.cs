using BoardGame;

namespace Chess.Pieces {
    public class King : ChessPiece {

        public King(Board board, Color color) : base(board, color) {
        }

        private bool CanMove(Position position) {
            ChessPiece p = (ChessPiece)Board.Piece(position);
            return p == null || p.Color != Color;
        }

        public override bool[,] PossibleMoves() {
            bool[,] mat = new bool[Board.Rows, Board.Columns];

            Position p = new Position(0, 0);

            // above
            p.SetValues(Position.Row - 1, Position.Column);
            if (Board.PositionExists(p) && CanMove(p)) {
                mat[p.Row, p.Column] = true;
            }
            // ne
            p.SetValues(Position.Row - 1, Position.Column + 1);
            if (Board.PositionExists(p) && CanMove(p)) {
                mat[p.Row, p.Column] = true;
            }
            // right
            p.SetValues(Position.Row, Position.Column + 1);
            if (Board.PositionExists(p) && CanMove(p)) {
                mat[p.Row, p.Column] = true;
            }
            // se
            p.SetValues(Position.Row + 1, Position.Column + 1);
            if (Board.PositionExists(p) && CanMove(p)) {
                mat[p.Row, p.Column] = true;
            }
            // below
            p.SetValues(Position.Row + 1, Position.Column);
            if (Board.PositionExists(p) && CanMove(p)) {
                mat[p.Row, p.Column] = true;
            }
            // sw
            p.SetValues(Position.Row + 1, Position.Column - 1);
            if (Board.PositionExists(p) && CanMove(p)) {
                mat[p.Row, p.Column] = true;
            }
            // left
            p.SetValues(Position.Row, Position.Column - 1);
            if (Board.PositionExists(p) && CanMove(p)) {
                mat[p.Row, p.Column] = true;
            }
            // nw
            p.SetValues(Position.Row - 1, Position.Column - 1);
            if (Board.PositionExists(p) && CanMove(p)) {
                mat[p.Row, p.Column] = true;
            }

            return mat;
        }

        public override string ToString() {
            return "K";
        }
    }
}
