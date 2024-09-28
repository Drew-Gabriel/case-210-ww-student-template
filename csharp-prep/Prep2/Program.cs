using System;

namespace GradeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Enter your grade percentage:");
            double gradePercentage = Convert.ToDouble(Console.ReadLine());

            
            char letter;
            if (gradePercentage >= 90)
            {
                letter = 'A';
            }
            else if (gradePercentage >= 80)
            {
                letter = 'B';
            }
            else if (gradePercentage >= 70)
            {
                letter = 'C';
            }
            else if (gradePercentage >= 60)
            {
                letter = 'D';
            }
            else
            {
                letter = 'F';
            }

            
            if (gradePercentage >= 70)
            {
                Console.WriteLine($"Congratulations! You passed the course with a grade of {letter}.");
            }
            else
            {
                Console.WriteLine($"Keep it up! You'll do better next time. Your grade is {letter}.");
            }
        }
    }
}
