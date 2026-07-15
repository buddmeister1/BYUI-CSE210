public class EternalGoal : Goal
{
    public EternalGoal(string shortName, string description, int points) : base(shortName, description, points)
    {
    }

    public override void RecordEvent()
    {
        // Eternal goals are never "finished" -- recording just keeps
        // the streak and score moving. Nothing else needs to change here.
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetStringRepresentation()
    {
        return "EternalGoal|" + GetCommonStringRepresentation();
    }
}