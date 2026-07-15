using System;

public abstract class Goal
{
    private string _shortName;
    private string _description;
    private int _points;

    private int _currentStreak;
    private int _totalAttempts;
    private int _totalSuccesses;
    private bool _hasReward;
    private RewardTriggerType _triggerType;
    private int _triggerThreshold;
    private string _rewardDescription;
    private bool _rewardClaimed;

    public Goal(string shortName, string description, int points)
    {
        _shortName = shortName;
        _description = description;
        _points = points;
        _currentStreak = 0;
        _totalAttempts = 0;
        _totalSuccesses = 0;
        _hasReward = false;
        _triggerType = RewardTriggerType.StreakCount;
        _triggerThreshold = 0;
        _rewardDescription = "";
        _rewardClaimed = false;
    }

    public int GetPoints()
    {
        return _points;
    }

    public string GetShortName()
    {
        return _shortName;
    }

    public abstract void RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetStringRepresentation();

    public virtual int GetBonusPoints()
    {
        return 0;
    }

    public virtual string GetDetailsString()
    {
        string checkBox = "";
        if (IsComplete())
        {
            checkBox = "[X]";
        }
        else
        {
            checkBox = "[ ]";
        }

        string details = checkBox + " " + _shortName + " (" + _description + ")";

        if (_hasReward)
        {
            details = details + " -- Current streak: " + _currentStreak;
        }

        return details;
    }

    public void SetupReward(RewardTriggerType triggerType, int threshold, string rewardDescription)
    {
        _triggerType = triggerType;
        _triggerThreshold = threshold;
        _rewardDescription = rewardDescription;
        _hasReward = true;
        _rewardClaimed = false;
    }

    public void UpdateStreakOnSuccess()
    {
        _currentStreak = _currentStreak + 1;
        _totalAttempts = _totalAttempts + 1;
        _totalSuccesses = _totalSuccesses + 1;
    }

    public void LogMissedDay()
    {
        _currentStreak = 0;
        _totalAttempts = _totalAttempts + 1;
    }

    public string CheckRewardTrigger()
    {
        if (_hasReward == false || _rewardClaimed == true)
        {
            return null;
        }

        bool triggered = false;

        if (_triggerType == RewardTriggerType.StreakCount)
        {
            if (_currentStreak >= _triggerThreshold)
            {
                triggered = true;
            }
        }
        else if (_triggerType == RewardTriggerType.SuccessRate)
        {
            if (_totalAttempts > 0)
            {
                int rate = (_totalSuccesses * 100) / _totalAttempts;
                if (rate >= _triggerThreshold)
                {
                    triggered = true;
                }
            }
        }

        if (triggered)
        {
            _rewardClaimed = true;
            return _rewardDescription;
        }

        return null;
    }

    public void LoadStreakData(int currentStreak, int totalAttempts, int totalSuccesses, bool hasReward, RewardTriggerType triggerType, int triggerThreshold, string rewardDescription, bool rewardClaimed)
    {
        _currentStreak = currentStreak;
        _totalAttempts = totalAttempts;
        _totalSuccesses = totalSuccesses;
        _hasReward = hasReward;
        _triggerType = triggerType;
        _triggerThreshold = triggerThreshold;
        _rewardDescription = rewardDescription;
        _rewardClaimed = rewardClaimed;
    }

    protected string GetCommonStringRepresentation()
    {
        return _shortName + "|" + _description + "|" + _points + "|" + _currentStreak + "|" + _totalAttempts + "|" + _totalSuccesses + "|" + _hasReward + "|" + _triggerType + "|" + _triggerThreshold + "|" + _rewardDescription + "|" + _rewardClaimed;
    }
}