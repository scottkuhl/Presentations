namespace BlackJack
{
    public class Card
    {
        public string Color { get; set; }

        public string FaceValue { get; set; }

        public string Suit { get; set; }

        public string FullName
        {
            get { return $"{FaceValue} of {Suit}"; }
        }

        public int PointValue
        {
            get
            {
                if (FaceValue == "Ace") return 11;
                else if (FaceValue == "King" || FaceValue == "Queen" || FaceValue == "Jack") return 10;
                else return FaceValue;
            }
        }

        public bool IsBlackJack
        {
            get
            {
                return Color == "Black" && FaceValue == "Jack";
            }
        }
    }
}
