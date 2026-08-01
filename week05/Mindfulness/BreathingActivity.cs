using System;

/// <summary>
/// A guided deep-breathing session, alternating "breathe in" and "breathe out"
/// prompts until the requested duration has elapsed.
/// </summary>
public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base(
            "Breathing",
            "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());
        while (DateTime.Now < endTime)
        {
            Console.WriteLine();
            Console.Write("Breathe in...");
            // Calling the base method instead means there's
            // only one countdown implementation to maintain, not two.
            ShowCountDown(4);

            Console.WriteLine();
            Console.Write("Breathe out...");
            ShowCountDown(4);
        }

        DisplayEndingMessage();
    }
}
