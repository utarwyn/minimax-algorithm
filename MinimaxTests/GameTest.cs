using MinimaxAlgorithm;
using NUnit.Framework;

namespace MinimaxTests
{
    [TestFixture]
    public class GameTests
    {
        private Game _game;

        [SetUp]
        public void Setup()
        {
            _game = new Game();
        }

        [Test]
        public void Initialize()
        {
            Assert.AreEqual(3, _game.Size);
            Assert.AreEqual(Player.First, _game.CurrentPlayer);
            Assert.IsNull(_game.GetWinner());
        }

        [Test]
        public void IsMoveValid()
        {
            // Check invalid cells
            Assert.IsFalse(_game.IsMoveValid(-1));
            Assert.IsFalse(_game.IsMoveValid(9));

            // Check for a valid cell
            Assert.IsTrue(_game.IsMoveValid(8));
            _game.SetMove(8, Player.First);
            Assert.IsFalse(_game.IsMoveValid(8));
        }

        [Test]
        public void GetWinnerWithColumn()
        {
            _game.SetMove(1, Player.First);
            Assert.IsNull(_game.GetWinner());
            _game.SetMove(4, Player.First);
            Assert.IsNull(_game.GetWinner());
            _game.SetMove(7, Player.First);
            Assert.AreEqual(Player.First, _game.GetWinner());
        }

        [Test]
        public void GetWinnerWithRow()
        {
            _game.SetMove(7, Player.Second);
            Assert.IsNull(_game.GetWinner());
            _game.SetMove(8, Player.Second);
            Assert.IsNull(_game.GetWinner());
            _game.SetMove(6, Player.Second);
            Assert.AreEqual(Player.Second, _game.GetWinner());
        }

        [Test]
        public void GetWinnerWithDiagonal1()
        {
            _game.SetMove(0, Player.First);
            Assert.IsNull(_game.GetWinner());
            _game.SetMove(4, Player.First);
            Assert.IsNull(_game.GetWinner());
            _game.SetMove(8, Player.First);
            Assert.AreEqual(Player.First, _game.GetWinner());
        }

        [Test]
        public void GetWinnerWithDiagonal2()
        {
            _game.SetMove(2, Player.Second);
            Assert.IsNull(_game.GetWinner());
            _game.SetMove(4, Player.Second);
            Assert.IsNull(_game.GetWinner());
            _game.SetMove(6, Player.Second);
            Assert.AreEqual(Player.Second, _game.GetWinner());
        }

        [Test]
        public void GetWinnerWithBoardFull()
        {
            _game.SetMove(0, Player.First);
            _game.SetMove(1, Player.Second);
            _game.SetMove(2, Player.Second);
            _game.SetMove(3, Player.Second);
            _game.SetMove(4, Player.First);
            _game.SetMove(5, Player.First);
            _game.SetMove(6, Player.First);
            _game.SetMove(7, Player.First);
            Assert.IsNull(_game.GetWinner());
            _game.SetMove(8, Player.Second);
            Assert.AreEqual(Player.Empty, _game.GetWinner());
        }

        [Test]
        public void GoNextPlayer()
        {
            _game.GoNextPlayer();
            Assert.AreEqual(Player.Second, _game.CurrentPlayer);
            _game.GoNextPlayer();
            Assert.AreEqual(Player.First, _game.CurrentPlayer);
        }

        [Test(Description = "a board must be represented as a string")]
        public void StringRepresentation()
        {
            // Default representation
            Assert.AreEqual("|   |   |   |\n|   |   |   |\n|   |   |   |\n", _game.ToString());

            // Representation with few moves
            _game.SetMove(1, Player.First);
            _game.SetMove(6, Player.Second);
            Assert.AreEqual("|   | X |   |\n|   |   |   |\n| O |   |   |\n", _game.ToString());
        }

        [Test]
        public void Clone()
        {
            var game2 = new Game(_game);
            _game.SetMove(3, Player.Second);
            Assert.IsFalse(_game.IsMoveValid(3));
            Assert.IsTrue(game2.IsMoveValid(3));
        }
    }
}