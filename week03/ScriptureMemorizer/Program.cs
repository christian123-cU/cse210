using System;
using System.Collections.Generic;

// ===================================================================
// EXCEEDING REQUIREMENTS (for full marks):
// 1. Library of scriptures: instead of a single hardcoded scripture,
//    the program stores a small library of several scriptures and
//    picks one at random each time the program runs.
// 2. Stretch challenge implemented: HideRandomWords only selects from
//    words that are not already hidden (see Scripture.HideRandomWords),
//    so every word gets a chance to be hidden and the program reliably
//    reaches "fully hidden" instead of repeatedly re-hiding the same
//    word.
// ===================================================================
class Program
{
    static void Main(string[] args)
    {
        List<Scripture> library = new List<Scripture>
        {
            new Scripture(new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all your heart and lean not unto thine own understanding"),
            new Scripture(new Reference("John", 3, 16),
                "For God so loved the world that he gave his only begotten Son"),
            new Scripture(new Reference("Philippians", 4, 13),
                "I can do all things through Christ which strengtheneth me")
        };

        Random random = new Random();
        Scripture scripture = library[random.Next(library.Count)];

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());

        while (!scripture.IsCompletelyHidden())
        {
            Console.WriteLine();
            Console.WriteLine("Press enter to continue, or type 'quit' to finish.");
            string input = Console.ReadLine();

            if (input == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
        }
    }
}