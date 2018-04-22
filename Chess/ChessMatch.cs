using System;
using System.Collections.Generic;
using BoardGame;
using Chess.Pieces;

namespace Chess {
    public class ChessMatch {

        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Check { get; private set; }
        public bool Checkmate { get; private set; }

        private Board _board;
        private List<Piece> _piecesOnTheBoard;
        private List<Piece> _capturedPieces;

        public ChessMatch() {
            _board = new Board(8, 8);
            _piecesOnTheBoard = new List<Piece>();
            _capturedPieces = new List<Piece>();
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

            if (TestCheck(CurrentPlayer)) {
                UndoMove(source, target, capturedPiece);
                throw new ChessException("You can't put yourself in check");
            }

            Check = (TestCheck(Opponent(CurrentPlayer))) ? true : false;

            if (TestCheckmate(Opponent(CurrentPlayer))) {
                Checkmate = true;
            }
            else {
                NextTurn();
            }

            return (ChessPiece)capturedPiece;
        }

        private Piece MakeMove(Position source, Position target) {
            Piece p = _board.RemovePiece(source);
            (p as ChessPiece).IncreaseMoveCount();
            Piece capturedPiece = _board.RemovePiece(target);
            _board.PlacePiece(p, target);

            if (capturedPiece != null) {
                _piecesOnTheBoard.Remove(capturedPiece);
                _capturedPieces.Add(capturedPiece);
            }

            return capturedPiece;
        }

        private void UndoMove(Position source, Position target, Piece capturedPiece) {
            Piece p = _board.RemovePiece(target);
            (p as ChessPiece).DecreaseMoveCount();
            _board.PlacePiece(p, source);

            if (capturedPiece != null) {
                _board.PlacePiece(capturedPiece, target);
                _piecesOnTheBoard.Add(capturedPiece);
                _capturedPieces.Remove(capturedPiece);
            }
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
            _piecesOnTheBoard.Add(piece);
        }

        private void InitialSetup() {
            PlaceNewPiece('a', 1, new Rook(_board, Color.White));
            PlaceNewPiece('b', 1, new Knight(_board, Color.White));
            PlaceNewPiece('c', 1, new Bishop(_board, Color.White));
            PlaceNewPiece('e', 1, new King(_board, Color.White));
            PlaceNewPiece('f', 1, new Bishop(_board, Color.White));
            PlaceNewPiece('g', 1, new Knight(_board, Color.White));
            PlaceNewPiece('h', 1, new Rook(_board, Color.White));
            PlaceNewPiece('a', 2, new Pawn(_board, Color.White));
            PlaceNewPiece('b', 2, new Pawn(_board, Color.White));
            PlaceNewPiece('c', 2, new Pawn(_board, Color.White));
            PlaceNewPiece('d', 2, new Pawn(_board, Color.White));
            PlaceNewPiece('e', 2, new Pawn(_board, Color.White));
            PlaceNewPiece('f', 2, new Pawn(_board, Color.White));
            PlaceNewPiece('g', 2, new Pawn(_board, Color.White));
            PlaceNewPiece('h', 2, new Pawn(_board, Color.White));

            PlaceNewPiece('a', 8, new Rook(_board, Color.Black));
            PlaceNewPiece('b', 8, new Knight(_board, Color.Black));
            PlaceNewPiece('c', 8, new Bishop(_board, Color.Black));
            PlaceNewPiece('e', 8, new King(_board, Color.Black));
            PlaceNewPiece('f', 8, new Bishop(_board, Color.Black));
            PlaceNewPiece('g', 8, new Knight(_board, Color.Black));
            PlaceNewPiece('h', 8, new Rook(_board, Color.Black));
            PlaceNewPiece('a', 7, new Pawn(_board, Color.Black));
            PlaceNewPiece('b', 7, new Pawn(_board, Color.Black));
            PlaceNewPiece('c', 7, new Pawn(_board, Color.Black));
            PlaceNewPiece('d', 7, new Pawn(_board, Color.Black));
            PlaceNewPiece('e', 7, new Pawn(_board, Color.Black));
            PlaceNewPiece('f', 7, new Pawn(_board, Color.Black));
            PlaceNewPiece('g', 7, new Pawn(_board, Color.Black));
            PlaceNewPiece('h', 7, new Pawn(_board, Color.Black));
        }

        private void NextTurn() {
            Turn++;
            CurrentPlayer = (CurrentPlayer == Color.White) ? Color.Black : Color.White;
        }

        private Color Opponent(Color color) {
            return (color == Color.White) ? Color.Black : Color.White;
        }

        private ChessPiece King(Color color) {
            List<Piece> list = _piecesOnTheBoard.FindAll(x => (x as ChessPiece).Color == color);
            foreach (Piece p in list) {
                if (p is King) {
                    return p as ChessPiece;
                }
            }
            throw new InvalidOperationException("There is no " + color + " king on the board");
        }

        private bool TestCheck(Color color) {
            Position kingPosition = King(color).ChessPosition.ToPosition();
            List<Piece> opponentPieces = _piecesOnTheBoard.FindAll(x => (x as ChessPiece).Color == Opponent(color));
            foreach (Piece p in opponentPieces) {
                bool[,] mat = p.PossibleMoves();
                if (mat[kingPosition.Row, kingPosition.Column]) {
                    return true;
                }
            }
            return false;
        }

        private bool TestCheckmate(Color color) {
            if (!TestCheck(color)) {
                return false;
            }
            List<Piece> list = _piecesOnTheBoard.FindAll(x => (x as ChessPiece).Color == color);
            foreach (ChessPiece p in list) {
                bool[,] mat = p.PossibleMoves();
                for (int i = 0; i < _board.Rows; i++) {
                    for (int j = 0; j < _board.Columns; j++) {
                        if (mat[i, j]) {
                            Position source = p.ChessPosition.ToPosition();
                            Position target = new Position(i, j);
                            Piece capturedPiece = MakeMove(source, target);
                            bool testCheck = TestCheck(color);
                            UndoMove(source, target, capturedPiece);
                            if (!testCheck) {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }
    }
}
