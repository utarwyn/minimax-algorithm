using System;
using System.Threading;
using MinimaxAlgorithm;
using NUnit.Framework;

namespace MinimaxTests
{
    [TestFixture]
    public class MinimaxTest
    {
        private Game _game;

        [SetUp]
        public void Setup()
        {
            _game = new Game();
        }

        [Test]
        public void MaxAlphaBeta()
        {
            while (_game.GetWinner() == null)
            {
                if (_game.CurrentPlayer == Player.First)
                {
                    var (_, index) = Minimax.Instance.MinAlphaBeta(_game);
                    _game.SetMove(index, _game.CurrentPlayer);
                }
                else
                {
                    var (_, index) = Minimax.Instance.MaxAlphaBeta(_game);
                    _game.SetMove(index, _game.CurrentPlayer);
                }

                Console.WriteLine(_game);
                _game.GoNextPlayer();
            }
            
            Console.WriteLine($"And the winner is {_game.GetWinner()?.ToString()}!");
        }
    }
}