namespace MinimaxAlgorithm
{
    public class Minimax
    {
        public static Minimax Instance { get; } = new();

        private Minimax()
        {
        }

        public (int, int) MaxAlphaBeta(Game game, int alpha = -2, int beta = 2)
        {
            var score = -2;
            var index = -1;

            // Perform winner check first
            var winner = game.GetWinner();
            switch (winner)
            {
                case Player.First:
                    return (-1, 0);
                case Player.Second:
                    return (1, 0);
                case Player.Empty:
                    return (0, 0);
            }

            // Start algorithm on empty cells
            foreach (var emptyCell in game.EmptyCellIndexes)
            {
                var cloned = new Game(game);
                cloned.SetMove(emptyCell, Player.Second);

                var (minScore, _) = MinAlphaBeta(cloned, alpha, beta);
                if (minScore > score)
                {
                    score = minScore;
                    index = emptyCell;
                }

                if (score >= beta)
                {
                    return (score, index);
                }

                if (score > alpha)
                {
                    alpha = score;
                }
            }

            return (score, index);
        }

        public (int, int) MinAlphaBeta(Game game, int alpha = -2, int beta = 2)
        {
            var score = 2;
            var index = -1;

            // Perform winner check first
            var winner = game.GetWinner();
            switch (winner)
            {
                case Player.First:
                    return (-1, 0);
                case Player.Second:
                    return (1, 0);
                case Player.Empty:
                    return (0, 0);
            }

            // Start algorithm on empty cells
            foreach (var emptyCell in game.EmptyCellIndexes)
            {
                var cloned = new Game(game);
                cloned.SetMove(emptyCell, Player.First);

                var (maxScore, _) = MaxAlphaBeta(cloned, alpha, beta);
                if (maxScore < score)
                {
                    score = maxScore;
                    index = emptyCell;
                }

                if (score <= alpha)
                {
                    return (score, index);
                }

                if (score < beta)
                {
                    beta = score;
                }
            }

            return (score, index);
        }
    }
}