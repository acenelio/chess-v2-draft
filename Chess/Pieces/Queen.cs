using BoardGame;

namespace Chess.Pieces {
    public class Queen : ChessPiece {

        public Queen(Board board, Color color) : base(board, color) {
        }

        public override bool[,] PossibleMoves() {
            bool[,] mat = new bool[Board.Rows, Board.Columns];

            Position p = new Position(0, 0);

            // above
            p.SetValues(Position.Row - 1, Position.Column);
            while (Board.PositionExists(p) && !Board.ThereIsAPiece(p)) {
                mat[p.Row, p.Column] = true;
                p.Row = p.Row - 1;
            }
            if (Board.PositionExists(p) && IsThereOpponentPiece(p)) {
                mat[p.Row, p.Column] = true;
            }

            // below
            p.SetValues(Position.Row + 1, Position.Column);
            while (Board.PositionExists(p) && !Board.ThereIsAPiece(p)) {
                mat[p.Row, p.Column] = true;
                p.Row = p.Row + 1;
            }
            if (Board.PositionExists(p) && IsThereOpponentPiece(p)) {
                mat[p.Row, p.Column] = true;
            }

            // right
            p.SetValues(Position.Row, Position.Column + 1);
            while (Board.PositionExists(p) && !Board.ThereIsAPiece(p)) {
                mat[p.Row, p.Column] = true;
                p.Column = p.Column + 1;
            }
            if (Board.PositionExists(p) && IsThereOpponentPiece(p)) {
                mat[p.Row, p.Column] = true;
            }

            // left
            p.SetValues(Position.Row, Position.Column - 1);
            while (Board.PositionExists(p) && !Board.ThereIsAPiece(p)) {
                mat[p.Row, p.Column] = true;
                p.Column = p.Column - 1;
            }
            if (Board.PositionExists(p) && IsThereOpponentPiece(p)) {
                mat[p.Row, p.Column] = true;
            }

            // nw
            p.SetValues(Position.Row - 1, Position.Column - 1);
            while (Board.PositionExists(p) && !Board.ThereIsAPiece(p)) {
                mat[p.Row, p.Column] = true;
                p.SetValues(p.Row - 1, p.Column - 1);
            }
            if (Board.PositionExists(p) && IsThereOpponentPiece(p)) {
                mat[p.Row, p.Column] = true;
            }

            // ne
            p.SetValues(Position.Row - 1, Position.Column + 1);
            while (Board.PositionExists(p) && !Board.ThereIsAPiece(p)) {
                mat[p.Row, p.Column] = true;
                p.SetValues(p.Row - 1, p.Column + 1);
            }
            if (Board.PositionExists(p) && IsThereOpponentPiece(p)) {
                mat[p.Row, p.Column] = true;
            }

            // se
            p.SetValues(Position.Row + 1, Position.Column + 1);
            while (Board.PositionExists(p) && !Board.ThereIsAPiece(p)) {
                mat[p.Row, p.Column] = true;
                p.SetValues(p.Row + 1, p.Column + 1);
            }
            if (Board.PositionExists(p) && IsThereOpponentPiece(p)) {
                mat[p.Row, p.Column] = true;
            }

            // sw
            p.SetValues(Position.Row + 1, Position.Column - 1);
            while (Board.PositionExists(p) && !Board.ThereIsAPiece(p)) {
                mat[p.Row, p.Column] = true;
                p.SetValues(p.Row + 1, p.Column - 1);
            }
            if (Board.PositionExists(p) && IsThereOpponentPiece(p)) {
                mat[p.Row, p.Column] = true;
            }

            return mat;
        }

        public override string ToString() {
            return "Q";
        }
    }
}
