using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        foreach (string word in text.Split(' '))
        {
            _words.Add(new Word(word));
        }
    }

    public string GetDisplayText()
    {
        List<string> displayWords = new List<string>();
        foreach (Word word in _words)
        {
            displayWords.Add(word.GetDisplayText());
        }
        return _reference.GetDisplayText() + Environment.NewLine + string.Join(" ", displayWords);
    }

    // Only hides words that are NOT already hidden, using
    // Word.IsHidden(). The earlier version could hide the same word over
    // and over, meaning some words might never get chosen and the
    // scripture might never reach a "fully hidden" state in reasonable
    // time. (This is the stretch-challenge behavior, but it's needed for
    // the core "end when all hidden" requirement to work reliably too.)
    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        int hiddenCount = 0;

        while (hiddenCount < numberToHide && !IsCompletelyHidden())
        {
            int index = random.Next(_words.Count);
            Word word = _words[index];

            if (!word.IsHidden())
            {
                word.Hide();
                hiddenCount++;
            }
        }
    }

    // Was completely missing before. Needed so Program.cs can detect
    // the "all words hidden" ending condition from the spec.
    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}