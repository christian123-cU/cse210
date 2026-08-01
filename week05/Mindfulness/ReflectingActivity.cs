using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    protected List<string> _prompts;
    protected List<string> _questions;

    public ReflectingActivity()
    {
        _name = "Reflecting";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";

        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
    }

    public void Run()
    {
        DisplayStartingMessage();

        DisplayPrompt();
        DisplayQuestions();

        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        return _prompts[random.Next(_prompts.Count)];
    }

    public string GetRandomQuestion()
    {
        Random random = new Random();
        return _questions[random.Next(_questions.Count)];
    }

    public void DisplayPrompt()
    {
        Console.WriteLine();
        Console.WriteLine(GetRandomPrompt());

        string[] animationChars = { "|", "/", "-", "\\" };
        int i = 0;
        for (int c = 0; c < 12; c++)
        {
            Console.Write(animationChars[i]);
            Thread.Sleep(250);
            Console.Write("\b \b");
            i++;
            if (i >= animationChars.Length)
            {
                i = 0;
            }
        }
    }

    public void DisplayQuestions()
    {
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.WriteLine();
            Console.WriteLine(GetRandomQuestion());

            string[] animationChars = { "|", "/", "-", "\\" };
            int i = 0;
            for (int c = 0; c < 12; c++)
            {
                Console.Write(animationChars[i]);
                Thread.Sleep(250);
                Console.Write("\b \b");
                i++;
                if (i >= animationChars.Length)
                {
                    i = 0;
                }
            }
        }
    }
}
