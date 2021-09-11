using System;

namespace DeckOfCards
{
    public static class Program
    {
        public static void Main()
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