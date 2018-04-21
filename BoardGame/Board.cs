namespace BoardGame {
    public class Board {

        public int Rows { get; set; }
        public int Columns { get; set; }
        private Piece[,] Pieces;

        public Board(int rows, int columns) {
            if (rows < 1 || columns < 1) {
                throw new BoardException("Error creating board: there must be at least 1 row and 1 column");
            }
            Rows = rows;
            Columns = columns;
            Pieces = new Piece[rows, columns];
        }

        public Piece Piece(int row, int column) {
            if (!PositionExists(row, column)) {
                throw new BoardException("Position not on the board");
            }
            return Pieces[row, column];
        }

        public Piece Piece(Position position) {
            if (!PositionExists(position)) {
                throw new BoardException("Position not on the board");
            }
            return Pieces[position.Row, position.Column];
        }

        public void PlacePiece(Piece piece, Position position) {
            if (ThereIsAPiece(position)) {
                throw new BoardException("There is already a piece on position " + position);
            }
            Pieces[position.Row, position.Column] = piece;
            piece.Position = position;
        }

        public Piece RemovePiece(Position position) {
            if (!PositionExists(position)) {
                throw new BoardException("Position not on the board");
            }
            if (Piece(position) == null) {
                return null;
            }
            Piece aux = Piece(position);
            aux.Position = null;
            Pieces[position.Row, position.Column] = null;
            return aux;
        }

        public bool PositionExists(int row, int column) {
            return row >= 0 && row < Rows && column >= 0 && column < Columns;
        }

        public bool PositionExists(Position position) {
            return PositionExists(position.Row, position.Column);
        }

        public bool ThereIsAPiece(Position position) {
            if (!PositionExists(position)) {
                throw new BoardException("Position not on the board");
            }
            return Piece(position) != null;
        }
    }
}
