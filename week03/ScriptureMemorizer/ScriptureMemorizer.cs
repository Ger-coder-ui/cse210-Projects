public class ScriptureMemorizer
{
    private ScriptureText _scriptureText;

    public ScriptureMemorizer(ScriptureReference reference, string text)
    {
        _scriptureText = new ScriptureText(reference, text);
    }

    public void Start()
    {
        _scriptureText.Display();

        while (true)
        {
            Console.WriteLine("Press Enter to hide words, or type 'quit' to exit.");
            var input = Console.ReadLine();

            if (input?.ToLower() == "quit")
                break;

            if (!_scriptureText.HideRandomWords(3))
                break;

            _scriptureText.Display();
        }

        Console.WriteLine("Final scripture:");
        _scriptureText.Display();
    }
}
