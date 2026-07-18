public class Scripture
{
    public string reference;
    public List<string> words;

    public Scripture(List<string> words, string reference)
    {
        this.words = words;
        this.reference = reference;
    }

    public void Display()
    {
        Console.WriteLine(reference);
        Console.WriteLine(string.Join(" ", words));
    }
}