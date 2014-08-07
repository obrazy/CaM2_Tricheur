using System;
using System.Collections.Generic;
using System.Linq;

namespace CaM2___Le_Tricheur.Model
{
    public class WordDictionary
    {
        #region Constants

        private const string ALPHABET = "abcdefghijklmnopqrstuvwxyz";

        #endregion

        #region Properties

        private Dictionary<char, HashSet<string>[]> _wordLists { get; set; }

        #endregion

        #region Constructors

        public WordDictionary()
        {
            this._wordLists = new Dictionary<char, HashSet<string>[]>();

            foreach (char c in ALPHABET)
            {
                this._wordLists[c] = new HashSet<string>[8];

                for (int i = 0; i < 8; i++)
                {
                    this._wordLists[c][i] = new HashSet<string>();
                }
            }
        }

        #endregion

        #region Methods

        private char FirstLetter(string word)
        {
            return word.ElementAt(0);
        }

        private int LengthIndex(string word)
        {
            return word.Length - 3;
        }

        public void LoadWords()
        {
            int lineCounter = 0;
            string allWords = CaM2___Le_Tricheur.Properties.Resources.FrenchDict_CaM2;
            char[] delimiters = { '\r', '\n' };

            foreach (string word in allWords.Split(delimiters, System.StringSplitOptions.RemoveEmptyEntries))
            {
                try
                {
                    if (word.Length > 10)
                    {
                        throw new Exception("Word \"" + word + "\" (length " + word.Length + ") on line " + lineCounter + " is longer than 10 characters.");
                    }

                    if (word.Length < 3)
                    {
                        throw new Exception("Word \"" + word + "\" (length " + word.Length + ") on line " + lineCounter + " is shorter than 3 characters.");
                    }

                    this._wordLists[FirstLetter(word)][LengthIndex(word)].Add(word);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error while loading words:");
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    lineCounter++;
                }
            }
        }

        public bool IsWord(string word)
        {
            return this._wordLists[FirstLetter(word)][LengthIndex(word)].Contains(word);
        }

        #endregion
    }
}
