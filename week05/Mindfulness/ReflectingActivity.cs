using System;
using System.Collections.Generic;

/// <summary>
/// Shows the user a random reflective prompt, then walks them through a
/// series of random follow-up questions until the requested duration has
/// elapsed.
/// </summary>
public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    public ReflectingActivity()
        : base(
            "Reflecting",
            "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
    }

    public void Run()
    {
        DisplayStartingMessage();

        DisplayPrompt();
        DisplayQuestions();

        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {
        // Same shared helper ListingActivity uses - one Random instance for
        // the whole program instead of a fresh one per class per call.
        return GetRandomItem(_prompts);
    }

    public string GetRandomQuestion()
    {
        return GetRandomItem(_questions);
    }

    public void DisplayPrompt()
    {
        Console.WriteLine();
        Console.WriteLine(GetRandomPrompt());
        // Activity.ShowSpinner() already does exactly this animation. Round 1
        // rewrote the same spinner loop by hand here and again below in
        // DisplayQuestions() - two extra copies of logic that already existed.
        ShowSpinner(3);
    }

    public void DisplayQuestions()
    {
        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());
        while (DateTime.Now < endTime)
        {
            Console.WriteLine();
            Console.WriteLine(GetRandomQuestion());
            ShowSpinner(3);
        }
    }
}
