using System;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a deck cards.
            Deck deck = new Deck();

            // Draw a card.
            var card = deck.Draw();

            // Show the value.
            Console.WriteLine(card.GetFullName());

            Console.ReadLine();
        }
    }
}
