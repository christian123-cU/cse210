using System;
using System.Collections.Generic;
using System.Threading;

/// <summary>
/// Represents a mindfulness activity. Holds the state and behavior shared by
/// every activity type (name, description, duration, and the pause/animation
/// helpers), so derived classes only need to implement what's unique to them.
/// </summary>
public class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    //  Only one Random is ever
    // created for the whole program, rather than each activity creating its
    // own - creating several new Random() instances back-to-back can seed
    // them identically since Random seeds from the system clock.
    private static readonly Random _random = new Random();

    /// <param name="name">Short name of the activity, e.g. "Breathing".</param>
    /// <param name="description">Explanation shown to the user at the start.</param>
    public Activity(string name, string description)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Activity name is required.", nameof(name));
        }

        if (string.IsNullOrWhiteSpace(description))
        {
            throw new ArgumentException("Activity description is required.", nameof(description));
        }

        _name = name;
        _description = description;
    }

    /// <summary>
    /// Shows the activity's name and description, asks the user for a
    /// session duration, and pauses briefly before the activity begins.
    /// </summary>
    public void DisplayStartingMessage()
    {
        Console.WriteLine();
        Console.WriteLine($"{_name} Activity");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();

        _duration = PromptForDuration();

        Console.WriteLine();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
    }

    // Repeats the prompt until the user enters a valid, positive whole
    // number, instead of letting int.Parse crash the program on bad input.
    private int PromptForDuration()
    {
        while (true)
        {
            Console.Write("How long, in seconds, would you like for your session? ");
            if (int.TryParse(Console.ReadLine(), out int seconds) && seconds > 0)
            {
                return seconds;
            }

            Console.WriteLine("Please enter a positive whole number of seconds.");
        }
    }

    /// <summary>
    /// Congratulates the user and reports the activity and duration just completed.
    /// </summary>
    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(3);
        Console.WriteLine();
        Console.WriteLine($"You have completed the {_name} activity for {_duration} seconds.");
        ShowSpinner(3);
    }

    /// <summary>Gets the activity's display name (e.g. for logging purposes).</summary>
    public string GetName()
    {
        return _name;
    }

    /// <summary>Gets the duration, in seconds, the user selected for the current session.</summary>
    public int GetDuration()
    {
        return _duration;
    }

    /// <summary>Displays a spinning animation for the given number of seconds.</summary>
    public void ShowSpinner(int seconds)
    {
        string[] animationChars = { "|", "/", "-", "\\" };
        int i = 0;
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        while (DateTime.Now < endTime)
        {
            Console.Write(animationChars[i]);
            Thread.Sleep(250);
            Console.Write("\b \b");
            i++;
            if (i >= animationChars.Length)
            {
                i = 0;
            }
        }
    }

    /// <summary>Displays a numeric countdown animation for the given number of seconds.</summary>
    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    /// <summary>
    /// Picks a random item from <paramref name="allItems"/> without repeating
    /// any item until every item in the list has been returned once.
    /// <paramref name="remainingItems"/> is the "not yet used this round"
    /// pool for a particular list - callers keep this list as a field and
    /// pass the same instance in on every call. When the pool runs dry, it
    /// refills from <paramref name="allItems"/> and the cycle starts over.
    /// This is what backs the "no repeats until everything's been shown"
    /// behavior in ListingActivity and ReflectingActivity.
    /// </summary>
    protected static string GetRandomItem(List<string> allItems, List<string> remainingItems)
    {
        if (remainingItems.Count == 0)
        {
            remainingItems.AddRange(allItems);
        }

        int index = _random.Next(remainingItems.Count);
        string item = remainingItems[index];
        remainingItems.RemoveAt(index);

        return item;
    }
}
