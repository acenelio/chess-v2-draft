using BoardGame;

namespace Chess {
    public class ChessPosition {

        public char Column { get; set; }
        public int Row { get; set; }

        public ChessPosition(char column, int row) {
            if (column < 'a' || column > 'h' || row < 1 || row > 8) {
                throw new ChessException("Error instantiating ChessPosition. Valid values are from a1 to h8.");
            }
            Column = column;
            Row = row;
        }

        internal Position ToPosition() {
            return new Position(8 - Row, Column - 'a');
        }

        internal static ChessPosition FromPosition(Position position) {
            return new ChessPosition((char)('a' + position.Column), 8 - position.Row);
        }

        public override string ToString() {
            return "" + Column + Row;
        }
    }
}
