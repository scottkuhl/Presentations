namespace Chatbot
{
    public class Chatbot
    {
        private string _name;

        /// <summary>
        ///     Initialize a Chatbot with a name for it.
        /// </summary>
        public Chatbot(string name)
        {
            _name = name;
        }

        /// <summary>
        ///     The Chatbot's way of introducing itself.
        /// </summary>
        public string Greeting
        {
            get
            {
                return $"Hello, my name is {_name}";
            }
        }

        /// <summary>
        ///     Returns the Chatbot's response to something the human said.
        /// </summary>
        public string Response(string prompt)
        {
            return $"It is very interesting that you say: '{prompt}'";
        }
    }
}