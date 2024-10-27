using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    // Class representing a scripture reference
    public class ScriptureReference
    {
        public string Book { get; }
        public int StartChapter { get; }
        public int StartVerse { get; }
        public int? EndVerse { get; }

        public ScriptureReference(string book, int chapter, int verse)
        {
            Book = book;
            StartChapter = chapter;
            StartVerse = verse;
            EndVerse = null;
        }

        public ScriptureReference(string book, int chapter, int startVerse, int endVerse)
        {
            Book = book;
            StartChapter = chapter;
            StartVerse = startVerse;
            EndVerse = endVerse;
        }

        public override string ToString()
        {
            return EndVerse.HasValue ? $"{Book} {StartChapter}:{StartVerse}-{EndVerse}" : $"{Book} {StartChapter}:{StartVerse}";
        }
    }

    // Class representing a word in scripture
    public class ScriptureWord
    {
        public string Word { get; }
        public bool IsHidden { get; private set; }

        public ScriptureWord(string word)
        {
            Word = word;
            IsHidden = false;
        }

        public void Hide() => IsHidden = true;

        public override string ToString()
        {
            return IsHidden ? "_____" : Word;
        }
    }

    // Class representing a scripture
    public class Scripture
    {
        public ScriptureReference Reference { get; }
        private List<ScriptureWord> Words { get; }

        public Scripture(ScriptureReference reference, string text)
        {
            Reference = reference;
            Words = text.Split(' ').Select(w => new ScriptureWord(w)).ToList();
        }

        public void HideRandomWords(int count)
        {
            Random random = new Random();
            var availableWords = Words.Where(w => !w.IsHidden).ToList();
            for (int i = 0; i < count && availableWords.Any(); i++)
            {
                int index = random.Next(availableWords.Count);
                availableWords[index].Hide();
                availableWords = Words.Where(w => !w.IsHidden).ToList();
            }
        }

        public override string ToString()
        {
            return $"{Reference}\n" + string.Join(" ", Words);
        }

        public bool AllWordsHidden() => Words.All(w => w.IsHidden);
    }

    // Program class to run the application
    class Program
    {
        static void Main(string[] args)
        {
            var scripture = new Scripture(new ScriptureReference("John", 3, 16), "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");
            Console.Clear();
            Console.WriteLine(scripture);

            while (true)
            {
                Console.WriteLine("\nPress Enter to hide some words, or type 'quit' to exit:");
                var input = Console.ReadLine();

                if (input?.ToLower() == "quit")
                {
                    break;
                }

                scripture.HideRandomWords(1);
                Console.Clear();
                Console.WriteLine(scripture);

                if (scripture.AllWordsHidden())
                {
                    Console.WriteLine("All words are now hidden. Exiting...");
                    break;
                }
            }
        }
    }
}
