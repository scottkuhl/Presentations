using System;

namespace Raffle
{
    /// <summary>
    ///     The Raffle Program!
    /// </summary>
    internal class Program
    {
        /// <summary>
        ///     Draw a winner from up to 30 names.  Fun for the whole family.
        /// </summary>
        private static void Main()
        {
            // Asks the user to enter up to 30 names.
            Console.WriteLine("Enter 30 names.");

            // Track the number of names entered.
            int namesEntered = 0;
            string[] names = EnterNames(out namesEntered);

            // Then, you will randomly choose a name from the array and write it to the console as the winner.
            int winner = PrintWinner(namesEntered, names);

            // Then, you will write the list of other names that did not win.
            PrintLosers(names, winner);

            Console.ReadLine();
        }

        /// <summary>
        ///     Loop until we get 30 names or the user hits enter.
        /// </summary>
        /// <param name="namesEntered">Return the total number of names the user entered.</param>
        /// <returns>A list of names.</returns>
        private static string[] EnterNames(out int namesEntered)
        {
            // Start names entered at zero.  An output parameter must be set at least once.
            namesEntered = 0;

            // Store the names entered into an array.
            string[] names = new string[30];

            // Loop until we get 30 names or the user hits enter.
            // Save the input from the user into the array.
            for (int i = 0; i < 30; i++)
            {
                // Read in a name from the user.
                string nameEntered = Console.ReadLine();

                // If the user hits enter without entering a name, assume they are done and stop asking them.
                if (nameEntered == "") break;

                // Save the name entered into the next element of the array.
                names[i] = nameEntered;

                // Increment our counter.
                namesEntered = i;
            }

            // Send out the list of names.
            return names;
        }

        /// <summary>
        ///     Print the name of the winner to the console.
        /// </summary>
        /// <param name="namesEntered">Total number of names entered.</param>
        /// <param name="names">List of names.</param>
        /// <returns>Number of the winner.</returns>
        /// <remarks>We could calculate the total number of names entered by counting non-nulls.</remarks>
        private static int PrintWinner(int namesEntered, string[] names)
        {
            // You can use the random class to generate random numbers.
            Random randomizer = new Random();

            // The random number generate requires a min and max value.
            // Our max value needs to be the number of names entered, not the size of the array.
            int winner = randomizer.Next(0, namesEntered);

            // Now we have the index or position of the array that contains the winner.
            // Print the value in that array position, not the number of the winner.
            Console.WriteLine($"The winner is {names[winner]}!");

            return winner;
        }

        /// <summary>
        ///     Print the list of losers.
        /// </summary>
        /// <param name="names">List of names, including the winner.</param>
        /// <param name="winner">Name of the winner.</param>
        private static void PrintLosers(string[] names, int winner)
        {
            foreach (string name in names)
            {
                // If the name is NULL, we hit the last entered name, stop looping.
                // Values in the string array started as NULL.
                // Because we stopped before entering the final blank, we can check for NULL.
                if (name == null) break;

                // If the name is the winner, do not print it.
                // Make sure you are checking the value of the array.
                if (names[winner] == name) continue;

                // Print the name, because it is a loser.
                Console.WriteLine($"{name} lost.");
            }
        }
    }
}