using System;

namespace StudentAverage
{
    public static class Program
    {
        public static void Main()
        {
            foreach (var student in students)
            {
                Console.WriteLine($"{student.Name} Average: {student.GetAverage()}");
            }

            Console.ReadLine();
        }
    }
}