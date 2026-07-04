using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        // Ask the user for numbers and append each one to the list, stopping at 0
        Console.Write("Enter number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        while (number != 0)
        {
            numbers.Add(number);

            Console.Write("Enter number: ");
            number = Convert.ToInt32(Console.ReadLine());
        }

        // Compute the sum of the numbers in the list
        int sum = 0;
        foreach (int n in numbers)
        {
            sum += n;
        }

        // Compute the average of the numbers in the list
        double average = (double)sum / numbers.Count;

        // Find the maximum number in the list
        int max = numbers[0];
        foreach (int n in numbers)
        {
            if (n > max)
            {
                max = n;
            }
        }

        // Display the results
        Console.WriteLine("The sum is: " + sum);
        Console.WriteLine("The average is: " + average);
        Console.WriteLine("The largest number is: " + max);
    }
}