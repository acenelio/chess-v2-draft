using BoardGame;

namespace Chess.Pieces {
    public class Bishop : ChessPiece {

        public Bishop(Board board, Color color) : base(board, color) {
        }

        public override bool[,] PossibleMoves() {
            bool[,] mat = new bool[Board.Rows, Board.Columns];

            Position p = new Position(0, 0);

            // nw
            p.SetValues(Position.Row - 1, Position.Column - 1);
            while (Board.PositionExists(p) && !Board.ThereIsAPiece(p)) {
                mat[p.Row, p.Column] = true;
                p.SetValues(p.Row - 1, p.Column - 1);
            }
            if (Board.PositionExists(p) &&  IsThereOpponentPiece(p)) {
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
            return "B";
        }
    }
}