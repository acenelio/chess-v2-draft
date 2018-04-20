namespace BoardGame {
    public class Board {

        public int Rows { get; set; }
        public int Columns { get; set; }
        private Piece[,] Pieces;

        public Board(int rows, int columns) {
            Rows = rows;
            Columns = columns;
            Pieces = new Piece[rows, columns];
        }
    }
}
