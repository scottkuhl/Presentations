using System;

namespace Chatbot
{
    public static class Program
    {
        public static void Main()
        {
            // Introduce Sally
            var sally = new Chatbot("Sally");
            Console.WriteLine(sally.Greeting);

            // Wait for a message from the user.
            var message = Console.ReadLine();

            // Respond from Sally.
            Console.WriteLine(sally.Response(message));

            Console.ReadLine();
        }
    }
}