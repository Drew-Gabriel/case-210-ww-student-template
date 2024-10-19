using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ScriptureMemorizer
{
    // Class to represent a word in the scripture
    class Word
    {
        private string _text;
        private bool _isHidden;

        public Word(string text)
        {
            _text = text;
            _isHidden = false;
        }

        public void Hide()
        {
            _isHidden = true;
        }

        public bool IsHidden()
        {
            return _isHidden;
        }

        public override string ToString()
        {
            return _isHidden ? "_____" : _text;
        }
    }

    // Class to represent the scripture reference (e.g., "John 3:16")
    class ScriptureReference
    {
        public string Book { get; private set; }
        public string VerseStart { get; private set; }
        public string VerseEnd { get; private set; }

        public ScriptureReference(string book, string verseStart, string verseEnd = "")
        {
            Book = book;
            VerseStart = verseStart;
            VerseEnd = verseEnd;
        }

        public override string ToString()
        {
            return string.IsNullOrEmpty(VerseEnd) ? $"{Book} {VerseStart}" : $"{Book} {VerseStart}-{VerseEnd}";
        }
    }

    // Class to represent the scripture itself
    class Scripture
    {
        private ScriptureReference _reference;
        private List<Word> _words;
        private Random _random;

        public Scripture(ScriptureReference reference, string text)
        {
            _reference = reference;
            _words = text.Split(' ').Select(w => new Word(w)).ToList();
            _random = new Random();
        }

        public void Display()
        {
            Console.Clear();
            Console.WriteLine(_reference);
            foreach (var word in _words)
            {
                Console.Write(word + " ");
            }
            Console.WriteLine("\n");
        }

        public void HideRandomWords(int count)
        {
            int wordsToHide = Math.Min(count, _words.Count(w => !w.IsHidden()));
            int hiddenWords = 0;

            while (hiddenWords < wordsToHide)
            {
                int index = _random.Next(_words.Count);
                if (!_words[index].IsHidden())
                {
                    _words[index].Hide();
                    hiddenWords++;
                }
            }
        }

        public bool AllWordsHidden()
        {
            return _words.All(w => w.IsHidden());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Example scripture: "John 3:16"
            var reference = new ScriptureReference("John", "3:16");
            var scriptureText = "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.";
            var scripture = new Scripture(reference, scriptureText);

            // Main loop
            while (!scripture.AllWordsHidden())
            {
                scripture.Display();
                Console.WriteLine("Press Enter to hide some words or type 'quit' to exit.");
                string input = Console.ReadLine();
                if (input.ToLower() == "quit")
                    break;

                scripture.HideRandomWords(3);
            }

            // End the program when all words are hidden
            Console.Clear();
            Console.WriteLine("All words are now hidden. Well done!");
        }
    }
}
