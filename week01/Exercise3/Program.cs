using System;

class Program
{
    static void Main(string[] args)
    {
        // Ask the user for the magic number
        Console.Write("What is the magic number? ");
        int magicNumber = Convert.ToInt32(Console.ReadLine());

        // Ask the user for their first guess
        Console.Write("What is your guess? ");
        int guess = Convert.ToInt32(Console.ReadLine());

        // Keep looping as long as the guess does not match the magic number
        while (guess != magicNumber)
        {
            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else
            {
                Console.WriteLine("Lower");
            }

            // Ask for another guess
            Console.Write("What is your guess? ");
            guess = Convert.ToInt32(Console.ReadLine());
        }

        // Once the loop ends, the guess must match the magic number
        Console.WriteLine("You guessed it!");
    }
}