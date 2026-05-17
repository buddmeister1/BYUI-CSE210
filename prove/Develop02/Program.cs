using System;
using System.Collections.Generic;

// Exceeds Requirements
// BONUS 1: Mood Tracker
//   When writing an entry, the user rates their mood 1-5. Score is stored in Entry, saved to file, loaded back
//  correctly, and displayed with each entry.After DisplayAll(), the average mood across all entries
//   is shown in magenta/murple.
//   
//   BONUS 2: Colored Console Output
//  Dates = Yellow, Prompts = Blue, Mood = Green, Average Mood = Magenta/Murple, Menu Title = Blue.
//   Colors reset after each section using Console.ResetColor().This improves readability and directly addresses the
//   'not convenient' barrier described in the assignment spec.
//   
// ====================================================================================================================

class Program
{
        

    private Journal _journal = new Journal();

    private List<string> _prompts = new List<string>()
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "What challenged me today, and how did I respond?",
        "What is something I am grateful for right now?",
        "If I could redo one moment from today, what would it be?",
        "What did I learn today, big or small?",
        "What made me laugh or smile today?",
    };

    static void Main(string[] args)
    {
        Program p = new Program();
        p.Run();
    }

    public void Run()
    {
        bool running = true;
        while (running)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n=== Personal Journal ===");
            Console.ResetColor();
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Quit");
            Console.Write("> ");

            string choice = Console.ReadLine();

            if      (choice == "1") WriteEntry();
            else if (choice == "2") DisplayJournal();
            else if (choice == "3") SaveJournal();
            else if (choice == "4") LoadJournal();
            else if (choice == "5") running = false;
            else Console.WriteLine("Invalid choice. Try again.");
        }
        Console.WriteLine("Goodbye! Keep writing.");
    }

    private void WriteEntry()
    {
        Random rng = new Random();
        string prompt = _prompts[rng.Next(_prompts.Count)];

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"\nToday's prompt: {prompt}");
        Console.ResetColor();
        Console.Write("> ");
        string response = Console.ReadLine();

        Console.Write("How are you feeling today? (1=awful, 5=amazing): ");
        int mood = 3;
        int.TryParse(Console.ReadLine(), out mood);
        if (mood < 1 || mood > 5) mood = 3;

        string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        Entry entry = new Entry(date, prompt, response, mood);
        _journal.AddEntry(entry);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Entry saved!");
        Console.ResetColor();
    }

    private void DisplayJournal()
    {
        _journal.DisplayAll();
    }

    private void SaveJournal()
    {
        Console.Write("Enter filename to save (example: myjournal.txt): ");
        string filename = Console.ReadLine();
        _journal.SaveToFile(filename);
    }

    private void LoadJournal()
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();
        _journal.LoadFromFile(filename);
    }
}
