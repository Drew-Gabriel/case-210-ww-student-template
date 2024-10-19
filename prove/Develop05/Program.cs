using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessApp
{
    // Base class for common behaviors of all activities
    abstract class MindfulnessActivity
    {
        protected string ActivityName;
        protected string Description;
        protected int Duration;

        public virtual void StartActivity()
        {
            Console.WriteLine($"Starting {ActivityName}...");
            Console.WriteLine(Description);
            Console.Write("Enter duration in seconds: ");
            Duration = int.Parse(Console.ReadLine());
            Console.WriteLine("Prepare to begin...");
            Pause(3);  // Pause before starting
        }

        public virtual void EndActivity()
        {
            Console.WriteLine($"Good job! You have completed the {ActivityName} for {Duration} seconds.");
            Pause(3);  // Pause before finishing
        }

        protected void Pause(int seconds)
        {
            for (int i = 0; i < seconds; i++)
            {
                Console.Write(".");
                Thread.Sleep(1000);
            }
            Console.WriteLine();
        }

        public abstract void PerformActivity();  // Must be implemented by subclasses
    }

    // Breathing activity class
    class BreathingActivity : MindfulnessActivity
    {
        public BreathingActivity()
        {
            ActivityName = "Breathing Activity";
            Description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
        }

        public override void PerformActivity()
        {
            StartActivity();
            int halfDuration = Duration / 2;

            for (int i = 0; i < halfDuration; i++)
            {
                Console.WriteLine("Breathe in...");
                Pause(3);
                Console.WriteLine("Breathe out...");
                Pause(3);
            }

            EndActivity();
        }
    }

    // Reflection activity class
    class ReflectionActivity : MindfulnessActivity
    {
        private List<string> Prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private List<string> Questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        private Random random = new Random();

        public ReflectionActivity()
        {
            ActivityName = "Reflection Activity";
            Description = "This activity will help you reflect on times in your life when you have shown strength and resilience.";
        }

        public override void PerformActivity()
        {
            StartActivity();
            Console.WriteLine(Prompts[random.Next(Prompts.Count)]);

            int totalQuestions = Duration / 7;  // Roughly 7 seconds per question
            for (int i = 0; i < totalQuestions; i++)
            {
                Console.WriteLine(Questions[random.Next(Questions.Count)]);
                Pause(5);
            }

            EndActivity();
        }
    }

    // Listing activity class
    class ListingActivity : MindfulnessActivity
    {
        private List<string> Prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt joy this month?",
            "Who are some of your personal heroes?"
        };

        private Random random = new Random();

        public ListingActivity()
        {
            ActivityName = "Listing Activity";
            Description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        }

        public override void PerformActivity()
        {
            StartActivity();
            Console.WriteLine(Prompts[random.Next(Prompts.Count)]);
            Pause(3);  // Pause before user starts listing

            Console.WriteLine("Start listing items. Type 'done' to finish:");
            List<string> items = new List<string>();
            string input;
            while ((input = Console.ReadLine()) != "done")
            {
                items.Add(input);
            }

            Console.WriteLine($"You listed {items.Count} items.");
            EndActivity();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nChoose an activity:");
                Console.WriteLine("1. Breathing Activity");
                Console.WriteLine("2. Reflection Activity");
                Console.WriteLine("3. Listing Activity");
                Console.WriteLine("4. Exit");

                string choice = Console.ReadLine();

                MindfulnessActivity activity = null;

                switch (choice)
                {
                    case "1":
                        activity = new BreathingActivity();
                        break;
                    case "2":
                        activity = new ReflectionActivity();
                        break;
                    case "3":
                        activity = new ListingActivity();
                        break;
                    case "4":
                        return;  // Exit the program
                    default:
                        Console.WriteLine("Invalid choice. Please select again.");
                        continue;
                }

                activity.PerformActivity();
            }
        }
    }
}
