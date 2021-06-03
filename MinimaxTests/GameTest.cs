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
            _game.Initialize();
        }

        [Test]
        public void Initialize()
        {
            Assert.AreEqual(3, _game.Size);
            Assert.AreEqual('X', _game.Player);
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
            _game.SetMove(8, 'X');
            Assert.IsFalse(_game.IsMoveValid(8));
        }

        [Test]
        public void GetWinnerWithColumn()
        {
            _game.SetMove(1, 'X');
            Assert.IsNull(_game.GetWinner());
            _game.SetMove(4, 'X');
            Assert.IsNull(_game.GetWinner());
            _game.SetMove(7, 'X');
            Assert.AreEqual('X', _game.GetWinner());
        }

        [Test]
        public void GetWinnerWithRow()
        {
            _game.SetMove(7, 'O');
            Assert.IsNull(_game.GetWinner());
            _game.SetMove(8, 'O');
            Assert.IsNull(_game.GetWinner());
            _game.SetMove(6, 'O');
            Assert.AreEqual('O', _game.GetWinner());
        }

        [Test]
        public void GetWinnerWithDiagonal1()
        {
            _game.SetMove(0, 'X');
            Assert.IsNull(_game.GetWinner());
            _game.SetMove(4, 'X');
            Assert.IsNull(_game.GetWinner());
            _game.SetMove(8, 'X');
            Assert.AreEqual('X', _game.GetWinner());
        }

        [Test]
        public void GetWinnerWithDiagonal2()
        {
            _game.SetMove(2, 'O');
            Assert.IsNull(_game.GetWinner());
            _game.SetMove(4, 'O');
            Assert.IsNull(_game.GetWinner());
            _game.SetMove(6, 'O');
            Assert.AreEqual('O', _game.GetWinner());
        }

        [Test]
        public void GetWinnerWithBoardFull()
        {
            _game.SetMove(0, 'X');
            _game.SetMove(1, 'O');
            _game.SetMove(2, 'O');
            _game.SetMove(3, 'O');
            _game.SetMove(4, 'X');
            _game.SetMove(5, 'X');
            _game.SetMove(6, 'X');
            _game.SetMove(7, 'X');
            Assert.IsNull(_game.GetWinner());
            _game.SetMove(8, 'O');
            Assert.AreEqual(' ', _game.GetWinner());
        }

        [Test(Description = "a board must be represented as a string")]
        public void StringRepresentation()
        {
            // Default representation
            Assert.AreEqual("|   |   |   |\n|   |   |   |\n|   |   |   |\n", _game.ToString());

            // Representation with few moves
            _game.SetMove(1, 'X');
            _game.SetMove(6, 'O');
            Assert.AreEqual("|   | X |   |\n|   |   |   |\n| O |   |   |\n", _game.ToString());
        }
    }
}