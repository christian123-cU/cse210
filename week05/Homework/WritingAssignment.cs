using System;

public class WritingAssignment : Assignment
{
    private string _title;

    public WritingAssignment(string studentName, string topic, string title)
        : base(studentName, topic)
    {
        _title = title;
    }

    public string GetWritingInformation()
    {
        // _studentName is private in Assignment, so referencing it directly here
        // failed to compile in round 1 (CS0122: "inaccessible due to its
        // protection level"). GetStudentName() is the base class's public
        // accessor, so we go through that instead of reaching into the field.
        return $"{_title} by {GetStudentName()}";
    }
}
