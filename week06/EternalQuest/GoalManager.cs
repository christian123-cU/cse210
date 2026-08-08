using System;
using System.Collections.Generic;
using System.IO;

// Encapsulates all of the menu-driven functionality for the program:
// managing the list of goals, tracking the player's score, running the
// bonus features, and saving/loading progress. Keeping this logic in its
// own class (rather than as static functions in Program.cs) means it can
// hold its own state (the goals list, score, streak, etc.) as member
// variables instead of passing everything around as parameters.
public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private ChecklistGoal _dailyStreakGoal;
    private FoundationsTracker _foundations;
    private TriviaChallenge _trivia;

    private const int StreakTarget = 30;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _dailyStreakGoal = new ChecklistGoal(
            "Daily Streak",
            "Complete at least one study goal each day",
            10, StreakTarget, 1000);
        _foundations = new FoundationsTracker();
        _trivia = new TriviaChallenge();
    }

    public void Start()
    {
        SeedDefaultGoals();

        bool running = true;
        while (running)
        {
            Console.WriteLine();
            DisplayPlayerInfo();
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Display Goals");
            Console.WriteLine("2. Create New Goal");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Bonus Round (Trivia)");
            Console.WriteLine("5. Foundations Study Module");
            Console.WriteLine("6. Learn More (Resources)");
            Console.WriteLine("7. Save Goals");
            Console.WriteLine("8. Load Goals");
            Console.WriteLine("9. Exit");
            Console.Write("Select an option: ");

            string? choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    ListGoalDetails();
                    break;
                case "2":
                    CreateGoal();
                    break;
                case "3":
                    RecordEvent();
                    break;
                case "4":
                    BonusRound();
                    break;
                case "5":
                    FoundationsMenu();
                    break;
                case "6":
                    LearnMoreMenu();
                    break;
                case "7":
                    SaveGoals();
                    break;
                case "8":
                    LoadGoals();
                    break;
                case "9":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }

        Console.WriteLine("Thanks for working on your goals today. Keep going!");
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Score: {_score} points | Tier: {GetTier()}");
        Console.WriteLine($"Daily streak: {_dailyStreakGoal.GetAmountCompleted()}/{StreakTarget} days");
    }

    public void ListGoalNames()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("\nYour Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nWhat type of goal would you like to create?");
        Console.WriteLine("1. Simple Goal (done once)");
        Console.WriteLine("2. Eternal Goal (repeats forever)");
        Console.WriteLine("3. Checklist Goal (repeats a set number of times)");
        Console.Write("Select a type: ");
        string? type = Console.ReadLine();

        Console.Write("Short name: ");
        string name = Console.ReadLine() ?? "";

        Console.Write("Description: ");
        string description = Console.ReadLine() ?? "";

        Console.Write("Points per event: ");
        int points = ReadInt();

        switch (type)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("Target number of times to complete: ");
                int target = ReadInt();
                Console.Write("Bonus points for reaching the target: ");
                int bonus = ReadInt();
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid goal type. Goal not created.");
                return;
        }

        Console.WriteLine("Goal created!");
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You don't have any goals yet.");
            return;
        }

        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        int index = ReadInt() - 1;

        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("That is not a valid goal.");
            return;
        }

        Goal goal = _goals[index];
        int earned = goal.RecordEvent();
        _score += earned;
        Console.WriteLine($"You earned {earned} points!");

        // Any study-related goal recorded today also advances the streak.
        int streakEarned = _dailyStreakGoal.RecordEvent();
        _score += streakEarned;
        if (_dailyStreakGoal.IsComplete())
        {
            _foundations.Unlock();
        }
    }

    public void BonusRound()
    {
        int earned = _trivia.PlayRound();
        _score += earned;
    }

    public void FoundationsMenu()
    {
        if (!_foundations.IsUnlocked())
        {
            Console.WriteLine($"\nThe Foundations module unlocks after a {StreakTarget}-day streak.");
            Console.WriteLine($"Current streak: {_dailyStreakGoal.GetAmountCompleted()}/{StreakTarget} days.");
            return;
        }

        Console.WriteLine($"\nFoundations progress: {_foundations.GetCompletedCount()}/{_foundations.GetTotalCount()} topics");
        _foundations.ListTopics();

        string? next = _foundations.GetNextTopic();
        if (next == null)
        {
            Console.WriteLine("You've completed all the foundational topics. Well done!");
            return;
        }

        Console.WriteLine($"\nNext topic: {next}");
        Console.Write("Mark this topic as studied? (y/n): ");
        string? response = Console.ReadLine();
        if (response != null && response.Trim().ToLower() == "y")
        {
            int topicNumber = int.Parse(next.Split('.')[0]);
            _foundations.MarkTopicComplete(topicNumber);
            Console.WriteLine("Topic marked complete!");
        }
    }

    public void LearnMoreMenu()
    {
        Console.WriteLine("\n--- Learn More: Further Study Resources ---");
        Console.WriteLine("Writings and reading library: https://m.egwwritings.org/");
        Console.WriteLine("Bible study tools: https://www.biblegateway.com/");
        Console.WriteLine("Health and wellness principles: https://www.adventist.org/health/");
        Console.WriteLine("(These are optional resources for anyone who wants to explore further.)");
    }

    public string GetTier()
    {
        if (_score >= 5000)
        {
            return "Transformation";
        }
        else if (_score >= 1000)
        {
            return "Growth";
        }
        else
        {
            return "Awakening";
        }
    }

    public void SaveGoals()
    {
        Console.Write("File name to save to: ");
        string filename = Console.ReadLine() ?? "goals.txt";

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            outputFile.WriteLine(_dailyStreakGoal.GetStringRepresentation());
            outputFile.WriteLine(_foundations.GetStringRepresentation());

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved!");
    }

    public void LoadGoals()
    {
        Console.Write("File name to load from: ");
        string filename = Console.ReadLine() ?? "goals.txt";

        if (!File.Exists(filename))
        {
            Console.WriteLine("That file does not exist.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        _goals.Clear();

        _score = int.Parse(lines[0]);
        _dailyStreakGoal = (ChecklistGoal)CreateGoalFromLine(lines[1]);
        _foundations = FoundationsTracker.CreateFromString(SplitSavedLine(lines[2]));

        for (int i = 3; i < lines.Length; i++)
        {
            _goals.Add(CreateGoalFromLine(lines[i]));
        }

        Console.WriteLine("Goals loaded!");
    }

    // Splits a saved line like "FoundationsTracker:True,true;false;..."
    // into ["FoundationsTracker", "True", "true;false;..."]
    private string[] SplitSavedLine(string line)
    {
        string[] topLevel = line.Split(':');
        string type = topLevel[0];
        string[] rest = topLevel[1].Split(new[] { ',' }, 2);

        if (rest.Length == 1)
        {
            return new[] { type, rest[0] };
        }
        return new[] { type, rest[0], rest[1] };
    }

    private Goal CreateGoalFromLine(string line)
    {
        string[] topLevel = line.Split(':');
        string type = topLevel[0];
        string[] details = topLevel[1].Split(',');

        // Rebuild a single array like [ "SimpleGoal", name, description, points, ... ]
        string[] parts = new string[details.Length + 1];
        parts[0] = type;
        Array.Copy(details, 0, parts, 1, details.Length);

        return type switch
        {
            "SimpleGoal" => SimpleGoal.CreateFromString(parts),
            "EternalGoal" => EternalGoal.CreateFromString(parts),
            "ChecklistGoal" => ChecklistGoal.CreateFromString(parts),
            _ => throw new InvalidDataException($"Unknown goal type: {type}")
        };
    }

    private void SeedDefaultGoals()
    {
        // Daily habits (recur every day, no end state).
        _goals.Add(new EternalGoal("Exercise", "15-20 minutes of physical activity", 50));
        _goals.Add(new EternalGoal("Sunshine", "30 minutes outdoors in natural light", 40));
        _goals.Add(new EternalGoal("Morning Study", "30 minutes of focused personal study", 50));
        _goals.Add(new EternalGoal("Evening Study", "30 minutes of focused personal study", 50));
        _goals.Add(new EternalGoal("Quiet Reflection", "5-10 minutes of music or reflection before study", 20));
        _goals.Add(new EternalGoal("Hydration", "Drink adequate water throughout the day", 20));
        _goals.Add(new EternalGoal("Rest", "Get adequate, restorative sleep", 30));
        _goals.Add(new EternalGoal("Temperance", "Practice moderation and avoid harmful habits", 30));

        // Weekly goals, twice a week, with a small bonus for hitting the target.
        _goals.Add(new ChecklistGoal("Prophecy Study", "Study of prophecy topics, twice weekly", 60, 2, 100));
        _goals.Add(new ChecklistGoal("Wellness Study", "Study of health and wellness principles, twice weekly", 60, 2, 100));
        _goals.Add(new ChecklistGoal("Family Life Study", "Study of family life topics, twice weekly", 60, 2, 100));
    }

    private int ReadInt()
    {
        int value;
        while (!int.TryParse(Console.ReadLine(), out value))
        {
            Console.Write("Please enter a valid number: ");
        }
        return value;
    }
}
