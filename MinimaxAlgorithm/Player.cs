using System;

namespace MinimaxAlgorithm
{
    public enum Player
    {
        First,
        Second,
        Empty
    }

    public static class PlayerExtensions
    {
        public static char ToChar(this Player player)
        {
            return player switch
            {
                Player.First => 'X',
                Player.Second => 'O',
                Player.Empty => ' ',
                _ => throw new ArgumentOutOfRangeException(nameof(player), player, null)
            };
        }
    }
}