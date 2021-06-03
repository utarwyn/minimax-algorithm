using System.Collections.Generic;
using System.Linq;

namespace MinimaxAlgorithm
{
    public class Game
    {
        public int Size { get; }

        public char Player { get; }

        private readonly List<char> _board;

        public Game(int size = 3)
        {
            _board = new List<char>();
            Size = size;
            Player = 'X';
        }

        public void Initialize()
        {
            char[] array = {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '};
            _board.Clear();
            _board.AddRange(array);
        }

        public bool IsMoveValid(int index)
        {
            return index >= 0 && index < Size * Size && _board[index] == ' ';
        }

        public void SetMove(int index, char player)
        {
            if (IsMoveValid(index))
            {
                _board[index] = player;
            }
        }

        public char? GetWinner()
        {
            // Check columns
            for (var col = 0; col < Size; col++)
            {
                if (_board[col] != ' ' && _board[col] == _board[col + Size] && _board[col] == _board[col + Size * 2])
                {
                    return _board[col];
                }
            }

            // Check rows
            for (var row = 0; row < Size; row++)
            {
                var rowIndex = Size * row;
                if (_board[rowIndex] != ' ' && _board[rowIndex] == _board[rowIndex + 1] &&
                    _board[rowIndex] == _board[rowIndex + 2])
                {
                    return _board[rowIndex];
                }
            }

            // Check two diagonals
            if (_board[0] != ' ' && _board[0] == _board[4] && _board[0] == _board[8])
            {
                return _board[0];
            }

            if (_board[2] != ' ' && _board[2] == _board[4] && _board[2] == _board[6])
            {
                return _board[2];
            }

            // Board full?
            if (_board.All(cell => cell != ' '))
            {
                return ' ';
            }

            return null;
        }

        public override string ToString()
        {
            var ret = "";
            for (var row = 0; row < Size; row++)
            {
                ret += "|";
                for (var col = 0; col < Size; col++)
                {
                    ret += " " + _board[col + row * Size] + " |";
                }

                ret += "\n";
            }

            return ret;
        }
    }
}