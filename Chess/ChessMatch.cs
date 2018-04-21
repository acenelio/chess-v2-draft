using BoardGame;
using Chess.Pieces;

namespace Chess {
    public class ChessMatch {

        private Board _board;

        public ChessMatch() {
            _board = new Board(8, 8);
            InitialSetup();
        }

        public ChessPiece[,] Pieces {
            get {
                ChessPiece[,] mat = new ChessPiece[_board.Rows, _board.Columns];
                for (int i = 0; i < _board.Rows; i++) {
                    for (int j = 0; j < _board.Columns; j++) {
                        mat[i, j] = (ChessPiece)_board.Piece(i, j);
                    }
                }
                return mat;
            }
        }

        public ChessPiece PerformChessMove(ChessPosition sourcePosition, ChessPosition targetPosition) {
            Position source = sourcePosition.ToPosition();
            Position target = targetPosition.ToPosition();
            ValidadeSourcePosition(source);
            Piece capturedPiece = MakeMove(source, target);
            return (ChessPiece)capturedPiece;
        }

        private Piece MakeMove(Position source, Position target) {
            Piece p = _board.RemovePiece(source);
            Piece capturedPiece = _board.RemovePiece(target);
            _board.PlacePiece(p, target);
            return capturedPiece;
        }

        private void ValidadeSourcePosition(Position position) {
            if (_board.Piece(position) == null) {
                throw new ChessException("There is no piece on source position");
            }
        }

        private void PlaceNewPiece(char column, int row, ChessPiece piece) {
            _board.PlacePiece(piece, new ChessPosition(column, row).ToPosition());
        }

        private void InitialSetup() {
            PlaceNewPiece('c', 1, new Rook(_board, Color.White));
            PlaceNewPiece('c', 2, new Rook(_board, Color.White));
            PlaceNewPiece('d', 2, new Rook(_board, Color.White));
            PlaceNewPiece('e', 2, new Rook(_board, Color.White));
            PlaceNewPiece('e', 1, new Rook(_board, Color.White));
            PlaceNewPiece('d', 1, new King(_board, Color.White));

            PlaceNewPiece('c', 7, new Rook(_board, Color.Black));
            PlaceNewPiece('c', 8, new Rook(_board, Color.Black));
            PlaceNewPiece('d', 7, new Rook(_board, Color.Black));
            PlaceNewPiece('e', 7, new Rook(_board, Color.Black));
            PlaceNewPiece('e', 8, new Rook(_board, Color.Black));
            PlaceNewPiece('d', 8, new King(_board, Color.Black));
        }
    }
}
