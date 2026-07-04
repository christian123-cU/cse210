using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();

        string name = PromptUserName();
        int number = PromptUserNumber();
        int squared = SquareNumber(number);

        DisplayResult(name, squared);
    }

    // Displays a welcome message
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    // Asks for and returns the user's name
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }

    // Asks for and returns the user's favorite number
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int number = Convert.ToInt32(Console.ReadLine());
        return number;
    }

    // Accepts an integer and returns that number squared
    static int SquareNumber(int number)
    {
        return number * number;
    }

    // Accepts the user's name and squared number, and displays them
    static void DisplayResult(string name, int squaredNumber)
    {
        Console.WriteLine(name + ", the square of your number is " + squaredNumber);
    }
}