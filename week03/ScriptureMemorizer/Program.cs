using System;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("Psalm", 23, 1);
        Scripture scripture = new Scripture(reference, "The Lord is my shepherd");
    }
}