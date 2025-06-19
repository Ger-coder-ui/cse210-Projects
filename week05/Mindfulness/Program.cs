using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

abstract class Activity
{
    private string _name;
    private string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    protected void ShowStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"--- {_name} ---");
        Console.WriteLine(_description);
        Console.Write("Enter duration in seconds: ");
        _duration = int.Parse(Console.ReadLine() ?? "30");
        Console.WriteLine("Prepare to begin...");
        Spinner(3);
    }

    protected void ShowEndingMessage()
    {
        Console.WriteLine("\nWell done!");
        Spinner(2);
        Console.WriteLine($"You have completed {_name} for {_duration} seconds.");
        Spinner(2);
    }

    protected void Spinner(int seconds)
    {
        string[] symbols = { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int i = 0;
        while (DateTime.Now < endTime)
        {
            Console.Write(symbols[i % symbols.Length]);
            Thread.Sleep(200);
            Console.Write("\b");
            i++;
        }
    }

    protected void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i}...\r");
            Thread.Sleep(1000);
        }
        Console.WriteLine("Go!   ");
    }

    public abstract void Run();
}

class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity",
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    { }

    public override void Run()
    {
        ShowStartingMessage();
        int elapsed = 0;
        while (elapsed < _duration)
        {
            Console.WriteLine("Breathe in...");
            Countdown(4);
            elapsed += 4;
            if (elapsed >= _duration) break;

            Console.WriteLine("Breathe out...");
            Countdown(4);
            elapsed += 4;
        }
        ShowEndingMessage();
    }
}

class ReflectionActivity : Activity
{
    private List<string> _prompts = new()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience?",
        "What did you learn about yourself?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity() : base("Reflection Activity",
        "This activity will help you reflect on times when you showed strength and resilience.")
    { }

    public override void Run()
    {
        ShowStartingMessage();
        Random rand = new();
        Console.WriteLine(_prompts[rand.Next(_prompts.Count)]);
        int elapsed = 0;
        while (elapsed < _duration)
        {
            string question = _questions[rand.Next(_questions.Count)];
            Console.WriteLine($"\n{question}");
            Spinner(5);
            elapsed += 5;
        }
        ShowEndingMessage();
    }
}

class ListingActivity : Activity
{
    private List<string> _prompts = new()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing Activity",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can.")
    { }

    public override void Run()
    {
        ShowStartingMessage();
        Random rand = new();
        Console.WriteLine(_prompts[rand.Next(_prompts.Count)]);
        Countdown(5);
        Console.WriteLine("Start listing items (press Enter after each one):");

        DateTime startTime = DateTime.Now;
        List<string> items = new();

        while ((DateTime.Now - startTime).TotalSeconds < _duration)
        {
            if (Console.KeyAvailable)
            {
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                    items.Add(input);
            }
        }

        Console.WriteLine($"\nYou listed {items.Count} items.");
        ShowEndingMessage();
    }
}

class Program
{
    static void Main()
    {
        Dictionary<int, Activity> activities = new()
        {
            { 1, new BreathingActivity() },
            { 2, new ReflectionActivity() },
            { 3, new ListingActivity() }
        };

        while (true)
        {
            Console.WriteLine("\nMindfulness App Menu");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");

            string input = Console.ReadLine();
            if (input == "4") break;

            if (int.TryParse(input, out int choice) && activities.ContainsKey(choice))
            {
                activities[choice].Run();
            }
            else
            {
                Console.WriteLine("Invalid option. Try again.");
            }
        }

        Console.WriteLine("Thank you for using the Mindfulness App. Goodbye!");
    }
}
