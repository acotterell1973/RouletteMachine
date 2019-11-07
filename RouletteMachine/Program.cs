using System;

namespace RouletteMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var bookie = new Bookie();
            var player = new Player();
            player.FundAccount(100);

            RouletteWheel rouletteWheel = new RouletteWheel();
            Slot slot;
            bool playAgain = true;
            while (playAgain)
            {
                Console.WriteLine("How much would you like to bet?");

                double.TryParse(Console.ReadLine(), out double betAmount);
                var canplay = player.IsfundsAvailable(betAmount);

                if (!canplay || betAmount <= 0)
                {
                    Console.WriteLine("You either don't have enough funds or you try to be play $0 bet.");
                    return; // this can be refactored

                }

                player.TakeFromAccount(betAmount);
                Console.WriteLine($"Available funds {player.GetBalance()}.");
                playAgain = bookie.PlaceBet(betAmount);

                if (!playAgain) break;

                slot = rouletteWheel.Spin();

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"You spun {slot}");

                Console.ResetColor();

                var payout = bookie.GetPayout(slot);
                Console.WriteLine($"You won {payout.Amount} for betting {bookie.BetAmount}.");
                
                player.AddToAccount(payout.Amount);

                Console.WriteLine(string.Empty);
                Console.WriteLine("Do you want to play again? Press y - for Yes, n for No.");
                var again = Console.ReadKey();
                playAgain = (again.Key == ConsoleKey.Y) ? true : false;
                Console.WriteLine(string.Empty);
            }
        }
    }
}
