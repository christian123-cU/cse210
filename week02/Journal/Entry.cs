// Entry.cs
// Represents a single journal entry containing a date, prompt, and the user's response.

public class Entry
{
    // Member variables using _underscoreCamelCase convention
    private string _date;
    private string _promptText;
    private string _entryText;
    private string _mood; // Exceeds requirements: tracks user mood per entry

    // Constructor
    public Entry(string date, string promptText, string entryText, string mood = "")
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;
        _mood = mood;
    }

    // Getters — Entry owns its own data; Journal or Program never touches internals directly
    public string GetDate() => _date;
    public string GetPromptText() => _promptText;
    public string GetEntryText() => _entryText;
    public string GetMood() => _mood;

    // Display: Entry is responsible for knowing how to display itself (abstraction)
    public void Display()
    {
        Console.WriteLine($"┌─────────────────────────────────────────────────────┐");
        Console.WriteLine($"  Date   : {_date}");
        if (!string.IsNullOrEmpty(_mood))
            Console.WriteLine($"  Mood   : {_mood}");
        Console.WriteLine($"  Prompt : {_promptText}");
        Console.WriteLine($"  Entry  : {_entryText}");
        Console.WriteLine($"└─────────────────────────────────────────────────────┘");
    }

    // Serialize entry to a pipe-delimited string for file storage
    // Format: date|mood|prompt|entry  (pipes inside content are escaped as \p)
    public string ToFileString()
    {
        string safeDate   = _date.Replace("|", "\\p");
        string safeMood   = _mood.Replace("|", "\\p");
        string safePrompt = _promptText.Replace("|", "\\p");
        string safeEntry  = _entryText.Replace("|", "\\p");
        return $"{safeDate}|{safeMood}|{safePrompt}|{safeEntry}";
    }

    // Factory method: re-create an Entry from a serialized file line
    public static Entry FromFileString(string line)
    {
        string[] parts = line.Split('|');
        if (parts.Length < 4)
            return null;

        string date   = parts[0].Replace("\\p", "|");
        string mood   = parts[1].Replace("\\p", "|");
        string prompt = parts[2].Replace("\\p", "|");
        string entry  = parts[3].Replace("\\p", "|");
        return new Entry(date, prompt, entry, mood);
    }
}
