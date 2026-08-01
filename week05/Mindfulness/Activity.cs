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

    // Shared by every derived class that needs a "pick something random from
    // a list" behavior (see GetRandomItem below). Only one Random is ever
    // created for the whole program, rather than each activity creating its
    // own. That matters because Random seeds itself from the system clock -
    // creating several new Random() instances back-to-back can seed them
    // identically, so their "random" output ends up repeating.
    private static readonly Random _random = new Random();

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartingMessage()
    {
        Console.WriteLine();
        Console.WriteLine($"{_name} Activity");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());

        Console.WriteLine();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(3);
        Console.WriteLine();
        Console.WriteLine($"You have completed the {_name} activity for {_duration} seconds.");
        ShowSpinner(3);
    }

    // _duration is set by DisplayStartingMessage() above, based on user input.
    // Derived classes need to read it (to know how long to run), but it stays
    // private here rather than protected - this getter is the only access
    // point, same pattern as GetStudentName() in the last project.
    public int GetDuration()
    {
        return _duration;
    }

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

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    // Shared by ListingActivity and ReflectingActivity, both of which need to
    // pull a random string out of one of their lists. Centralizing it here
    // means there's exactly one Random instance for the whole program (see
    // the comment on _random above) instead of each class declaring its own.
    protected static string GetRandomItem(List<string> items)
    {
        int index = _random.Next(items.Count);
        return items[index];
    }
}
