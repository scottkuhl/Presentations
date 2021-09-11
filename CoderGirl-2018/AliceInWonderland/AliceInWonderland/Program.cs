using System;

namespace AliceInWonderland
{
    public static class Program
    {
        private const string Alice = "Alice was beginning to get very tired of sitting by her sister on the bank, and of having nothing to do: once or twice she had peeped into the book her sister was reading, but it had no pictures or conversations in it, ‘and what is the use of a book,’ thought Alice ‘without pictures or conversation?’";

        public static void Main()
        {
            // TODO: Prompt the user for a string within the first sentence of Alice in Wonderland to search for within this string.

            Console.ReadLine();
        }

        // TODO: Create a method that returns whether the text was found. See if you can make the search case-insensitive, so that searching for “alice” prints true.

        public static bool Match(string search)
        {
            return Alice.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
}
