using System;

namespace DeckOfCards
{
    public class Deck
    {
        private Random _random;

        public Deck()
        {
            _random = new Random();

            // TODO: Load the card deck with a standard deck of 52 cards.  Use loops, do not hard code each one.
        }

        public Card[] Cards { get; set; }

        public Card Draw()
        {
            // TODO: Return a random card from the deck.
            return null;
        }
    }
}