using System;
using System.Collections.Generic;
using System.IO;

namespace Develop03
{
    public class ScriptureLibrary
    {
        // 1. Private fields go first
        private List<Scripture> _scriptures;
        private Random _random;

        // 2. Constructor goes second
        public ScriptureLibrary(string filePath)
        {
            _scriptures = new List<Scripture>();
            _random = new Random();
            LoadFromFile(filePath);
        }

        // 3. LoadFromFile method goes third (a separate method, not inside the constructor)
        private void LoadFromFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                if (line.Trim().Length == 0)
                {
                    continue;
                }

                int firstQuote = line.IndexOf('"');
                int lastQuote = line.LastIndexOf('"');

                string referenceText = line.Substring(0, firstQuote).Trim();
                string scriptureText = line.Substring(firstQuote + 1, lastQuote - firstQuote - 1).Trim();

                Reference reference = ParseReference(referenceText);

                Scripture newScripture = new Scripture(reference, scriptureText);
                _scriptures.Add(newScripture);
            }
        }

        // 4. ParseReference method goes fourth (a separate method, not inside LoadFromFile)
        private Reference ParseReference(string referenceText)
        {
            int colonIndex = referenceText.LastIndexOf(':');
            string beforeColon = referenceText.Substring(0, colonIndex).Trim();
            string afterColon = referenceText.Substring(colonIndex + 1).Trim();

            int lastSpace = beforeColon.LastIndexOf(' ');
            string book = beforeColon.Substring(0, lastSpace).Trim();
            int chapter = int.Parse(beforeColon.Substring(lastSpace + 1).Trim());

            afterColon = afterColon.Replace('_', '-');

            if (afterColon.Contains('-'))
            {
                string[] verseParts = afterColon.Split('-');
                int startVerse = int.Parse(verseParts[0].Trim());
                int endVerse = int.Parse(verseParts[1].Trim());
                return new Reference(book, chapter, startVerse, endVerse);
            }
            else
            {
                int verse = int.Parse(afterColon.Trim());
                return new Reference(book, chapter, verse);
            }
        }

        // 5. GetRandomScripture method goes last
        public Scripture GetRandomScripture()
        {
            int randomIndex = _random.Next(_scriptures.Count);
            return _scriptures[randomIndex];
        }

    } 
}