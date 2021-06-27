using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WordUnscrambler.Workers;

namespace WordUnscrambler.Test.Unit
{
    [TestClass]
    public class WordMatcherTest
    {
        private readonly WordMatcher _wordMatcher = new WordMatcher();


        [TestMethod]
        public void SingleScrambledWordMatchesGivenWordInTheList()
        {
            // Create sample input for the match method
            string[] words = { "cat", "chair", "more" };
            string[] scrambledWords = { "omre" };

            //call the function we would like to test
            var matchedWords = _wordMatcher.Match(scrambledWords, words);

            // Test that the output is one matched word, where the scrambled word is omre and the word is more
            Assert.IsTrue(matchedWords.Count == 1);
            Assert.IsTrue(matchedWords[0].ScrambledWord.Equals("omre"));
            Assert.IsTrue(matchedWords[0].Word.Equals("more"));

        }

        [TestMethod]
        public void ManyScrambledWordsMatchesGivenWordsInTheList()
        {
            // Create sample input for the match method
            string[] words = { "cat", "chair", "more" };
            string[] scrambledWords = { "omre", "airch" };

            //call the function we would like to test
            var matchedWords = _wordMatcher.Match(scrambledWords, words);

            // Test that the output are multiple matched words
            Assert.IsTrue(matchedWords.Count == 2);
            Assert.IsTrue(matchedWords[0].ScrambledWord.Equals("omre"));
            Assert.IsTrue(matchedWords[0].Word.Equals("more"));
            Assert.IsTrue(matchedWords[1].ScrambledWord.Equals("airch"));
            Assert.IsTrue(matchedWords[1].Word.Equals("chair"));
        }
    }
}
