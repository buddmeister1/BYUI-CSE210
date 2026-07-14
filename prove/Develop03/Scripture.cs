using System;
using System.Collections.Generic;

namespace Develop03
{
    public class Scripture
    {
        private Reference _reference;
        private List<Word> _words;
        private Random _random;

        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            _words = new List<Word>();
            _random = new Random();

            string[] splitWords = text.Split(' ');
            foreach (string wordText in splitWords)
            {
                Word newWord = new Word(wordText);
                _words.Add(newWord);
            }
        }

        public string GetDisplayText()
        {
            string result = _reference.GetDisplayText() + Environment.NewLine + Environment.NewLine;

            foreach (Word word in _words)
            {
                result += word.GetDisplayText() + " ";
            }

            return result;
        }

        public void HideRandomWords(int numberToHide)
        {
            List<Word> hiddenCandidates = new List<Word>();

            foreach (Word word in _words)
            {
                if (!word.IsHidden())
                {
                    hiddenCandidates.Add(word);
                }
            }

            int numberAvailable = hiddenCandidates.Count;
            int actualNumberToHide = numberToHide;
            if (actualNumberToHide > numberAvailable)
            {
                actualNumberToHide = numberAvailable;
            }

            for (int i = 0; i < actualNumberToHide; i++)
            {
                int randomIndex = _random.Next(hiddenCandidates.Count);
                Word wordToHide = hiddenCandidates[randomIndex];
                wordToHide.Hide();
                hiddenCandidates.RemoveAt(randomIndex);
            }
        }

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
}