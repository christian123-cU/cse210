using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<string> words = new List<string> { "The", "Lord", "is", "my", "shepherd" };
        Scripture scripture = new Scripture(words, "Psalm 23:1");

        scripture.Display();

        Hider hider = new Hider();
        hider.HideWords(scripture.words, 2);

        scripture.Display();
    }
}