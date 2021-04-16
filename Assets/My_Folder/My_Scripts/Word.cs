using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Word
{
    public string word;

    private int wordIndex;

    WordDisplay wordDisplay;
    public Word(string _word, WordDisplay _display)
    {
        word = _word;
        wordIndex = 0;

        wordDisplay = _display;
        wordDisplay.SetWord(word);
    }

    public char GetNextLetter()
    {
        return word[wordIndex];
    }

    public void TypeLetter()
    {
        wordIndex++; // increase word index

        wordDisplay.RemoveLetter(); //remove the previous letter on screen

    }

    public bool WordTyped()
    {
        bool wordTyped = (wordIndex >= word.Length);

        if (wordTyped)
        {
            wordDisplay.RemoveWord(); //remove word out of the screen
            
        }
        return wordTyped;

    }
}
