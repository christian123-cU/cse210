using System;

// A goal that is completed a single time. Once recorded, it stays complete.
public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string shortName, string description, int points)
        : base(shortName, description, points)
    {
        // A brand-new goal has not been done yet, so default it to false
        // rather than requiring the caller to pass it in.
        _isComplete = false;
    }

    public override int RecordEvent()
    {
        _isComplete = true;
        return GetPoints();
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{GetShortName()},{GetDescription()},{GetPoints()},{_isComplete}";
    }

    // Recreates a SimpleGoal from a saved string representation.
    public static SimpleGoal CreateFromString(string[] parts)
    {
        // parts: [ "SimpleGoal", name, description, points, isComplete ]
        string name = parts[1];
        string description = parts[2];
        int points = int.Parse(parts[3]);
        bool isComplete = bool.Parse(parts[4]);

        SimpleGoal goal = new SimpleGoal(name, description, points);
        if (isComplete)
        {
            goal.RecordEvent();
        }
        return goal;
    }
}
