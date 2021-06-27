using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    class Constants
    {
        public const string OptionsOnHowToEnterScrabledWords = "Please enter the option (F for File, M for Manaual) on how you would like to enter word(s): ";
        public const string OptionsOnContinuingTheProgram = "Do you want to continue? (Y for Yes, N for No): ";
        
        public const string EnterScrambledWordsViaFile = "Enter Scrambled Words full path file location: ";
        public const string EnterWordsManually = "Enter Scrambled Word(s) Manually separated by commas (if Multiple): ";
        public const string EnterScrambledWordOptionNotRecognized = "Option was not recognized.";
       
        public const string ErrorScrambledWordsCannotBeLoaded = "Scrambled Words could not be loaded because there was an error: ";
        public const string ErrorProgramWillBeTerminated = "This program will be terminated: ";
        public const string ErrorMatchesCannotBeDisplayed = "Matches could be be displayed becase there was an error: ";
      
        public const string MatchFound = "MATCH FOUND {0}: {1}";
        public const string MatchNotFound = "No Matches have been found";

        public const string Yes = "Y";
        public const string No = "N";
        public const string File = "F";
        public const string Manual = "M";

        public const string wordListFileName = "wordlist.txt";
    }
}
