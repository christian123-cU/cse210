using System;
using System.Collections.Generic;

// A small standalone question record used by TriviaChallenge.
public class TriviaQuestion
{
    public string Question { get; }
    public string Clue { get; }
    public string Answer { get; }
    public int BonusPoints { get; }

    public TriviaQuestion(string question, string clue, string answer, int bonusPoints)
    {
        Question = question;
        Clue = clue;
        Answer = answer;
        BonusPoints = bonusPoints;
    }
}

// A standalone bonus mini-game, intentionally kept outside the Goal
// hierarchy since answering a trivia question is a different kind of
// activity than recording a goal event.
public class TriviaChallenge
{
    private List<TriviaQuestion> _questions;
    private Random _random;

    public TriviaChallenge()
    {
        _random = new Random();
        _questions = GetDefaultQuestions();
    }

    // Runs one round of trivia via the console: shows a question, offers
    // a clue if requested, checks the answer, and returns any bonus
    // points earned (0 if incorrect or skipped).
    public int PlayRound()
    {
        TriviaQuestion q = _questions[_random.Next(_questions.Count)];

        Console.WriteLine("\n--- Bonus Trivia ---");
        Console.WriteLine(q.Question);
        Console.Write("Your answer (or type 'clue' for a hint, 'skip' to skip): ");
        string? input = Console.ReadLine();

        if (input != null && input.Trim().ToLower() == "clue")
        {
            Console.WriteLine($"Clue: {q.Clue}");
            Console.Write("Your answer: ");
            input = Console.ReadLine();
        }

        if (input != null && input.Trim().ToLower() == q.Answer.ToLower())
        {
            Console.WriteLine($"Correct! You earned {q.BonusPoints} bonus points.");
            return q.BonusPoints;
        }

        Console.WriteLine($"Not quite. The answer was: {q.Answer}");
        return 0;
    }

    private List<TriviaQuestion> GetDefaultQuestions()
    {
        return new List<TriviaQuestion>
        {
            new TriviaQuestion(
                "How many days does a full week contain?",
                "Count from Sunday to Saturday.",
                "7",
                50),
            new TriviaQuestion(
                "In the story of creation, on which day is rest introduced as a practice?",
                "It comes right after the sixth day of work.",
                "seventh",
                75),
            new TriviaQuestion(
                "What natural resource, received daily and best in the morning, supports both mood and vitamin production?",
                "It rises in the east.",
                "sunlight",
                50),
            new TriviaQuestion(
                "What is the name for consistently choosing moderation and avoiding harmful substances?",
                "It's one of the classic 'laws of health.'",
                "temperance",
                60),
            new TriviaQuestion(
                "Which meal of water intake habit is often recommended: drinking it, or avoiding it, between meals for better digestion?",
                "Fits with the idea of giving your stomach a break.",
                "avoiding",
                40),
        };
    }
}
