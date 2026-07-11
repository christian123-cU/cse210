// Journal.cs
// Manages the complete collection of journal entries.
// Responsibilities: adding entries, displaying all entries, saving to file, loading from file.

using System.IO;

public class Journal
{
    // Member variable: private list — outside code uses AddEntry(), not _entries directly
    private List<Entry> _entries;

    public Journal()
    {
        _entries = new List<Entry>();
    }

    // Add a new entry to the journal
    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    // Display all entries by delegating display to each Entry (abstraction)
    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("  (No entries yet — start writing!)");
            return;
        }

        Console.WriteLine($"\n  ══════════════ Journal ({_entries.Count} entries) ══════════════\n");
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    // Save the entire journal to a pipe-delimited text file
    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            // Write a header line so the file is self-describing
            outputFile.WriteLine("#YouthRise Journal v1.0");
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine(entry.ToFileString());
            }
        }
        Console.WriteLine($"  ✔ Journal saved to '{file}' ({_entries.Count} entries).");
    }

    // Load the journal from a pipe-delimited text file (replaces current entries)
    public void LoadFromFile(string file)
    {
        if (!File.Exists(file))
        {
            Console.WriteLine($"  ✘ File '{file}' not found.");
            return;
        }

        _entries.Clear();
        string[] lines = File.ReadAllLines(file);
        int loaded = 0;

        foreach (string line in lines)
        {
            // Skip blank lines and the header comment
            if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
                continue;

            Entry entry = Entry.FromFileString(line);
            if (entry != null)
            {
                _entries.Add(entry);
                loaded++;
            }
        }
        Console.WriteLine($"  ✔ Loaded {loaded} entries from '{file}'.");
    }

    // Exceeds requirements: report a word-count summary across all entries
    public void DisplayWordCountSummary()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("  No entries to summarise.");
            return;
        }

        int totalWords = 0;
        int longestEntry = 0;
        string longestDate = "";

        foreach (Entry entry in _entries)
        {
            int words = entry.GetEntryText().Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
            totalWords += words;
            if (words > longestEntry)
            {
                longestEntry = words;
                longestDate  = entry.GetDate();
            }
        }

        double average = (double)totalWords / _entries.Count;
        Console.WriteLine($"\n  ── Journal Stats ──────────────────────────────────");
        Console.WriteLine($"  Total entries     : {_entries.Count}");
        Console.WriteLine($"  Total words       : {totalWords}");
        Console.WriteLine($"  Average per entry : {average:F1} words");
        Console.WriteLine($"  Longest entry     : {longestEntry} words (written on {longestDate})");
        Console.WriteLine($"  ───────────────────────────────────────────────────\n");
    }
}
