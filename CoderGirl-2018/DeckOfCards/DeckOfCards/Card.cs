namespace DeckOfCards
{
    public class Card
    {
        public string FaceValue { get; set; }

        public string Suit { get; set; }

        public string GetFullName()
        {
            return $"{FaceValue} of {Suit}";
        }
    }
}
