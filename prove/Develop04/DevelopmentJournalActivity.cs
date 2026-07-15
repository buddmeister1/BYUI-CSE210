using System.Collections.Generic;

class DevelopmentJournalActivity : JournalActivity
{
    public DevelopmentJournalActivity()
        : base("Development Journal Activity",
               "This activity will help you grow by pondering what you want to work on this week and what you could do differently or improve upon tomorrow.",
               new List<string>
               {
                   "What is one thing you would like to accomplish this week?",
                   "What skill or habit would you like to improve on?",
                   "What did not go as well as you hoped today, and why?",
                   "What will you do differently tomorrow?",
                   "What obstacle do you expect this week, and how will you prepare for it?",
                   "What is one small step you can take today toward a bigger goal?"
               },
               "development_log.txt")
    {
    }
}