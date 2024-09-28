using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberListAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            int number;

            
            do
            {
                Console.WriteLine("Enter a number (0 to finish):");
                number = Convert.ToInt32(Console.ReadLine());
                if (number != 0)
                {
                    numbers.Add(number);
                }
            } while (number != 0);

            
            int sum = numbers.Sum();
            double average = numbers.Average();
            int max = numbers.Max();

            Console.WriteLine($"The sum is: {sum}");
            Console.WriteLine($"The average is: {average}");
            Console.WriteLine($"The largest number is: {max}");

            
            List<int> positiveNumbers = numbers.Where(n => n > 0).ToList();
            int smallestPositive = positiveNumbers.Min();
            List<int> sortedNumbers = numbers.OrderBy(n => n).ToList();

            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
            Console.WriteLine("The sorted list is:");
            foreach (var num in sortedNumbers)
            {
                Console.WriteLine(num);
            }
        }
    }
}
