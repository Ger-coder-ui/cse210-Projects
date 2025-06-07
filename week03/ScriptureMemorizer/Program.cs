using System;

class Program
{
    static void Main()
    {
        var reference = new ScriptureReference("John", 3, 16);
        var text = "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.";

        var memorizer = new ScriptureMemorizer(reference, text);
        memorizer.Start();
    }
}
