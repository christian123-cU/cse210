using System;
using System.Collections.Generic;

public class Scripture
{
    
    // Fixed:
    // 1. Changed reference from a raw string to an actual Reference object,
    //    and words from List<string> to List<Word>. Each word can
    //    NOW carry its own hidden/visible state, and the Reference can format
    //    itself.
    private Reference _reference;
    private List<Word> _words;

    // BEFORE: public Scripture(List<string> words, string reference)
    // This forced Program.cs to pre-split the text into a list itself,
    // exposing Scripture's internal storage format — a clear encapsulation
    // break. FIX: accept the raw verse text as a string, and a real
    // Reference object, then do the splitting internally.
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        foreach (string word in text.Split(' '))
        {
            _words.Add(new Word(word));
        }
    }

    // GetDisplayText() (returns the formatted string) so
    // Program.cs decides when/how to print it — Scripture doesn't need
    // to know about console output at all.
    public string GetDisplayText()
    {
        List<string> displayWords = new List<string>();
        foreach (Word word in _words)
        {
            displayWords.Add(word.GetDisplayText());
        }
        return _reference.GetDisplayText() + Environment.NewLine + string.Join(" ", displayWords);
    }

    // NEW: was entirely missing before (the old Hider.HideWords stub did
    // nothing). This replaces Hider completely — Scripture decides which
    // words to hide, and delegates the actual hiding to each Word.
    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        int hiddenCount = 0;

        while (hiddenCount < numberToHide && !AllWordsHidden())
        {
            int index = random.Next(_words.Count);
            Word word = _words[index];

            // Calls Word.IsHidden() to avoid "wasting" a hide on an
            // already-hidden word
            if (!word.IsHidden())
            {
                word.Hide();
                hiddenCount++;
            }
        }
    }

    // NEW: was entirely missing before. Lets Program.cs know when to stop
    // the loop (per the spec: "all words hidden" is one of the two ways
    // the program ends).
    public bool AllWordsHidden()
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