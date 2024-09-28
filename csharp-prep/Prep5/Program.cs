using System;

namespace SimpleFunctionsProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            
            DisplayWelcome();

            
            string userName = PromptUserName();

            
            int userNumber = PromptUserNumber();

            
            int squaredNumber = SquareNumber(userNumber);

            
            DisplayResult(userName, squaredNumber);
        }

        
        static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the program!");
        }

        
        static string PromptUserName()
        {
            Console.WriteLine("Please enter your name:");
            return Console.ReadLine();
        }

        
        static int PromptUserNumber()
        {
            Console.WriteLine("Please enter your favorite number:");
            return Convert.ToInt32(Console.ReadLine());
        }

        
        static int SquareNumber(int number)
        {
            return number * number;
        }

        
        static void DisplayResult(string name, int squaredNumber)
        {
            Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
        }
    }
}
