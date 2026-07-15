public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;
    private bool _bonusAwarded;

    public ChecklistGoal(string shortName, string description, int points, int target, int bonus) : base(shortName, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
        _bonusAwarded = false;
    }

    public override void RecordEvent()
    {
        if (_amountCompleted < _target)
        {
            _amountCompleted = _amountCompleted + 1;
        }
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override int GetBonusPoints()
    {
        if (_amountCompleted >= _target && _bonusAwarded == false)
        {
            _bonusAwarded = true;
            return _bonus;
        }

        return 0;
    }

    public override string GetDetailsString()
    {
        string baseDetails = base.GetDetailsString();
        return baseDetails + " -- Completed " + _amountCompleted + "/" + _target + " times";
    }

    public override string GetStringRepresentation()
    {
        return "ChecklistGoal|" + GetCommonStringRepresentation() + "|" + _amountCompleted + "|" + _target + "|" + _bonus + "|" + _bonusAwarded;
    }

    public void LoadChecklistData(int amountCompleted, int target, int bonus, bool bonusAwarded)
    {
        _amountCompleted = amountCompleted;
        _target = target;
        _bonus = bonus;
        _bonusAwarded = bonusAwarded;
    }
}