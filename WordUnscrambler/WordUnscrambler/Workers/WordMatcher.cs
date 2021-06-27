using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordUnscrambler.Data;


namespace WordUnscrambler.Workers
{
    public class WordMatcher
    {
        public List<MatchedWord> Match(string[] scrambledWords, string[] wordList)
        {
            // Create a list to hold the matched words and their scrambled word
            var matchedWords = new List<MatchedWord>();
            
            try
            {
                foreach (var scrambledWord in scrambledWords)
                {
                    foreach (var word in wordList)
                    {
                        // If the scrambled word matched a word in the list in it's current order
                        if (scrambledWord.Equals(word, StringComparison.OrdinalIgnoreCase))
                        {
                            matchedWords.Add(BuildMatchedWord(scrambledWord, word));
                        }
                        else
                        {
                            // Covert the scrambled word and the regular word into character arrays
                            var scrambledWordArray = scrambledWord.ToCharArray();
                            var wordArray = word.ToCharArray();

                            // Sort the character arrays
                            Array.Sort(scrambledWordArray);
                            Array.Sort(wordArray);

                            // Compare the words after combining them into a string
                            var sortedScrambledWord = new string(scrambledWordArray);
                            var sortedWord = new string(wordArray);

                            // If the scrambled word (sorted by letter) matches a word in the word list (sorted by letter)
                            if (sortedScrambledWord.Equals(sortedWord, StringComparison.OrdinalIgnoreCase))
                            {
                                matchedWords.Add(BuildMatchedWord(scrambledWord, word));
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return matchedWords;
        }
        /// <summary>
        /// Helper Method to create MatchedWord structs by taking in a scrambled and normal word and returning a MatchedWord Struct
        /// </summary>
        /// <param name="scrambledWord"></param>
        /// <param name="word"></param>
        /// <returns> MatchedWord Struct</returns>
        private MatchedWord BuildMatchedWord(string scrambledWord, string word)
        {
            MatchedWord matchedWord = new MatchedWord
            {
                ScrambledWord = scrambledWord,
                Word = word
            };

            return matchedWord;
        }
    }
}
