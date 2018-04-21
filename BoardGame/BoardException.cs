using System;

namespace BoardGame {
    public class BoardException : ApplicationException {

        public BoardException(string message) : base(message) {
        }
    }
}
