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
        public void BlockOtherToWin()
        {
            _game.SetMove(0, Player.First);
            _game.SetMove(3, Player.First);
            _game.SetMove(1, Player.Second);
            _game.SetMove(4, Player.Second);

            var (score, index) = Minimax.Instance.MinAlphaBeta(_game);
            _game.SetMove(2, Player.First);
            var (_, max) = Minimax.Instance.MaxAlphaBeta(_game);

            Assert.AreEqual(-1, score);
            Assert.AreEqual(6, index);
            Assert.AreEqual(7, max);
        }

        [Test]
        public void MaximizeChancesToWin()
        {
            _game.SetMove(0, Player.First);
            _game.SetMove(7, Player.First);
            _game.SetMove(1, Player.Second);

            var (score, index) = Minimax.Instance.MaxAlphaBeta(_game);
            Assert.AreEqual(0, score);
            Assert.AreEqual(6, index);
        }

        [Test]
        public void TieGame()
        {
            while (_game.GetWinner() == null)
            {
                int index;
                if (_game.CurrentPlayer == Player.First)
                {
                    (_, index) = Minimax.Instance.MinAlphaBeta(_game);
                }
                else
                {
                    (_, index) = Minimax.Instance.MaxAlphaBeta(_game);
                }

                _game.SetMove(index, _game.CurrentPlayer);
                _game.GoNextPlayer();
            }

            // Players use the same algorithm, so it must be a tie!
            Assert.AreEqual(Player.Empty, _game.GetWinner());
            Assert.AreEqual("| X | X | O |\n| O | O | X |\n| X | O | X |\n", _game.ToString());
        }
    }
}