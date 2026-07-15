using System.Collections.Generic;

class GratitudeJournalActivity : JournalActivity
{
    public GratitudeJournalActivity()
        : base("Gratitude Journal Activity",
               "This activity will help you build gratitude by writing down things you are thankful for. Each entry will be saved to your personal gratitude log.",
               new List<string>
               {
                   "What made you smile today?",
                   "Who is someone you are grateful for right now?",
                   "What is something small that brought you joy this week?",
                   "What ability or skill are you thankful to have?"
               },
               "gratitude_log.txt")
    {
    }
}