using System;

class Program
{
    static void Main(string[] args)
    {
        // BEFORE: only f1, f2, f3 were tested, and decimal values for
        // f1/f2 were never printed, and setters were never demonstrated.
        // FIX: added f4 (1/3) to cover all sample fractions from the
        // instructions (1, 5, 3/4, 1/3), and print both representations
        // for every fraction.
        Fraction f1 = new Fraction();
        Fraction f2 = new Fraction(5);
        Fraction f3 = new Fraction(3, 4);
        Fraction f4 = new Fraction(1, 3);

        Console.WriteLine(f1.GetFractionString());
        Console.WriteLine(f1.GetDecimalValue());

        Console.WriteLine(f2.GetFractionString());
        Console.WriteLine(f2.GetDecimalValue());

        Console.WriteLine(f3.GetFractionString());
        Console.WriteLine(f3.GetDecimalValue());

        Console.WriteLine(f4.GetFractionString());
        Console.WriteLine(f4.GetDecimalValue());

        // NEW: demonstrates getters and setters, as required by the
        // rubric.
        f1.SetTop(7);
        f1.SetBottom(8);
        Console.WriteLine(f1.GetFractionString());
        Console.WriteLine(f1.GetDecimalValue());
    }
}