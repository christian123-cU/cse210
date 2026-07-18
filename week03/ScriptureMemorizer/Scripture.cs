using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
    }

    public string GetDisplayText()
    {
        return "";
    }

    public void HideRandomWords(int numberToHide)
    {
    }

    public bool AllWordsHidden()
    {
        return false;
    }
}