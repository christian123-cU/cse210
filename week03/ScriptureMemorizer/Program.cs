using System;

class Program
{
    static void Main(string[] args)
    {
      
        // Build a real Reference object, and pass the raw verse text
        // as a string — Scripture handles splitting it internally now.
        Reference reference = new Reference("Psalm", 23, 1);
        Scripture scripture = new Scripture(reference, "The Lord is my shepherd");

        // No Hider — call scripture.HideRandomWords() directly, and
        // use GetDisplayText() + Console.WriteLine() ourselves.
        Console.WriteLine(scripture.GetDisplayText());

        while (!scripture.AllWordsHidden())
        {
            Console.WriteLine();
            Console.WriteLine("Press Enter to hide more words, or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);
            Console.WriteLine(scripture.GetDisplayText());
        }
    }
}