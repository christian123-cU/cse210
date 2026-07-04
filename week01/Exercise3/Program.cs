using System;

class Program
{
    static void Main(string[] args)
    {
        // Ask the user for the magic number
        Console.Write("What is the magic number? ");
        int magicNumber = Convert.ToInt32(Console.ReadLine());

        // Ask the user for their guess
        Console.Write("What is your guess? ");
        int guess = Convert.ToInt32(Console.ReadLine());

        // Determine if the guess is correct, too high, or too low
        if (guess < magicNumber)
        {
            Console.WriteLine("Higher");
        }
        else if (guess > magicNumber)
        {
            Console.WriteLine("Lower");
        }
        else
        {
            Console.WriteLine("You guessed it!");
        }
    }
}