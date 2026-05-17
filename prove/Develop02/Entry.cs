using System;

public class Entry
{
    private string _date;
    private string _prompt;
    private string _response;
    private int _moodScore;

    public Entry(string date, string prompt, string response, int moodScore = 3)
    {
        _date = date;
        _prompt = prompt;
        _response = response;
        _moodScore = moodScore;
    }

    public void Display()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Date:     {_date}");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"Prompt:   {_prompt}");
        Console.ResetColor();
        Console.WriteLine($"Response: {_response}");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Mood:     {_moodScore}/5");
        Console.ResetColor();
        Console.WriteLine();
    }

    public string GetSaveText()
    {
        return $"{_date}~|~{_prompt}~|~{_response}~|~{_moodScore}";
    }

    public int GetMood()
    {
        return _moodScore;
    }

    public static Entry FromSaveText(string line)
    {
        string[] parts = line.Split("~|~");
        string date = parts[0];
        string prompt = parts[1];
        string response = parts[2];
        int mood = parts.Length > 3 ? int.Parse(parts[3]) : 3;
        return new Entry(date, prompt, response, mood);
    }
}