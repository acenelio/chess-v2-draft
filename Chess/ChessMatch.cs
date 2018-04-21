using BoardGame;

namespace Chess {
    public class ChessMatch {

        private Board _board;

        public ChessMatch() {
            _board = new Board(8,8);
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
    }
}
