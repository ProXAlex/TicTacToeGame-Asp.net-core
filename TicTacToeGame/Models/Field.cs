using System;
using System.Linq;

namespace TicTacToeGame.Models
{
    public class Field
    {
        private bool _isBotEnabled;

        public int ScoreX { get; set; }
        public int ScoreO { get; set; }

        public enum State
        {
            None,
            X,
            O
        }

        public State LastMove { get; set; }

        public State FirstMove { get; set; } = State.X;

        public bool IsEnd { get; set; }


        public State[] Cells { get; set; } = new State[] { State.None, State.None, State.None, State.None, State.None, State.None, State.None, State.None, State.None };

        public bool IsBotEnabled
        {
            get => _isBotEnabled;
            set => _isBotEnabled = value;
        }


        public void NewGame()
        {
            IsEnd = false;
            LastMove = State.None;
            FirstMove = State.X;
            Cells = new State[] { State.None, State.None, State.None, State.None, State.None, State.None, State.None, State.None, State.None };
            
        }

        public void ResetScores()
        {
            ScoreX = ScoreO = 0;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cellId"></param>
        /// <returns>true - if move is correct</returns>
        public MoveResult Move(int cellId)
        {

            MoveResult result = new MoveResult();

            if (IsEnd)
                return result;
            if (cellId > Cells.Length)
                throw new ArgumentException("Индекс не может быть больше чем количество ячеек");
            if (cellId < 0)
                throw new ArgumentException("Индекс не может быть отрицательным");

            if (Cells[cellId] != State.None)
                return result;

            
            switch (LastMove)
            {
                case State.O:
                    LastMove = State.X;
                    break;
                case State.X:
                    LastMove = State.O;
                    break;
                case State.None:
                    LastMove = FirstMove;
                    break;

            }


            Cells[cellId] = LastMove;
            //LastMove = currentMove;
            var winner = CheckWinner();
            if (IsBotEnabled && LastMove == State.X && winner == State.None && !IsEnd)
            {
                var CountEmptyCells = Cells.Count(state => state == State.None);
                int RandomCell = new Random().Next(CountEmptyCells);

                for (int i = 0; i <= RandomCell; i++)
                {
                    if (Cells[i] != State.None)
                    {
                        RandomCell++;
                        continue;
                    }

                    if (i == RandomCell)
                        Cells[i] = State.O;
                }


                LastMove = State.O;
                winner = CheckWinner();
            }


            if (winner != State.None)
            {
                IsEnd = true;
                result.Winner = LastMove;
                result.IsEnd = IsEnd;
                switch (winner)
                {
                    case State.X:
                        ScoreX++;
                        break;
                    case State.O:
                        ScoreO++;
                        break;
                }
            }


            result.Cells = Cells;
            result.Success = true;
            result.IsEnd = IsEnd;
            result.ScoreO = ScoreO;
            result.ScoreX = ScoreX;

            return result;
        }

        /// <summary>
        /// Check Winner
        /// </summary>
        /// <returns></returns>
        private State CheckWinner()
        {
            if (Cells.Where((state, i) => i == 0 || i == 1 || i == 2).Count(state => state == State.O) == 3 ||
                Cells.Where((state, i) => i == 0 || i == 1 || i == 2).Count(state => state == State.X) == 3)
            {
                return Cells[0];
            }
            if (Cells.Where((state, i) => i == 3 || i == 4 || i == 5).Count(s => s == State.O ) == 3 ||
                Cells.Where((state, i) => i == 3 || i == 4 || i == 5).Count(s => s == State.X) == 3)
            {
                return Cells[3];
            }
            if (Cells.Where((state, i) => i == 6 || i == 7 || i == 8).Count(s => s == State.O) == 3 ||
                Cells.Where((state, i) => i == 6 || i == 7 || i == 8).Count(s => s == State.X) == 3)
            {
                return Cells[6];
            }
            if (Cells.Where((state, i) => i == 0 || i == 4 || i == 8).Count(s => s == State.O) == 3 ||
                Cells.Where((state, i) => i == 0 || i == 4 || i == 8).Count(s => s == State.X) == 3)
            {
                return Cells[0];
            }
            if (Cells.Where((state, i) => i == 2 || i == 4 || i == 6).Count(s => s == State.O) == 3 ||
                Cells.Where((state, i) => i == 2 || i == 4 || i == 6).Count(s => s == State.X) == 3)
            {
                return Cells[2];
            }
            if (Cells.Where((state, i) => i == 0 || i == 3 || i == 6).Count(s => s == State.O) == 3 ||
                Cells.Where((state, i) => i == 0 || i == 3 || i == 6).Count(s => s == State.X) == 3)
            {
                return Cells[0];
            }
            if (Cells.Where((state, i) => i == 1 || i == 4 || i == 7).Count(s => s == State.O) == 3 ||
                Cells.Where((state, i) => i == 1 || i == 4 || i == 7).Count(s => s == State.X) == 3)
            {
                return Cells[1];
            }
            if (Cells.Where((state, i) => i == 2 || i == 5 || i == 8).Count(s => s == State.O) == 3 ||
                Cells.Where((state, i) => i == 2 || i == 5 || i == 8).Count(s => s == State.X) == 3)
            {
                return Cells[2];
            }

            if (Cells.All(state => state != State.None))
            {
                IsEnd = true;
            }
            


            return State.None;

        }
    }
}