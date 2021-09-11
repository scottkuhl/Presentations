using Contacts.Controller;
using System;

namespace Contacts
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("Enter the first name: ");
            var firstName = Console.ReadLine();
            Console.Write("Enter the last name: ");
            var lastName = Console.ReadLine();
            Console.Write("Enter the email address: ");
            var email = Console.ReadLine();

            var controller = new PersonController();
            controller.AddVisitor(firstName, lastName, email);

            Console.WriteLine("Test 2");

            Console.WriteLine("Press ENTER to end");
            Console.Read();
        }
    }
}