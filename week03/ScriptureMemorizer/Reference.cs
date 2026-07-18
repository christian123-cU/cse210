public class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

    // Constructor 1: single verse (e.g. "John 3:16")
    // _endVerse is explicitly set equal to _verse. In the earlier
    // version, _endVerse was left at its default (0) here, so ranges never
    // worked correctly in GetDisplayText.
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = verse;
    }

    // Constructor 2 (overload): verse range (e.g. "Proverbs 3:5-6")
    public Reference(string book, int chapter, int verse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = endVerse;
    }

    // now checks whether this is a range or single verse and formats
    // accordingly, so "Proverbs 3:5-6" actually displays correctly.
    public string GetDisplayText()
    {
        if (_verse == _endVerse)
        {
            return $"{_book} {_chapter}:{_verse}";
        }
        return $"{_book} {_chapter}:{_verse}-{_endVerse}";
    }
}