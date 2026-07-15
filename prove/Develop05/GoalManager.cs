using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        string choice = "";

        while (choice != "7")
        {
            Console.WriteLine();
            Console.WriteLine("Eternal Quest Menu");
            Console.WriteLine("1. Create a new goal");
            Console.WriteLine("2. List goals");
            Console.WriteLine("3. Record an event");
            Console.WriteLine("4. Log a missed day (breaks a streak)");
            Console.WriteLine("5. Display score");
            Console.WriteLine("6. Load goals");
            Console.WriteLine("7. Save and quit");
            Console.Write("Select an option: ");
            choice = Console.ReadLine();
            Console.WriteLine();

            if (choice == "1")
            {
                CreateGoal();
            }
            else if (choice == "2")
            {
                ListGoalNames();
            }
            else if (choice == "3")
            {
                RecordEvent();
            }
            else if (choice == "4")
            {
                LogMissedDay();
            }
            else if (choice == "5")
            {
                DisplayPlayerInfo();
            }
            else if (choice == "6")
            {
                LoadGoals();
            }
        }

        SaveGoals();
        Console.WriteLine("Goodbye!");
    }

    public void ListGoalNames()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You don't have any goals yet.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine((i + 1) + ". " + _goals[i].GetDetailsString());
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("What type of goal would you like to create?");
        Console.WriteLine("1. Simple Goal (one-time)");
        Console.WriteLine("2. Eternal Goal (never finished)");
        Console.WriteLine("3. Checklist Goal (finish X times)");
        Console.Write("Enter your choice: ");
        string typeChoice = Console.ReadLine();

        Console.Write("What is the short name of this goal? ");
        string shortName = Console.ReadLine();

        Console.Write("What is a short description of this goal? ");
        string description = Console.ReadLine();

        Console.Write("How many points is this goal worth? ");
        int points = int.Parse(Console.ReadLine());

        Goal newGoal = null;

        if (typeChoice == "1")
        {
            newGoal = new SimpleGoal(shortName, description, points);
        }
        else if (typeChoice == "2")
        {
            newGoal = new EternalGoal(shortName, description, points);
        }
        else if (typeChoice == "3")
        {
            Console.Write("How many times must this goal be completed? ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("What bonus points are earned when it's finished? ");
            int bonus = int.Parse(Console.ReadLine());

            newGoal = new ChecklistGoal(shortName, description, points, target, bonus);
        }
        else
        {
            Console.WriteLine("That is not a valid goal type.");
            return;
        }

        SetupRewardIfWanted(newGoal);

        _goals.Add(newGoal);
        Console.WriteLine("Goal created!");
    }

    private void SetupRewardIfWanted(Goal goal)
    {
        Console.Write("Would you like to set up a personal reward for this goal? (y/n): ");
        string answer = Console.ReadLine();

        if (answer.ToLower() == "y")
        {
            Console.WriteLine("How should the reward be triggered?");
            Console.WriteLine("1. Reach a streak count (consecutive successes)");
            Console.WriteLine("2. Reach a success rate percentage");
            Console.Write("Enter your choice: ");
            string triggerChoice = Console.ReadLine();

            RewardTriggerType triggerType = RewardTriggerType.StreakCount;
            string prompt = "How many in a row before you earn the reward? ";

            if (triggerChoice == "2")
            {
                triggerType = RewardTriggerType.SuccessRate;
                prompt = "What success rate percentage should trigger the reward (1-100)? ";
            }

            Console.Write(prompt);
            int threshold = int.Parse(Console.ReadLine());

            string rewardDescription = ChooseRewardDescription();

            goal.SetupReward(triggerType, threshold, rewardDescription);
        }
    }

    private string ChooseRewardDescription()
    {
        Console.WriteLine("Choose a reward:");
        Console.WriteLine("1. Watch a movie");
        Console.WriteLine("2. Get a treat");
        Console.WriteLine("3. Take a rest day");
        Console.WriteLine("4. Buy something small");
        Console.WriteLine("5. Write my own custom reward");
        Console.Write("Enter your choice: ");
        string choice = Console.ReadLine();

        if (choice == "1")
        {
            return "Watch a movie";
        }
        else if (choice == "2")
        {
            return "Get a treat";
        }
        else if (choice == "3")
        {
            return "Take a rest day";
        }
        else if (choice == "4")
        {
            return "Buy something small";
        }
        else
        {
            Console.Write("Type your custom reward: ");
            return Console.ReadLine();
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You don't have any goals yet. Create one first!");
            return;
        }

        ListGoalNames();
        Console.Write("Which goal did you accomplish? Enter the number: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("That is not a valid goal number.");
            return;
        }

        Goal goal = _goals[index];
        goal.RecordEvent();

        int pointsEarned = goal.GetPoints() + goal.GetBonusPoints();
        _score = _score + pointsEarned;
        goal.UpdateStreakOnSuccess();

        Console.WriteLine("You earned " + pointsEarned + " points!");
        Console.WriteLine("Your total score is now: " + _score);

        string reward = goal.CheckRewardTrigger();
        if (reward != null)
        {
            Console.WriteLine("Congratulations! You earned a reward: " + reward);
        }
    }

    public void LogMissedDay()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You don't have any goals yet.");
            return;
        }

        ListGoalNames();
        Console.Write("Which goal did you miss? Enter the number: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("That is not a valid goal number.");
            return;
        }

        _goals[index].LogMissedDay();
        Console.WriteLine("Streak reset. Keep going - you can do this!");
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine("Your current score is: " + _score);
    }

    public void SaveGoals()
    {
        List<string> lines = new List<string>();
        lines.Add(_score.ToString());

        foreach (Goal goal in _goals)
        {
            lines.Add(goal.GetStringRepresentation());
        }

        File.WriteAllLines("goals.txt", lines);
        Console.WriteLine("Goals saved!");
    }

    public void LoadGoals()
    {
        if (File.Exists("goals.txt") == false)
        {
            Console.WriteLine("No saved goals found.");
            return;
        }

        string[] lines = File.ReadAllLines("goals.txt");

        _goals.Clear();
        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');
            string type = parts[0];

            string shortName = parts[1];
            string description = parts[2];
            int points = int.Parse(parts[3]);
            int currentStreak = int.Parse(parts[4]);
            int totalAttempts = int.Parse(parts[5]);
            int totalSuccesses = int.Parse(parts[6]);
            bool hasReward = bool.Parse(parts[7]);
            RewardTriggerType triggerType = (RewardTriggerType)Enum.Parse(typeof(RewardTriggerType), parts[8]);
            int triggerThreshold = int.Parse(parts[9]);
            string rewardDescription = parts[10];
            bool rewardClaimed = bool.Parse(parts[11]);

            Goal loadedGoal = null;

            if (type == "SimpleGoal")
            {
                bool isComplete = bool.Parse(parts[12]);
                SimpleGoal simpleGoal = new SimpleGoal(shortName, description, points);
                simpleGoal.LoadCompletionStatus(isComplete);
                loadedGoal = simpleGoal;
            }
            else if (type == "EternalGoal")
            {
                loadedGoal = new EternalGoal(shortName, description, points);
            }
            else if (type == "ChecklistGoal")
            {
                int amountCompleted = int.Parse(parts[12]);
                int target = int.Parse(parts[13]);
                int bonus = int.Parse(parts[14]);
                bool bonusAwarded = bool.Parse(parts[15]);
                ChecklistGoal checklistGoal = new ChecklistGoal(shortName, description, points, target, bonus);
                checklistGoal.LoadChecklistData(amountCompleted, target, bonus, bonusAwarded);
                loadedGoal = checklistGoal;
            }

            if (loadedGoal != null)
            {
                loadedGoal.LoadStreakData(currentStreak, totalAttempts, totalSuccesses, hasReward, triggerType, triggerThreshold, rewardDescription, rewardClaimed);
                _goals.Add(loadedGoal);
            }
        }

        Console.WriteLine("Goals loaded!");
    }
}