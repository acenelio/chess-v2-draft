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

        private void InitialSetup() {
            _board.PlacePiece(new Rook(_board, Color.White), new Position(2, 1));
            _board.PlacePiece(new King(_board, Color.Black), new Position(0, 4));
            _board.PlacePiece(new King(_board, Color.White), new Position(7, 4));
        }
    }
}
