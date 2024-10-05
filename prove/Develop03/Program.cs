using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizationProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Scripture Memorization Program!");

            
            ScriptureManager manager = new ScriptureManager();

            
            manager.Display();

            
            Console.WriteLine("Press enter to hide a few words or type 'quit' to exit.");
            string input = Console.ReadLine();

            while (input != "quit")
            {
                
                manager.HideRandomWords();

                
                Console.Clear();
                manager.Display();

                
                Console.WriteLine("Press enter to hide a few more words or type 'quit' to exit.");
                input = Console.ReadLine();
            }
        }
    }

    class ScriptureManager
    {
        private List<Scripture> scriptures;
        private Random random;

        public ScriptureManager()
        {
            scriptures = new List<Scripture>();
            random = new Random();

            scriptures.Add(new Scripture("3rd Nephi 11:11", "And behold, I am the light and the life of the world."));
            scriptures.Add(new Scripture("Proverbs 3:5-6", "Trust in the Lord with all your heart, and do not lean on your own understanding. In all your ways acknowledge him, and he will make straight your paths."));
        }

        public void Display()
        {
            foreach (var scripture in scriptures)
            {
                scripture.Display();
                Console.WriteLine();
            }
        }

        public void HideRandomWords()
        {
            foreach (var scripture in scriptures)
            {
                scripture.HideRandomWords();
            }
        }
    }

    class Scripture
    {
        private string reference;
        private string text;
        private List<string> words;
        private Random random;

        public Scripture(string reference, string text)
        {
            this.reference = reference;
            this.text = text;
            this.words = text.Split(' ').ToList();
            this.random = new Random();
        }

        public void Display()
        {
            Console.WriteLine(reference);
            Console.WriteLine(text);
        }

        public void HideRandomWords()
        {
            
            int numWordsToHide = random.Next(1, words.Count);

            
            List<int> indices = Enumerable.Range(0, words.Count).OrderBy(x => random.Next()).Take(numWordsToHide).ToList();

            
            foreach (int index in indices)
            {
                words[index] = "";
            }

            
            text = string.Join(" ", words);
        }
    }
