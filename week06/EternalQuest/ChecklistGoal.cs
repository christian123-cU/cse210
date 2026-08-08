using System;

// A goal that must be accomplished a certain number of times before it is
// considered complete. Each recording earns the base points, and reaching
// the target awards an additional bonus.
public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string shortName, string description, int points, int target, int bonus)
        : base(shortName, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    public override int RecordEvent()
    {
        if (_amountCompleted < _target)
        {
            _amountCompleted++;
        }

        int earned = GetPoints();

        if (_amountCompleted == _target)
        {
            earned += _bonus;
        }

        return earned;
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public int GetAmountCompleted()
    {
        return _amountCompleted;
    }

    public int GetTarget()
    {
        return _target;
    }

    // Overridden to also show progress toward the target, e.g.
    // "[ ] Attend session (Weekly session) -- Completed 2/10 times"
    public override string GetDetailsString()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkbox} {GetShortName()} ({GetDescription()}) -- Completed {_amountCompleted}/{_target} times";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{GetShortName()},{GetDescription()},{GetPoints()},{_target},{_bonus},{_amountCompleted}";
    }

    public static ChecklistGoal CreateFromString(string[] parts)
    {
        // parts: [ "ChecklistGoal", name, description, points, target, bonus, amountCompleted ]
        string name = parts[1];
        string description = parts[2];
        int points = int.Parse(parts[3]);
        int target = int.Parse(parts[4]);
        int bonus = int.Parse(parts[5]);
        int amountCompleted = int.Parse(parts[6]);

        ChecklistGoal goal = new ChecklistGoal(name, description, points, target, bonus);
        for (int i = 0; i < amountCompleted; i++)
        {
            goal.RecordEvent();
        }
        return goal;
    }
}
