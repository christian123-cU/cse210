using System;
using System.Collections.Generic;
using System.IO;

/// <summary>
/// Exceeds requirements: tracks how many times each activity has been run
/// and the total seconds spent on it, and can save that log to disk and
/// reload it later, so the history survives between runs of the program.
/// </summary>
public class ActivityLog
{
    private const string LogFilePath = "activity_log.txt";

    private Dictionary<string, int> _runCounts = new Dictionary<string, int>();
    private Dictionary<string, int> _totalSeconds = new Dictionary<string, int>();

    /// <summary>Records that an activity was just completed.</summary>
    /// <param name="activityName">The activity's name, e.g. "Breathing".</param>
    /// <param name="durationSeconds">How many seconds the session lasted.</param>
    public void RecordRun(string activityName, int durationSeconds)
    {
        if (!_runCounts.ContainsKey(activityName))
        {
            _runCounts[activityName] = 0;
            _totalSeconds[activityName] = 0;
        }

        _runCounts[activityName]++;
        _totalSeconds[activityName] += durationSeconds;
    }

    /// <summary>Prints a summary of every activity recorded so far.</summary>
    public void Display()
    {
        Console.WriteLine();
        Console.WriteLine("Activity Log:");

        if (_runCounts.Count == 0)
        {
            Console.WriteLine("  No activities have been performed yet.");
            return;
        }

        foreach (KeyValuePair<string, int> entry in _runCounts)
        {
            string name = entry.Key;
            int count = entry.Value;
            int seconds = _totalSeconds[name];
            Console.WriteLine($"  {name}: {count} session(s), {seconds} total seconds");
        }
    }

    /// <summary>Writes the current log to a text file in the working directory.</summary>
    public void Save()
    {
        List<string> lines = new List<string>();
        foreach (KeyValuePair<string, int> entry in _runCounts)
        {
            lines.Add($"{entry.Key},{entry.Value},{_totalSeconds[entry.Key]}");
        }

        File.WriteAllLines(LogFilePath, lines);
    }

    /// <summary>
    /// Loads a previously saved log, if one exists. Safe to call even if the
    /// file has never been created yet (e.g. on the very first run).
    /// </summary>
    public void Load()
    {
        if (!File.Exists(LogFilePath))
        {
            return;
        }

        foreach (string line in File.ReadAllLines(LogFilePath))
        {
            string[] parts = line.Split(',');
            if (parts.Length != 3)
            {
                continue;
            }

            string name = parts[0];
            if (int.TryParse(parts[1], out int count) && int.TryParse(parts[2], out int seconds))
            {
                _runCounts[name] = count;
                _totalSeconds[name] = seconds;
            }
        }
    }
}
