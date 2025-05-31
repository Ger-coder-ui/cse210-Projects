using System;

public class JournalEntry
{
    public string Date { get; }
    public string Prompt { get; }
    public string Response { get; }

    public JournalEntry(string date, string prompt, string response)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\n");
    }
}
