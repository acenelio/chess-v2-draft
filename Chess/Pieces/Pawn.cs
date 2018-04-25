using BoardGame;

namespace Chess.Pieces {
    public class Pawn : ChessPiece {

        private ChessMatch _chessMatch;

        public Pawn(Board board, Color color, ChessMatch chessMatch) : base(board, color) {
            _chessMatch = chessMatch;
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

                // #specialmove en passant white
                if (Position.Row == 3) {
                    Position left = new Position(Position.Row, Position.Column - 1);
                    if (Board.PositionExists(left) && IsThereOpponentPiece(left) && Board.Piece(left) == _chessMatch.EnPassantVulnerable) {
                        mat[left.Row - 1, left.Column] = true;
                    }
                    Position right = new Position(Position.Row, Position.Column + 1);
                    if (Board.PositionExists(right) && IsThereOpponentPiece(right) && Board.Piece(right) == _chessMatch.EnPassantVulnerable) {
                        mat[right.Row - 1, right.Column] = true;
                    }
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

                // #specialmove en passant black
                if (Position.Row == 4) {
                    Position left = new Position(Position.Row, Position.Column - 1);
                    if (Board.PositionExists(left) && IsThereOpponentPiece(left) && Board.Piece(left) == _chessMatch.EnPassantVulnerable) {
                        mat[left.Row + 1, left.Column] = true;
                    }
                    Position right = new Position(Position.Row, Position.Column + 1);
                    if (Board.PositionExists(right) && IsThereOpponentPiece(right) && Board.Piece(right) == _chessMatch.EnPassantVulnerable) {
                        mat[right.Row + 1, right.Column] = true;
                    }
                }
            }

            return mat;
        }

        public override string ToString() {
            return "P";
        }
    }
}