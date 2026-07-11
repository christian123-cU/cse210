using System;

class Program
{
    static void Main(string[] args)
    {
        // Job 1: Youth Service Librarian and Community Leader (completed role)
        Job job1 = new Job();
        job1._jobTitle = "Youth Service Librarian and Community Leader";
        job1._company = "Mashimoni School of Hope, Mathare";
        job1._startYear = 2015;
        job1._endYear = 2020;
        job1._isCurrent = false;

        // Job 2: Program Manager - Education & Community Impact (ongoing role)
        Job job2 = new Job();
        job2._jobTitle = "Program Manager - Education & Community Impact";
        job2._company = "Smiley Charity Organization";
        job2._startYear = 2021;
        job2._isCurrent = true; // still employed here, so _endYear is not used

        // Job 3: Program Officer (ongoing role)
        Job job3 = new Job();
        job3._jobTitle = "Program Officer";
        job3._company = "ChallengeAid Africa";
        job3._startYear = 2024;
        job3._isCurrent = true; // still employed here, so _endYear is not used

        // Build the resume and add each job
        Resume myResume = new Resume();
        myResume._name = "David Oduor Ochanda";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);
        myResume._jobs.Add(job3);

        // Display the full resume
        myResume.Display();
    }
}
