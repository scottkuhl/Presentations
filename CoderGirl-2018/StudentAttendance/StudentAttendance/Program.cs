using System;

namespace StudentAttendance
{
    public static class Program
    {
        public static void Main()
        {
            foreach (var student in students)
            {
                Console.WriteLine($"{student.Name}");
            }

            Console.ReadLine();
        }
    }
}