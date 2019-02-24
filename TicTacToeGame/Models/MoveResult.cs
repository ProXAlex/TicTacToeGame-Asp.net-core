namespace TicTacToeGame.Models
{
    public class MoveResult
    {
        private bool _success;
        private int _cellId;
        private Field.State _state;
        private bool _isEnd;
        private Field.State _winner;
        private Field.State[] _cells = new []{Field.State.None, Field.State.None, Field.State.None, Field.State.None, Field.State.None, Field.State.None, Field.State.None, Field.State.None, Field.State.None };

        public bool Success
        {
            get => _success;
            set => _success = value;
        }

        public Field.State[] Cells
        {
            get => _cells;
            set => _cells = value;
        }

        public bool IsEnd
        {
            get => _isEnd;
            set => _isEnd = value;
        }

        public Field.State Winner
        {
            get => _winner;
            set => _winner = value;
        }

        public int ScoreX { get; set; }

        public int ScoreO { get; set; }
    }
}