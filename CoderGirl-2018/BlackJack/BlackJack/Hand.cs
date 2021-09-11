namespace BlackJack
{
    public class Hand
    {
        Card[] cards = new Card[52];

        public void AddCard(Card card)
        {
            for(int i = 0; i <= cards.Length; i++)
            {
                if (cards[i] == null)
                {
                    cards[i] = card;
                    break;
                }
            }
        }

        public int PointValue
        {
            get
            {
                int value = 0;

                for (int i = 0; i <= cards.Length; i++)
                {
                    if (cards[i] != null)
                    {
                        value += cards[i].PointValue;
                    }
                }

                return value;
            }
        }

        public override string ToString()
        {
            string value = string.Empty;

            for (int i = 0; i <= cards.Length; i++)
            {
                if (cards[i] != null)
                {
                    if (string.IsNullOrEmpty(value)) value = cards[i].FullName;
                    else value += ", " + cards[i].FullName;
                }
            }

            return value;
        }

        public bool IsBlackJack
        {
            get
            {
                if (cards[0] != null && cards[1] != null && cards[2] == null)
                {
                    if (cards[0].IsBlackJack || cards[1].IsBlackJack)
                    {
                        if (PointValue == 21)
                            return true;
                    }
                }

                return false;
            }
        }

        public bool IsBusted
        {
            get
            {
                return PointValue > 21;
            }
        }

        public Card LastCard
        {
            get
            {
                Card lastCard = null;

                for (int i = 0; i <= cards.Length; i++)
                {
                    if (cards[i] != null)
                    {
                        lastCard = cards[i];
                    }
                    else
                    {
                        break;
                    }
                }

                return lastCard;
            }
        }
    }
}
