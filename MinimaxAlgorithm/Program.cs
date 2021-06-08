using System;

namespace MinimaxAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();

            while (true)
            {
                Console.WriteLine(game);

                var winner = game.GetWinner();

                switch (winner)
                {
                    case Player.First:
                        Console.WriteLine("Player 1 wins!");
                        return;
                    case Player.Second:
                        Console.WriteLine("Player 2 wins!");
                        return;
                    case Player.Empty:
                        Console.WriteLine("It's a tie!");
                        return;
                }

                if (game.CurrentPlayer == Player.First)
                {
                    while (true)
                    {
                        var begin = DateTime.Now;
                        var (score, index) = Minimax.Instance.MinAlphaBeta(game);

                        Console.WriteLine("Evaluation time : " + (DateTime.Now - begin));
                        Console.WriteLine($"Recommended move : {index} (score = {score})");
                        Console.Write("Insert the index you want to play : ");

                        try
                        {
                            var input = Convert.ToInt32(Console.ReadLine());

                            if (game.IsMoveValid(input))
                            {
                                game.SetMove(input, game.CurrentPlayer);
                                game.GoNextPlayer();
                                break;
                            }
                        }
                        catch (FormatException)
                        {
                            // ignored
                        }

                        Console.WriteLine("Invalid move! Please retry.");
                    }
                }
                else
                {
                    var (_, index) = Minimax.Instance.MaxAlphaBeta(game);
                    game.SetMove(index, game.CurrentPlayer);
                    game.GoNextPlayer();
                }
            }
        }
    }
}