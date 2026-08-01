using System;

// ============================================================================
// Exceeding Requirements
// ============================================================================
// This program goes beyond the core requirements in the following ways:
//
// 1. No repeated prompts/questions until all have been used (Listing and
//    Reflecting activities): Activity.GetRandomItem() draws from a shrinking
//    "remaining items" pool instead of picking with replacement every time.
//    Once every prompt/question in a list has been shown, the pool refills
//    and the cycle starts over. Because the Breathing/Reflecting/Listing
//    instances below are created once and reused for the life of the
//    program, this guarantees variety both within a single activity session
//    and across repeated visits to the same activity in one run.
//
// 2. Session log, saved to and loaded from a file: ActivityLog.cs records
//    how many times each activity has been run and the total seconds spent
//    on it. The log loads at startup (if activity_log.txt exists from a
//    previous run) and saves after every completed activity, and can be
//    viewed at any time from the "View Activity Log" menu option.
//
// 3. A more meaningful breathing animation: instead of a plain numeric
//    countdown, BreathingActivity grows (or shrinks) a bar of asterisks with
//    pauses that lengthen each step, so the animation moves quickly at first
//    and eases off near the end of the breath - closer to how an actual
//    inhale/exhale doesn't move at a constant speed. A "Hold..." phase was
//    also added between breathing in and out, so a 12-second session (for
//    example) is spent as 4 seconds in, 4 seconds held, and 4 seconds out.
// ============================================================================

class Program
{
    static void Main(string[] args)
    {
        ActivityLog log = new ActivityLog();
        log.Load();

        // Created once and reused for the life of the program (rather than a
        // new instance per menu selection) so each activity's "remaining
        // items" pool - see Activity.GetRandomItem() - carries over between
        // visits instead of resetting every time.
        BreathingActivity breathing = new BreathingActivity();
        ReflectingActivity reflecting = new ReflectingActivity();
        ListingActivity listing = new ListingActivity();

        bool quit = false;
        while (!quit)
        {
            int choice = GetMenuChoice();

            switch (choice)
            {
                case 1:
                    breathing.Run();
                    log.RecordRun(breathing.GetName(), breathing.GetDuration());
                    log.Save();
                    break;

                case 2:
                    reflecting.Run();
                    log.RecordRun(reflecting.GetName(), reflecting.GetDuration());
                    log.Save();
                    break;

                case 3:
                    listing.Run();
                    log.RecordRun(listing.GetName(), listing.GetDuration());
                    log.Save();
                    break;

                case 4:
                    log.Display();
                    break;

                case 5:
                    quit = true;
                    break;
            }
        }
    }

    // Repeats the menu prompt until the user enters a valid option, instead
    // of letting int.Parse crash the program on bad input.
    static int GetMenuChoice()
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Breathing Activity");
            Console.WriteLine("  2. Reflecting Activity");
            Console.WriteLine("  3. Listing Activity");
            Console.WriteLine("  4. View Activity Log");
            Console.WriteLine("  5. Quit");
            Console.Write("Select a choice from the menu: ");

            if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= 5)
            {
                return choice;
            }

            Console.WriteLine("Please enter a number between 1 and 5.");
        }
    }
}
