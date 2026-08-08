using System;
using System.Collections.Generic;
using System.Linq;

// A standalone tracker (separate from the Goal hierarchy) that unlocks
// once the user has kept up a 30-day daily study streak. It holds a set
// of 28 short foundational topics that the user can work through one at
// a time, similar in spirit to the 28 Fundamental Beliefs studied by
// members of some faith traditions -- presented here in a generic,
// non-denominational way so it is useful to anyone.
public class FoundationsTracker
{
    private bool _isUnlocked;
    private List<string> _topics;
    private List<bool> _topicCompleted;

    public FoundationsTracker()
    {
        _isUnlocked = false;
        _topics = GetDefaultTopics();
        _topicCompleted = new List<bool>();
        for (int i = 0; i < _topics.Count; i++)
        {
            _topicCompleted.Add(false);
        }
    }

    public bool IsUnlocked()
    {
        return _isUnlocked;
    }

    // Called by GoalManager once the 30-day streak goal reports complete.
    public void Unlock()
    {
        if (!_isUnlocked)
        {
            _isUnlocked = true;
            Console.WriteLine("\n*** Congratulations! You've kept a 30-day streak! ***");
            Console.WriteLine("The Foundations study module is now unlocked.\n");
        }
    }

    // Returns the next topic that has not yet been marked complete,
    // or null if all topics are finished.
    public string? GetNextTopic()
    {
        for (int i = 0; i < _topics.Count; i++)
        {
            if (!_topicCompleted[i])
            {
                return $"{i + 1}. {_topics[i]}";
            }
        }
        return null;
    }

    public void MarkTopicComplete(int topicNumber)
    {
        int index = topicNumber - 1;
        if (index >= 0 && index < _topicCompleted.Count)
        {
            _topicCompleted[index] = true;
        }
        else
        {
            Console.WriteLine("That topic number does not exist.");
        }
    }

    public void ListTopics()
    {
        for (int i = 0; i < _topics.Count; i++)
        {
            string checkbox = _topicCompleted[i] ? "[X]" : "[ ]";
            Console.WriteLine($"{checkbox} {i + 1}. {_topics[i]}");
        }
    }

    public int GetCompletedCount()
    {
        return _topicCompleted.Count(c => c);
    }

    public int GetTotalCount()
    {
        return _topics.Count;
    }

    // Produces a string suitable for saving to a file.
    public string GetStringRepresentation()
    {
        string completedFlags = string.Join(";", _topicCompleted);
        return $"FoundationsTracker:{_isUnlocked},{completedFlags}";
    }

    public static FoundationsTracker CreateFromString(string[] parts)
    {
        // parts: [ "FoundationsTracker", isUnlocked, "true;false;..." ]
        FoundationsTracker tracker = new FoundationsTracker();
        tracker._isUnlocked = bool.Parse(parts[1]);

        if (parts.Length > 2 && !string.IsNullOrWhiteSpace(parts[2]))
        {
            string[] flags = parts[2].Split(';');
            for (int i = 0; i < flags.Length && i < tracker._topicCompleted.Count; i++)
            {
                tracker._topicCompleted[i] = bool.Parse(flags[i]);
            }
        }

        return tracker;
    }

    private List<string> GetDefaultTopics()
    {
        return new List<string>
        {
            "Foundations of Trust",
            "Foundations of Purpose",
            "Foundations of Peace",
            "Foundations of Growth",
            "Foundations of Community",
            "Foundations of Gratitude",
            "Foundations of Renewal",
            "Foundations of Wisdom",
            "Foundations of Perseverance",
            "Foundations of Humility",
            "Foundations of Service",
            "Foundations of Hope",
            "Foundations of Discipline",
            "Foundations of Compassion",
            "Foundations of Reflection",
            "Foundations of Balance",
            "Foundations of Forgiveness",
            "Foundations of Integrity",
            "Foundations of Contentment",
            "Foundations of Courage",
            "Foundations of Stewardship",
            "Foundations of Rest",
            "Foundations of Connection",
            "Foundations of Vision",
            "Foundations of Legacy",
            "Foundations of Wholeness",
            "Foundations of Transformation",
            "Foundations of Meaning"
        };
    }
}
