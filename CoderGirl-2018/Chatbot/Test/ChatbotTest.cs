using Xunit;

namespace Test
{
    public class ChatbotTest
    {
        [Fact]
        public void Greeting_ReturnValue()
        {
            var lin = new Chatbot.Chatbot("Lin");
            Assert.Equal("Hello, my name is Lin", lin.Greeting);
        }

        [Fact]
        public void Response_ReturnValue()
        {
            var lin = new Chatbot.Chatbot("Lin");
            Assert.Equal("It is very interesting that you say: 'Test'", lin.Response("Test"));
        }
    }
}