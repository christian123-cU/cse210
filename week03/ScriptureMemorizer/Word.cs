public class Word
{
    // Private fields;encapsulation requirement from the spec.
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false; // visible by default when first created
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    // The number of underscores now matches the word's actual length,
    // instead of a hardcoded "____". Satisfies the spec requirement:
    // "the number of underscores should match the number of letters."
    public string GetDisplayText()
    {
        if (_isHidden)
        {
            return new string('_', _text.Length);
        }
        return _text;
    }
}