using System;

public class Assignment
{
    private string _studentName;
    private string _topic;

    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    // Exposes the student's name to derived classes (and anyone else) without
    // making the field itself protected or public. Keeping _studentName private
    // preserves encapsulation - WritingAssignment needs read access to it, and a
    // getter is the safer choice over widening the field's access level.
    public string GetStudentName()
    {
        return _studentName;
    }

    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }
}
