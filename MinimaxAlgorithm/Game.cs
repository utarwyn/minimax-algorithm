using System.Collections.Generic;
using System.Linq;

namespace MinimaxAlgorithm
{
    public class Game
    {
        public int Size { get; }

        public Player CurrentPlayer { get; private set; }

        public IEnumerable<int> EmptyCellIndexes => Enumerable.Range(0, _board.Count)
            .Where(index => _board[index] == Player.Empty)
            .ToList();

        private readonly List<Player> _board;

        public Game(int size = 3)
        {
            Size = size;
            CurrentPlayer = Player.First;
            _board = Enumerable.Repeat(Player.Empty, Size * Size).ToList();
        }

        public Game(Game other)
        {
            Size = other.Size;
            CurrentPlayer = other.CurrentPlayer;
            _board = new List<Player>(other._board);
        }

        public bool IsMoveValid(int index)
        {
            return index >= 0 && index < Size * Size && _board[index] == Player.Empty;
        }

        public void SetMove(int index, Player player)
        {
            if (IsMoveValid(index))
            {
                _board[index] = player;
            }
        }

        public Player? GetWinner()
        {
            // Check columns
            for (var col = 0; col < Size; col++)
            {
                if (_board[col] != Player.Empty && _board[col] == _board[col + Size] &&
                    _board[col] == _board[col + Size * 2])
                {
                    return _board[col];
                }
            }

            // Check rows
            for (var row = 0; row < Size; row++)
            {
                var rowIndex = Size * row;
                if (_board[rowIndex] != Player.Empty && _board[rowIndex] == _board[rowIndex + 1] &&
                    _board[rowIndex] == _board[rowIndex + 2])
                {
                    return _board[rowIndex];
                }
            }

            // Check two diagonals
            if (_board[0] != Player.Empty && _board[0] == _board[4] && _board[0] == _board[8])
            {
                return _board[0];
            }

            if (_board[2] != Player.Empty && _board[2] == _board[4] && _board[2] == _board[6])
            {
                return _board[2];
            }

            // Board full?
            if (_board.All(cell => cell != Player.Empty))
            {
                return Player.Empty;
            }

            return null;
        }

        public void GoNextPlayer()
        {
            CurrentPlayer = CurrentPlayer == Player.First ? Player.Second : Player.First;
        }

        public override string ToString()
        {
            var ret = "";
            for (var row = 0; row < Size; row++)
            {
                ret += '|';
                for (var col = 0; col < Size; col++)
                {
                    ret += " " + _board[col + row * Size].ToChar() + " |";
                }

                ret += '\n';
            }

            return ret;
        }
    }
}