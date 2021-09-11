using System;

namespace Football
{
    public static class Program
    {
        public static void Main()
        {
            Console.Write("Enter the number of touchdowns(7 points): ");
            int touchdowns = int.Parse(Console.ReadLine());

            Console.Write("Enter the number of field goals(3 points: ");
            int fieldgoals = int.Parse(Console.ReadLine());

            // Compute the number of points in a single line of code.
            int points = 0;

            Console.WriteLine($"The team scored {points} points.");

            Console.ReadLine();
        }
    }
}
