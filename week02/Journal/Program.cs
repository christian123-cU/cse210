// Program.cs
// W02 Project: Journal Program
// Author: David Oduor Ochanda
// Course: CSE 210 — Programming with Classes
//
// ── What this program does ───────────────────────────────────────────────────
// A journaling app that gives the user a random prompt each day, records their
// response with the date and an optional mood tag, and persists everything to
// a plain-text file.
//
// ── How requirements are exceeded (score ≥ 100%) ────────────────────────────
// 1. MOOD TRACKING: Each entry optionally records the user's mood (e.g. happy,
//    tired, anxious). This is stored alongside the entry in the file and shown
//    on display, addressing the barrier of "not knowing what to write" by also
//    capturing emotional context.
//
// 2. NO-REPEAT PROMPTS: PromptGenerator remembers the last prompt index and
//    never shows the same prompt twice in a row, improving the writing
//    experience.
//
// 3. WORD-COUNT STATS: Menu option 5 shows a statistics summary: total entries,
//    total words written, average words per entry, and the date of the longest
//    entry. This gives users motivating feedback on their journaling progress.
//
// 4. EXPANDED PROMPT LIBRARY: The PromptGenerator has 15 prompts (10 extra
//    beyond the required 5), covering gratitude, personal growth, relationships,
//    health, and spirituality.
//
// 5. SAFE SERIALIZATION: The pipe '|' separator is escaped in content so that
//    any user text (including pipes) is saved and loaded correctly.
// ─────────────────────────────────────────────────────────────────────────────

using System;

class Program
{
    static void Main(string[] args)
    {
        Journal          journal   = new Journal();
        PromptGenerator  generator = new PromptGenerator();

        Console.WriteLine("╔═══════════════════════════════════════╗");
        Console.WriteLine("║       Welcome to Your Journal  📔      ║");
        Console.WriteLine("╚═══════════════════════════════════════╝");

        bool running = true;
        while (running)
        {
            DisplayMenu();
            string choice = Console.ReadLine()?.Trim();

            switch (choice)
            {
                case "1":
                    WriteNewEntry(journal, generator);
                    break;
                case "2":
                    journal.DisplayAll();
                    break;
                case "3":
                    SaveJournal(journal);
                    break;
                case "4":
                    LoadJournal(journal);
                    break;
                case "5":
                    journal.DisplayWordCountSummary();
                    break;
                case "6":
                    Console.WriteLine("\n  Goodbye! Keep writing — one prompt at a time. 👋\n");
                    running = false;
                    break;
                default:
                    Console.WriteLine("  Please enter a number between 1 and 6.");
                    break;
            }
        }
    }

    // ── Menu ─────────────────────────────────────────────────────────────────

    static void DisplayMenu()
    {
        Console.WriteLine();
        Console.WriteLine("  ┌─── Menu ──────────────────────────────┐");
        Console.WriteLine("  │  1 - Write a new entry                │");
        Console.WriteLine("  │  2 - Display the journal              │");
        Console.WriteLine("  │  3 - Save journal to file             │");
        Console.WriteLine("  │  4 - Load journal from file           │");
        Console.WriteLine("  │  5 - View writing stats               │");
        Console.WriteLine("  │  6 - Quit                             │");
        Console.WriteLine("  └───────────────────────────────────────┘");
        Console.Write("  What would you like to do? ");
    }

    // ── Feature 1: Write a new entry ─────────────────────────────────────────

    static void WriteNewEntry(Journal journal, PromptGenerator generator)
    {
        string date   = DateTime.Now.ToShortDateString();
        string prompt = generator.GetRandomPrompt();

        Console.WriteLine($"\n  📅 {date}");
        Console.WriteLine($"  ✏  Prompt: {prompt}");
        Console.Write("  Your response: ");
        string response = Console.ReadLine() ?? "";

        // Exceeds requirements: capture optional mood
        Console.Write("  How are you feeling right now? (press Enter to skip): ");
        string mood = Console.ReadLine()?.Trim() ?? "";

        Entry newEntry = new Entry(date, prompt, response, mood);
        journal.AddEntry(newEntry);

        Console.WriteLine("  ✔ Entry saved!");
    }

    // ── Feature 3: Save ──────────────────────────────────────────────────────

    static void SaveJournal(Journal journal)
    {
        Console.Write("  Enter filename to save (e.g. journal.txt): ");
        string filename = Console.ReadLine()?.Trim() ?? "journal.txt";

        if (string.IsNullOrEmpty(filename))
            filename = "journal.txt";

        journal.SaveToFile(filename);
    }

    // ── Feature 4: Load ──────────────────────────────────────────────────────

    static void LoadJournal(Journal journal)
    {
        Console.Write("  Enter filename to load (e.g. journal.txt): ");
        string filename = Console.ReadLine()?.Trim() ?? "journal.txt";

        if (string.IsNullOrEmpty(filename))
            filename = "journal.txt";

        journal.LoadFromFile(filename);
    }
}
