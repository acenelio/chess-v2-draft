namespace BoardGame {
    public class Piece {

        protected internal Position Position;
        protected Board Board { get; private set; }

        public Piece(Board board) {
            Position = null;
            Board = board;
        }
    }
}
