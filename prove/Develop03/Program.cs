using System;

namespace Develop03
{
    class Program
    {
        static void Main(string[] args)
        {
            // This program exceeds the core requirements in three ways:
           
            // 1. It loads a library of 13 scriptures from an external file (scriptures.txt)instead of using a single hardcoded scripture.
    
            // 2. Chooses a random scripture from the library each time the program runs.
            // 3. When hiding words, it only selects from words that are not already hidden.
            //    So every key typed reveals real progress instead of possibly re-hiding a word that's already gone.
        

            ScriptureLibrary library = new ScriptureLibrary("scriptures.txt");
            Scripture scripture = library.GetRandomScripture();

            int wordsToHideEachRound = 3;
            bool userQuit = false;

            while (!scripture.AllWordsHidden() && !userQuit)
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine();
                Console.Write("Press enter to continue or type 'quit' to end: ");

                string input = Console.ReadLine();

                if (input == "quit")
                {
                    userQuit = true;
                }
                else
                {
                    scripture.HideRandomWords(wordsToHideEachRound);
                }
            }

            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Great work! Program complete.");
        }
    }
}