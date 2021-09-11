using DeckOfCards;
using System.Collections.Generic;
using Xunit;

namespace Test
{
    public class DeckTest
    {
        [Fact]
        public void Cards_HasStandardDeck()
        {
            Deck deck = new Deck();
            List<Card> cards = new List<Card>(deck.Cards);

            Assert.Contains(cards, c => c.FaceValue == "2" && c.Suit == "Hearts");
            Assert.Contains(cards, c => c.FaceValue == "3" && c.Suit == "Hearts");
            Assert.Contains(cards, c => c.FaceValue == "4" && c.Suit == "Hearts");
            Assert.Contains(cards, c => c.FaceValue == "5" && c.Suit == "Hearts");
            Assert.Contains(cards, c => c.FaceValue == "6" && c.Suit == "Hearts");
            Assert.Contains(cards, c => c.FaceValue == "7" && c.Suit == "Hearts");
            Assert.Contains(cards, c => c.FaceValue == "8" && c.Suit == "Hearts");
            Assert.Contains(cards, c => c.FaceValue == "9" && c.Suit == "Hearts");
            Assert.Contains(cards, c => c.FaceValue == "10" && c.Suit == "Hearts");
            Assert.Contains(cards, c => c.FaceValue == "Jack" && c.Suit == "Hearts");
            Assert.Contains(cards, c => c.FaceValue == "Queen" && c.Suit == "Hearts");
            Assert.Contains(cards, c => c.FaceValue == "King" && c.Suit == "Hearts");
            Assert.Contains(cards, c => c.FaceValue == "Ace" && c.Suit == "Hearts");

            Assert.Contains(cards, c => c.FaceValue == "2" && c.Suit == "Diamonds");
            Assert.Contains(cards, c => c.FaceValue == "3" && c.Suit == "Diamonds");
            Assert.Contains(cards, c => c.FaceValue == "4" && c.Suit == "Diamonds");
            Assert.Contains(cards, c => c.FaceValue == "5" && c.Suit == "Diamonds");
            Assert.Contains(cards, c => c.FaceValue == "6" && c.Suit == "Diamonds");
            Assert.Contains(cards, c => c.FaceValue == "7" && c.Suit == "Diamonds");
            Assert.Contains(cards, c => c.FaceValue == "8" && c.Suit == "Diamonds");
            Assert.Contains(cards, c => c.FaceValue == "9" && c.Suit == "Diamonds");
            Assert.Contains(cards, c => c.FaceValue == "10" && c.Suit == "Diamonds");
            Assert.Contains(cards, c => c.FaceValue == "Jack" && c.Suit == "Diamonds");
            Assert.Contains(cards, c => c.FaceValue == "Queen" && c.Suit == "Diamonds");
            Assert.Contains(cards, c => c.FaceValue == "King" && c.Suit == "Diamonds");
            Assert.Contains(cards, c => c.FaceValue == "Ace" && c.Suit == "Diamonds");

            Assert.Contains(cards, c => c.FaceValue == "2" && c.Suit == "Clubs");
            Assert.Contains(cards, c => c.FaceValue == "3" && c.Suit == "Clubs");
            Assert.Contains(cards, c => c.FaceValue == "4" && c.Suit == "Clubs");
            Assert.Contains(cards, c => c.FaceValue == "5" && c.Suit == "Clubs");
            Assert.Contains(cards, c => c.FaceValue == "6" && c.Suit == "Clubs");
            Assert.Contains(cards, c => c.FaceValue == "7" && c.Suit == "Clubs");
            Assert.Contains(cards, c => c.FaceValue == "8" && c.Suit == "Clubs");
            Assert.Contains(cards, c => c.FaceValue == "9" && c.Suit == "Clubs");
            Assert.Contains(cards, c => c.FaceValue == "10" && c.Suit == "Clubs");
            Assert.Contains(cards, c => c.FaceValue == "Jack" && c.Suit == "Clubs");
            Assert.Contains(cards, c => c.FaceValue == "Queen" && c.Suit == "Clubs");
            Assert.Contains(cards, c => c.FaceValue == "King" && c.Suit == "Clubs");
            Assert.Contains(cards, c => c.FaceValue == "Ace" && c.Suit == "Clubs");

            Assert.Contains(cards, c => c.FaceValue == "2" && c.Suit == "Spades");
            Assert.Contains(cards, c => c.FaceValue == "3" && c.Suit == "Spades");
            Assert.Contains(cards, c => c.FaceValue == "4" && c.Suit == "Spades");
            Assert.Contains(cards, c => c.FaceValue == "5" && c.Suit == "Spades");
            Assert.Contains(cards, c => c.FaceValue == "6" && c.Suit == "Spades");
            Assert.Contains(cards, c => c.FaceValue == "7" && c.Suit == "Spades");
            Assert.Contains(cards, c => c.FaceValue == "8" && c.Suit == "Spades");
            Assert.Contains(cards, c => c.FaceValue == "9" && c.Suit == "Spades");
            Assert.Contains(cards, c => c.FaceValue == "10" && c.Suit == "Spades");
            Assert.Contains(cards, c => c.FaceValue == "Jack" && c.Suit == "Spades");
            Assert.Contains(cards, c => c.FaceValue == "Queen" && c.Suit == "Spades");
            Assert.Contains(cards, c => c.FaceValue == "King" && c.Suit == "Spades");
            Assert.Contains(cards, c => c.FaceValue == "Ace" && c.Suit == "Spades");
        }

        [Fact]
        public void Draw_Random()
        {
            Deck deck = new Deck();

            var cards = new List<Card>();

            for (int i = 1; i <= 10; i++)
            {
                cards.Add(deck.Draw());
            }

            var firstCard = cards[0];

            foreach (var card in cards)
            {
                if (card.FaceValue == firstCard.FaceValue && card.Suit == firstCard.Suit) continue;
                return;
            }

            Assert.True(false);
        }
    }
}