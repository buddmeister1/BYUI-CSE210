using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries yet. Start writing!");
            return;
        }

        Console.WriteLine($"--- Journal ({_entries.Count} entries) ---\n");

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }

        double avg = _entries.Average(e => e.GetMood());
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"Overall average mood: {avg:F1} / 5.0");
        Console.ResetColor();
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine(entry.GetSaveText());
            }
        }
        Console.WriteLine($"Journal saved to {filename}.");
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found. Check the filename and try again.");
            return;
        }

        _entries.Clear();

        using (StreamReader reader = new StreamReader(filename))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.Trim() != "")
                {
                    Entry entry = Entry.FromSaveText(line);
                    _entries.Add(entry);
                }
            }
        }
        Console.WriteLine($"Loaded {_entries.Count} entries from {filename}.");
    }
}