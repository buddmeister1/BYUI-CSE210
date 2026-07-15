using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();

      
        // Creativity/Exceeding Requirements
        // 1. Streak and Reward system: any goal can by choice be set up with a personal reward. The user chooses whether the
        //   reward unlocks after reaching a chosen number of consistent
        //    successes (a streak) or after reaching a chosen success rate
        //    percentage. Rewards can be picked from a preset list or
        //    typed in as they would prefer(custom)
        //   
        // 2. "Log a Missed Day" allows a streak to break which
        //    is what makes the success rate percentage important instead
        //    of always sitting at 100%.

        // 3. Bonus points for ChecklistGoals are added with a
        //    polymorphic GetBonusPoints() method (returns 0 at base in
        //    the Goal class, overridden only in ChecklistGoal), so
        //    GoalManager never needs to check what type of goal it is
        //    working with.
        
    }
}