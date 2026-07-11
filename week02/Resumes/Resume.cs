using System.Collections.Generic;

// A code template for the category of things known as Resume. The
// responsibility of a Resume is to hold a person's name and job history,
// and to display that information.
public class Resume
{
    public string _name = "";
    public List<Job> _jobs = new List<Job>();

    // Displays the resume: the person's name first, followed by
    // each job in the list of jobs.
    public void Display()
    {
        System.Console.WriteLine($"Name: {_name}");
        System.Console.WriteLine("Jobs:");

        foreach (Job job in _jobs)
        {
            job.Display();
        }
    }
}
