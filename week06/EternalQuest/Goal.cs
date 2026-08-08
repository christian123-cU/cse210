using System;

// Base class for all kinds of goals. Holds the attributes and behaviors
// that every goal shares, and defines the "contract" (via abstract methods)
// that every derived goal type must fulfill.
public abstract class Goal
{
    private string _shortName;
    private string _description;
    private int _points;

    public Goal(string shortName, string description, int points)
    {
        _shortName = shortName;
        _description = description;
        _points = points;
    }

    public string GetShortName()
    {
        return _shortName;
    }

    public string GetDescription()
    {
        return _description;
    }

    public int GetPoints()
    {
        return _points;
    }

    // Marks the goal as accomplished (in whatever way is appropriate for
    // that goal type) and returns the number of points earned, which may
    // include a bonus.
    public abstract int RecordEvent();

    // Returns true if the goal has been fully completed.
    public abstract bool IsComplete();

    // Returns a string suitable for saving to / loading from a file.
    public abstract string GetStringRepresentation();

    // Returns a line suitable for display in the goal list, e.g.
    // "[X] Run a marathon (Run a marathon and finish)"
    // Overridden by ChecklistGoal to also show progress.
    public virtual string GetDetailsString()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkbox} {_shortName} ({_description})";
    }
}
