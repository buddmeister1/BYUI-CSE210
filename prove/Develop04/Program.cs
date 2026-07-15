using System;

// Creativity-Exceeded Requirements
// I added two journal activities - Gratitude Journal and Development Journal
// They both inherit from the new shared JournalActivity class *Which is a another layer below the current activity and it saves the inputers response
// with a timestamp to it's designated personal text file using File I/O.
// The benefit of that is the log of these entrys will continue every time this program runs.


class Program
{
    static void Main(string[] args)
    {
        bool keepRunning = true;

        while (keepRunning)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Gratitude Journal Activity");
            Console.WriteLine("5. Development Journal Activity");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity breathing = new BreathingActivity();
                breathing.RunActivity();
            }
            else if (choice == "2")
            {
                ReflectionActivity reflection = new ReflectionActivity();
                reflection.RunActivity();
            }
            else if (choice == "3")
            {
                ListingActivity listing = new ListingActivity();
                listing.RunActivity();
            }
            else if (choice == "4")
            {
                GratitudeJournalActivity gratitude = new GratitudeJournalActivity();
                gratitude.RunActivity();
            }
            else if (choice == "5")
            {
                DevelopmentJournalActivity development = new DevelopmentJournalActivity();
                development.RunActivity();
            }
            else if (choice == "6")
            {
                keepRunning = false;
            }
        }
    }
}