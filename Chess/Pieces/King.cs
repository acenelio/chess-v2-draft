using BoardGame;

namespace Chess.Pieces {
    public class King : ChessPiece {

        private ChessMatch _chessMatch;

        public King(Board board, Color color, ChessMatch chessMatch) : base(board, color) {
            _chessMatch = chessMatch;
        }

        private bool CanMove(Position position) {
            ChessPiece p = (ChessPiece)Board.Piece(position);
            return p == null || p.Color != Color;
        }

        private bool TestRookCastling(Position position) {
            ChessPiece p = (ChessPiece)Board.Piece(position);
            return p != null && p is Rook && p.Color == Color && p.MoveCount == 0;
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

            // #specialmove castling
            if (MoveCount == 0 && !_chessMatch.Check) {
                // #specialmove castling kingside rook
                Position posT1 = new Position(Position.Row, Position.Column + 3);
                if (TestRookCastling(posT1)) {
                    Position p1 = new Position(Position.Row, Position.Column + 1);
                    Position p2 = new Position(Position.Row, Position.Column + 2);
                    if (Board.Piece(p1) == null && Board.Piece(p2) == null) {
                        mat[Position.Row, Position.Column + 2] = true;
                    }
                }
                // #specialmove castling queenside rook
                Position posT2 = new Position(Position.Row, Position.Column - 4);
                if (TestRookCastling(posT2)) {
                    Position p1 = new Position(Position.Row, Position.Column - 1);
                    Position p2 = new Position(Position.Row, Position.Column - 2);
                    Position p3 = new Position(Position.Row, Position.Column - 3);
                    if (Board.Piece(p1) == null && Board.Piece(p2) == null && Board.Piece(p3) == null) {
                        mat[Position.Row, Position.Column - 2] = true;
                    }
                }
            }

            return mat;
        }

        public override string ToString() {
            return "K";
        }
    }
}
