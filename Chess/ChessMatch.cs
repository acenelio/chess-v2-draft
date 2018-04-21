using BoardGame;
using Chess.Pieces;

namespace Chess {
    public class ChessMatch {

        private Board _board;

        public ChessMatch() {
            _board = new Board(8,8);
            InitialSetup();
        }

        public ChessPiece[,] Pieces {
            get {
                ChessPiece[,] mat = new ChessPiece[_board.Rows, _board.Columns];
                for (int i = 0; i < _board.Rows; i++) {
                    for (int j = 0; j < _board.Columns; j++) {
                        mat[i, j] = (ChessPiece) _board.Piece(i, j);
                    }
                }
                return mat;
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
