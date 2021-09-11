using System;

// TODO: Fix the compiler bugs.
// TODO: Find the logic bug in Hand.
// TODO: Find the logic bug in Deck.
// TODO: Set the hand array to the smallest possible value.
// TODO: Why is the an extra enter key needed in the middle of the program?
// TODO: Ties always goes to the house never prints.

namespace BlackJack
{
    public static class Program
    {
        public static void Main()
        {
            Play();

            Console.ReadLine();
        }

        public static void Play()
        {
            Deck deck = new Deck();

            Hand player = new Hand();
            player.AddCard(deck.Draw());
            player.AddCard(deck.Draw());
            Console.WriteLine($"Player has drawn {player} worth {player.PointValue} points.");

            if (player.IsBlackJack)
            {
                Console.WriteLine("Black Jack! You Win!");
                return;
            }

            bool keepDrawing;
            do
            {
                Console.WriteLine("Do you want to draw another card?");
                keepDrawing = Console.ReadLine().ToLower() == "yes" || Console.ReadLine().ToLower() == "hit me";
                if (keepDrawing)
                {
                    player.AddCard(deck.Draw());
                    Console.WriteLine($"You drew the {player.LastCard.FullName} for a new total of {player.PointValue} points.");
                }
            } while (keepDrawing && !player.IsBusted);

            if (player.IsBusted)
            {
                Console.WriteLine("Busted!  You lose.");
                return;
            }

            Hand computer = new Hand();
            computer.AddCard(deck.Draw());
            computer.AddCard(deck.Draw());
            Console.WriteLine($"Computer has drawn {computer} worth {computer.PointValue} points.");

            if (computer.IsBlackJack)
            {
                Console.WriteLine("Black Jack! You Lose.");
                return;
            }

            while (computer.PointValue < player.PointValue && computer.PointValue <= 21)
            {
                computer.AddCard(deck.Draw());
                Console.WriteLine($"Computer has drawn the {computer.LastCard.FullName} for a new total of {computer.PointValue} points.");
            }

            if (computer.IsBusted)
            {
                Console.WriteLine("Busted!  You win!");
                return;
            }

            if (computer.PointValue >= player.PointValue)
            {
                Console.WriteLine($"The computer won with {computer.PointValue} compared to your {player.PointValue}.");
            }
            else if (computer.PointValue == player.PointValue)
            {
                Console.WriteLine("Ties always goes to the house.");
            }
            
            if (computer.PointValue < player.PointValue)
            {
                Console.WriteLine($"You won with {player.PointValue} compared to its {computer.PointValue}.");
            }

            return;
        }
    }
}
