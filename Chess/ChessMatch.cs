using BoardGame;
using Chess.Pieces;

namespace Chess {
    public class ChessMatch {

        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        private Board _board;

        public ChessMatch() {
            _board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
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

        public bool[,] PossibleMoves(ChessPosition sourcePosition) {
            Position source = sourcePosition.ToPosition();
            ValidadeSourcePosition(source);
            return _board.Piece(source).PossibleMoves();
        }

        public ChessPiece PerformChessMove(ChessPosition sourcePosition, ChessPosition targetPosition) {
            Position source = sourcePosition.ToPosition();
            Position target = targetPosition.ToPosition();
            ValidadeSourcePosition(source);
            ValidateTargetPosition(source, target);

            Piece capturedPiece = MakeMove(source, target);

            NextTurn();

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
            if (CurrentPlayer != (_board.Piece(position) as ChessPiece).Color) {
                throw new ChessException("The chosen piece is not yours");
            }
            if (!_board.Piece(position).IsThereAnyPossibleMove()) {
                throw new ChessException("There is no possible moves for the chosen piece");
            }
        }

        private void ValidateTargetPosition(Position source, Position target) {
            if (!_board.Piece(source).PossibleMove(target)) {
                throw new ChessException("The chosen piece can't move to target position");
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

        private void NextTurn() {
            Turn++;
            CurrentPlayer = (CurrentPlayer == Color.White) ? Color.Black : Color.White;
        }
    }
}
