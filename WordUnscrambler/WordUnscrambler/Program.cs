using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using WordUnscrambler.Workers;
using WordUnscrambler.Data;

namespace WordUnscrambler
{
    class Program
    {
        private static readonly FileReader _fileReader = new FileReader();
        private static readonly WordMatcher _wordMatcher = new WordMatcher();
        static void Main(string[] args)
        {
            try
            {
                // Whether or not we are going to continue with the program
                bool continueWordUnscramble = true;

                do
                {
                    // Ask for the user preferred method
                    Console.Write(Constants.OptionsOnHowToEnterScrabledWords);
                    var option = Console.ReadLine() ?? string.Empty;

                    // Based on the method chosen...
                    switch (option.ToUpper())
                    {
                        case Constants.File:
                            // Get the file location and execute unscrambling
                            Console.Write(Constants.EnterScrambledWordsViaFile);
                            ExecuteScrambledWordsInFileScenario();
                            break;
                        case Constants.Manual:
                            // Get the word list and execute unscrambling
                            Console.Write(Constants.EnterWordsManually);
                            ExecuteScrambledWordsManualEntryScenario();
                            break;
                        default:
                            // Notify user of input
                            Console.WriteLine(Constants.EnterScrambledWordOptionNotRecognized);
                            break;
                    }

                    // Figure out if the user would like to continue
                    var continueDecision = string.Empty;
                    do
                    {
                        Console.Write(Constants.OptionsOnContinuingTheProgram);
                        continueDecision = (Console.ReadLine() ?? string.Empty);

                    }
                    // Continue to ask until they give an answer
                    while (!continueDecision.Equals(Constants.Yes, StringComparison.OrdinalIgnoreCase) &&
                           !continueDecision.Equals(Constants.No, StringComparison.OrdinalIgnoreCase));


                    continueWordUnscramble = continueDecision.Equals(Constants.Yes, StringComparison.OrdinalIgnoreCase);
                } while (continueWordUnscramble);
            }
            catch (Exception ex)
            {
                Console.WriteLine(Constants.ErrorProgramWillBeTerminated + ex.Message);
            }
        }

        private static void ExecuteScrambledWordsManualEntryScenario()
        {
            try
            {
                // Get word list from console, default empty if otherwise.
                var manualInput = Console.ReadLine() ?? String.Empty;
                // Split the list on the commas
                string[] scrambledWords = manualInput.Split(',');
                // Display the Matched Words
                DisplayMatchedUnscrambledWords(scrambledWords);
            }
            catch (Exception ex)
            {
                Console.WriteLine(Constants.ErrorScrambledWordsCannotBeLoaded + ex.Message);
            }
        }

        private static void ExecuteScrambledWordsInFileScenario()
        {
            try
            {
                // Get word list file location from console, default empty if otherwise.
                var fileName = Console.ReadLine() ?? String.Empty;
                // Read in the words from the file
                string[] scrambledWords = _fileReader.Read(fileName);
                // Display the Matched Words
                DisplayMatchedUnscrambledWords(scrambledWords);
            }
            catch (Exception ex)
            {
                Console.WriteLine(Constants.ErrorScrambledWordsCannotBeLoaded + ex.Message);
            }

        }
        private static void DisplayMatchedUnscrambledWords(string[] scrambledWords)
        {
            try
            {
                // Read in the words
                string[] wordList = _fileReader.Read(Constants.wordListFileName);

                // Make a list of the scrambled words and the matched words
                List<MatchedWord> matchedWords = _wordMatcher.Match(scrambledWords, wordList);

                // If there are any matched words in the list
                if (matchedWords.Any())
                {
                    // Print out each scrambled word and the word that it matches
                    foreach (var matchedWord in matchedWords)
                    {
                        Console.WriteLine(Constants.MatchFound, matchedWord.ScrambledWord, matchedWord.Word);
                    }
                }
                else
                {
                    // No matching words are in the list
                    Console.WriteLine(Constants.MatchNotFound);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(Constants.ErrorMatchesCannotBeDisplayed + ex.Message);
            }

        }

        
    }
}
