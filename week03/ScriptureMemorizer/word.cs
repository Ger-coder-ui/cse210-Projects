public class Word
{
    public string Original { get; }
    public string Display { get; private set; }


    public Word(string original)
    {
        Original = original;
        Display = original;

    }

    public void Hide()
    {
        Display = new string('_', Original.Length);
    }

}