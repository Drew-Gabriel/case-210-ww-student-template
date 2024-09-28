using System;

namespace NameRepeater
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("What is your first name?");
            string firstName = Console.ReadLine();

            
            Console.WriteLine("What is your last name?");
            string lastName = Console.ReadLine();

            
            Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}.");
        }
    }
}
