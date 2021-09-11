using DeckOfCards;
using Xunit;

namespace Test
{
    public class CardTest
    {
        [Fact]
        public void GetFullName_ReturnValue()
        {
            Card card = new Card { FaceValue = "8", Suit = "Hearts" };
            Assert.Equal("8 of Hearts", card.GetFullName());
        }
    }
}