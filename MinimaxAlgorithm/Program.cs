using System;

namespace MinimaxAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            game.Initialize();
            Console.Write(game);
        }
    }
}