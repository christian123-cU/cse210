using System;
using System.Collections.Generic;

/// <summary>
/// Prompts the user to list as many items as they can for a random prompt,
/// until the requested duration has elapsed.
/// </summary>
public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;

    public ListingActivity()
        : base(
            "Listing",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine();
        Console.WriteLine(GetRandomPrompt());
        Console.WriteLine();
        Console.Write("You have a few seconds to think of items...");
        // Reuse the base class's countdown instead of copy of the
        // same loop.
        ShowCountDown(5);

        List<string> items = GetListFromUser();
        _count = items.Count;

        Console.WriteLine();
        Console.WriteLine($"You listed {_count} items!");

        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {
        // GetRandomItem() lives in Activity and uses one shared Random
        // instance for the whole program. initial code created a new Random()
        // right here every time a prompt was needed, which is the classic
        // bug where back-to-back "random" picks can come out identical.
        return GetRandomItem(_prompts);
    }

    public List<string> GetListFromUser()
    {
        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            string item = Console.ReadLine();
            items.Add(item);
        }

        return items;
    }
}
