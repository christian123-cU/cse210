public class Reference
{
    // added _endVerse,so that verse ranges like
    // "Proverbs 3:5-6" can be represented.
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

    // Constructor 1: single verse (e.g., "John 3:16").
    // _endVerse is set equal to _verse so GetDisplayText's logic below
    // works the same whether it's a single verse or a range.
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = verse;
    }

    public Reference(string book, int chapter, int verse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = endVerse;
    }

    //Formats the reference itself, so Scripture knows book/chapter/verse formatting rules 
    public string GetDisplayText()
    {
        if (_verse == _endVerse)
        {
            return $"{_book} {_chapter}:{_verse}";
        }
        return $"{_book} {_chapter}:{_verse}-{_endVerse}";
    }
}