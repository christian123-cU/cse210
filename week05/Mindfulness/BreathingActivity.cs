using System;
using System.Threading;

/// <summary>
/// A guided deep-breathing session: breathe in, hold, breathe out, repeated
/// until the requested duration has elapsed.
/// </summary>
public sealed class BreathingActivity : Activity
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
            ShowBreathAnimation(growing: true);

            Console.WriteLine();
            Console.Write("Hold...");
            ShowSpinner(4);

            Console.WriteLine();
            Console.Write("Breathe out...");
            ShowBreathAnimation(growing: false);
        }

        DisplayEndingMessage();
    }

    // Exceeds requirements: instead of a plain numeric countdown, this grows
    // (or shrinks) a bar of asterisks with pauses that get longer each step -
    // 400, 600, 800, 1000, 1200ms, adding up to exactly 4 seconds. The
    // lengthening pauses make the animation move quickly at first and ease
    // off near the end of the breath, similar to how an actual inhale or
    // exhale doesn't move at a constant speed. This is specific to breathing,
    // so it lives here rather than in the base Activity class - the hold
    // phase above still reuses Activity.ShowSpinner(), since a plain spinner
    // fits a held breath just fine.
    private void ShowBreathAnimation(bool growing)
    {
        int[] stepDelaysMs = { 400, 600, 800, 1000, 1200 };
        int maxBarLength = stepDelaysMs.Length;

        for (int step = 1; step <= maxBarLength; step++)
        {
            int barLength = growing ? step : maxBarLength - step + 1;
            string bar = new string('*', barLength);

            Console.Write(bar);
            Thread.Sleep(stepDelaysMs[step - 1]);

            Console.Write(new string('\b', bar.Length));
            Console.Write(new string(' ', bar.Length));
            Console.Write(new string('\b', bar.Length));
        }
    }
}
