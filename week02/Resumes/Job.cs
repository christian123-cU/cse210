// A code template for the category of things known as Job. The
// responsibility of a Job is to hold and display job history information.
public class Job
{
    public string _company = "";
    public string _jobTitle = "";
    public int _startYear;
    public int _endYear;
    public bool _isCurrent = false;

    // Displays the job information in the format:
    // "Job Title (Company) StartYear-EndYear"
    // or, if the job is still ongoing:
    // "Job Title (Company) StartYear-Present"
    public void Display()
    {
        string endLabel = _isCurrent ? "Present" : _endYear.ToString();
        System.Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{endLabel}");
    }
}
