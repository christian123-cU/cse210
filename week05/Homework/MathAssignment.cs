using System;

public class MathAssignment : Assignment
{
    // _studentName and _topic are NOT redeclared here - they already live in
    // the Assignment base class and are set via base(...) below. Round 1
    // redeclared them locally, which created two independent copies of the
    // same data (one in Assignment, one in MathAssignment). That's wasted
    // memory at best, and a bug at worst if the two copies ever diverge.
    private string _textbookSection;
    private string _problems;

    public MathAssignment(string studentName, string topic, string textbookSection, string problems)
        : base(studentName, topic)
    {
        _textbookSection = textbookSection;
        _problems = problems;
    }

    public string GetHomeworkList()
    {
        return $"Section {_textbookSection} Problems {_problems}";
    }
}
