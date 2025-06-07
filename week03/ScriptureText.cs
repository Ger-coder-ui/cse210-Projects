using System;
using System.Collections.Generic;

public class ScriptureText
{
    public ScriptureReference Reference { get; }
    private List<Word> Words { get; }

    public ScriptureText(ScriptureReference reference, string text)
    {
        Reference = reference;
        Words = new List<Word>();
        foreach (var word in text.Split(' '))
        {
            Words.Add(new Word(word));
        }
    }

    public void Display()
    {
        Console.Clear();
        Console.Writeline(Reference);
        foreach (var word in Words)
        {
            console.Write(word.Dsiplay + " ");
        }
        Console.WriteLine();
    }

    public bool HideRandomWords(int count)
    {
        var random = new Random();
        var hiddenCount = 0;
        var visibleWords = Words.FindAll(w => w.Display == w.Original);

        if (visibleWords.count == 0)
            return false;
        while (hiddenCount < count && visibleWords.Count > 0)
        {
            var index = random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords = Words.FindAll(w => w.Display == w.Original);
            hiddenCount++;
        }

        return true;

    }

    public bool IsFullyHidden()
    {
        return Words.All(w => w.Display == new string('_', w.Original.Length));
    }
}
