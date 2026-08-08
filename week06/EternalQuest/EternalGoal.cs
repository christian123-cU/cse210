using System;

// A goal that repeats indefinitely and is never "finished" (for example,
// a daily habit). Every time it is recorded, the user earns points, but
// the goal itself is never marked complete.
public class EternalGoal : Goal
{
    public EternalGoal(string shortName, string description, int points)
        : base(shortName, description, points)
    {
    }

    public override int RecordEvent()
    {
        return GetPoints();
    }

    public override bool IsComplete()
    {
        // Eternal goals are, by definition, never complete.
        return false;
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{GetShortName()},{GetDescription()},{GetPoints()}";
    }

    public static EternalGoal CreateFromString(string[] parts)
    {
        // parts: [ "EternalGoal", name, description, points ]
        string name = parts[1];
        string description = parts[2];
        int points = int.Parse(parts[3]);

        return new EternalGoal(name, description, points);
    }
}
