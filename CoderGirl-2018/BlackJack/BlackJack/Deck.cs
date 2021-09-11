using System;

namespace BlackJack
{
    public class Deck
    {
        private Random _random;

        public Card[] Cards { get; set; }

        public Deck()
        {
            _random = new Random();

            Cards = new Card[52];

            int counter = 0;

            for (int i = 2; i <= 14; i++)
            {
                string faceValue;
                if (i < 11) faceValue = i.ToString();
                else if (i == 11) faceValue = "Jack";
                else if (i == 12) faceValue = "Queen";
                else if (i == 13) faceValue = "King";
                else faceValue = "Ace";

                for (int j = 1; j <= 4; j++)
                {
                    string suit;
                    if (j == 1) suit = "Hearts";
                    else if (j == 2) suit = "Diamonds";
                    else if (j == 3) suit = "Spades";
                    else suit = "Clubs";

                    Cards[counter] = new Card
                    {
                        Color = suit == "Hearts" || suit == "Diamonds" ? "Red" : "Black",
                        FaceValue = faceValue,
                        Suit = suit
                    };
                }

                counter++;
            }
        }

        public Card Draw()
        {
            var number = _random.Next(Cards.Length);
            return Cards[number];
        }
    }
}
