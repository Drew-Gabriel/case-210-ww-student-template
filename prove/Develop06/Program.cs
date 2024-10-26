using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace EternalQuest
{
    // Base class for all goals
    abstract class Goal
    {
        public string Name { get; private set; }
        public int Points { get; protected set; }
        public bool IsComplete { get; protected set; }

        protected Goal(string name)
        {
            Name = name;
            IsComplete = false;
        }

        public abstract void RecordAchievement();
        public abstract string GetStatus();
    }

    // Class for simple goals
    class SimpleGoal : Goal
    {
        public SimpleGoal(string name, int points) : base(name)
        {
            Points = points;
        }

        public override void RecordAchievement()
        {
            IsComplete = true;
        }

        public override string GetStatus()
        {
            return IsComplete ? "[X] " + Name : "[ ] " + Name;
        }
    }

    // Class for eternal goals
    class EternalGoal : Goal
    {
        public EternalGoal(string name, int points) : base(name)
        {
            Points = points;
        }

        public override void RecordAchievement()
        {
            Points += 100; // Increment points for each achievement
        }

        public override string GetStatus()
        {
            return "[ ] " + Name + $" (Points: {Points})";
        }
    }

    // Class for checklist goals
    class ChecklistGoal : Goal
    {
        private int _totalCount;
        private int _completedCount;

        public ChecklistGoal(string name, int totalCount, int points) : base(name)
        {
            _totalCount = totalCount;
            Points = points;
            _completedCount = 0;
        }

        public override void RecordAchievement()
        {
            if (!IsComplete)
            {
                _completedCount++;
                Points += 50; // Points for each completion
                if (_completedCount >= _totalCount)
                {
                    IsComplete = true;
                    Points += 500; // Bonus for completing all
                }
            }
        }

        public override string GetStatus()
        {
            return IsComplete ? "[X] " + Name : $"[ ] {Name} (Completed {_completedCount}/{_totalCount})";
        }
    }

    // Main program class
    class Program
    {
        private static List<Goal> _goals = new List<Goal>();
        private static int _totalScore = 0;

        static void Main(string[] args)
        {
            LoadGoals();
            ShowMenu();
        }

        static void ShowMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Eternal Quest Goals Tracker");
                Console.WriteLine($"Total Score: {_totalScore}\n");
                ShowGoals();
                Console.WriteLine("\n1. Add Goal");
                Console.WriteLine("2. Record Achievement");
                Console.WriteLine("3. Save Goals");
                Console.WriteLine("4. Load Goals");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddGoal();
                        break;
                    case "2":
                        RecordAchievement();
                        break;
                    case "3":
                        SaveGoals();
                        break;
                    case "4":
                        LoadGoals();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        static void ShowGoals()
        {
            foreach (var goal in _goals)
            {
                Console.WriteLine(goal.GetStatus());
            }
        }

        static void AddGoal()
        {
            Console.WriteLine("Enter goal type (simple/eternal/checklist): ");
            var type = Console.ReadLine().ToLower();
            Console.WriteLine("Enter goal name: ");
            var name = Console.ReadLine();

            switch (type)
            {
                case "simple":
                    Console.WriteLine("Enter points for this goal: ");
                    int points = int.Parse(Console.ReadLine());
                    _goals.Add(new SimpleGoal(name, points));
                    break;
                case "eternal":
                    _goals.Add(new EternalGoal(name, 0));
                    break;
                case "checklist":
                    Console.WriteLine("Enter total number of completions required: ");
                    int totalCount = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter points for each completion: ");
                    int checklistPoints = int.Parse(Console.ReadLine());
                    _goals.Add(new ChecklistGoal(name, totalCount, checklistPoints));
                    break;
                default:
                    Console.WriteLine("Invalid goal type.");
                    break;
            }
        }

        static void RecordAchievement()
        {
            Console.WriteLine("Select a goal to record achievement: ");
            ShowGoals();
            int goalIndex = int.Parse(Console.ReadLine()) - 1;
            if (goalIndex >= 0 && goalIndex < _goals.Count)
            {
                _goals[goalIndex].RecordAchievement();
                _totalScore += _goals[goalIndex].Points; // Update total score
            }
            else
            {
                Console.WriteLine("Invalid goal selection.");
            }
        }

        static void SaveGoals()
        {
            var json = JsonConvert.SerializeObject(_goals);
            File.WriteAllText("goals.json", json);
            Console.WriteLine("Goals saved successfully.");
        }

        static void LoadGoals()
        {
            if (File.Exists("goals.json"))
            {
                var json = File.ReadAllText("goals.json");
                _goals = JsonConvert.DeserializeObject<List<Goal>>(json) ?? new List<Goal>();
                _totalScore = _goals.Sum(g => g.Points);
                Console.WriteLine("Goals loaded successfully.");
            }
            else
            {
                Console.WriteLine("No saved goals found.");
            }
        }
    }
}
