using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        string playAgain = "yes";

        // Keep playing the whole game as long as the user says "yes"
        while (playAgain.ToLower() == "yes")
        {
            // Generate a random magic number from 1 to 100
            int magicNumber = random.Next(1, 101);
            int guessCount = 0;

            // Ask the user for their first guess
            Console.Write("What is your guess? ");
            int guess = Convert.ToInt32(Console.ReadLine());
            guessCount++;

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
                guessCount++;
            }

            // Once the loop ends, the guess must match the magic number
            Console.WriteLine("You guessed it!");
            Console.WriteLine("It took you " + guessCount + " guesses.");

            // Ask if the user wants to play again
            Console.Write("Do you want to play again? ");
            playAgain = Console.ReadLine();
        }

        Console.WriteLine("Thanks for playing!");
    }
}