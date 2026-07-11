// PromptGenerator.cs
// Abstracts all prompt-related logic. Could later load from a file, web API, or database
// without the rest of the program needing to change — that is the value of this class.

public class PromptGenerator
{
    // Private list — callers only use GetRandomPrompt(); they never touch _prompts directly
    private List<string> _prompts;
    private Random _random;
    private int _lastIndex; // Exceeds requirements: avoids giving the same prompt twice in a row

    public PromptGenerator()
    {
        _random    = new Random();
        _lastIndex = -1;

        _prompts = new List<string>
        {
            // Required prompts
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",

            // Additional prompts (exceeds requirements)
            "What is one thing I learned today that I did not know yesterday?",
            "What small act of kindness did I give or receive today?",
            "What challenged me today, and how did I respond?",
            "What am I most grateful for at this moment?",
            "What is one goal I made progress on today?",
            "Describe a moment today when I felt truly present and at peace.",
            "What conversation had the biggest impact on me today, and why?",
            "What would I tell my future self about today?",
            "What book, idea, or piece of content inspired me recently?",
            "How did I take care of my physical or mental health today?"
        };
    }

    // Return a random prompt, guaranteed not to repeat the previous one
    public string GetRandomPrompt()
    {
        if (_prompts.Count == 1)
            return _prompts[0];

        int index;
        do
        {
            index = _random.Next(_prompts.Count);
        }
        while (index == _lastIndex);

        _lastIndex = index;
        return _prompts[index];
    }

    // Exceeds requirements: let callers see how many prompts are available
    public int GetPromptCount() => _prompts.Count;
}
