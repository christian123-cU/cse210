using System;

// -----------------------------------------------------------------------
// Eternal Quest - a goal tracking program.
//
// Ways this program exceeds the core requirements:
// 1. FoundationsTracker: a separate class (not part of the Goal hierarchy)
//    that unlocks a 28-topic study module once the user reaches a 30-day
//    daily streak, tracked via a dedicated ChecklistGoal inside GoalManager.
// 2. TriviaChallenge: a standalone bonus mini-game with clue support,
//    reachable from the main menu, that awards bonus points for correct
//    answers.
// 3. A tiered progression system (Awakening -> Growth -> Transformation)
//    based on total score, shown alongside the player's stats.
// 4. A "Learn More" menu offering optional external resources for anyone
//    who wants to explore the underlying topics further.
// -----------------------------------------------------------------------

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("=====================================");
        Console.WriteLine("       Welcome to Eternal Quest");
        Console.WriteLine("=====================================");

        GoalManager manager = new GoalManager();
        manager.Start();
    }
}
