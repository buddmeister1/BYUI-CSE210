using System;
using System.Collections.Generic;
using System.IO;

class JournalActivity : Activity
{
    private List<string> _prompts;
    private Random _random;
    private string _logFilePath;

    public JournalActivity(string name, string description, List<string> prompts, string logFilePath)
        : base(name, description)
    {
        _prompts = prompts;
        _random = new Random();
        _logFilePath = logFilePath;
    }

    public void RunActivity()
    {
        StartActivity();

        int promptIndex = _random.Next(_prompts.Count);
        Console.WriteLine();
        Console.WriteLine(_prompts[promptIndex]);
        Console.WriteLine();
        Console.WriteLine("Type your response, then press enter.");

        string response = Console.ReadLine();
        SaveEntry(response);

        Console.WriteLine();
        Console.WriteLine("Your entry has been saved to your log.");
        ShowSpinner(3);

        EndActivity();
    }

    private void SaveEntry(string response)
    {
        string entry = $"{DateTime.Now}: {response}";
        File.AppendAllText(_logFilePath, entry + Environment.NewLine);
    }
}