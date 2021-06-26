using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WordUnscrambler
{
    class Program
    {
        static void Main(string[] args)
        {
            // Whether or not we are going to continue with the program
            bool continueWordUnscramble = true;

            do
            {
                // Ask for the user preferred method
                Console.Write("Please enter the option (F for File, M for Manaual): ");
                var option = Console.ReadLine() ?? string.Empty;

                // Based on the method chosen...
                switch (option.ToUpper())
                {
                    case "F":
                        // Get the file location and execute unscrambling
                        Console.Write("Enter Scrambled Words file location: ");
                        ExecuteScrambledWordsInFileScenario();
                        break;
                    case "M":
                        // Get the word list and execute unscrambling
                        Console.Write("Enter Scrambled Words Manually: ");
                        ExecuteScrambledWordsManualEntryScenario();
                        break;
                    default:
                        // Notify user of input
                        Console.Write("Option was not recognized: ");
                        break;
                }

                // Figure out if the user would like to continue
                var continueWordUnscrambleDecision = string.Empty;
                do
                {
                    Console.Write("Do you want to continue? (Y for Yes, N for No): ");
                    continueWordUnscrambleDecision = (Console.ReadLine() ?? string.Empty);

                } 
                // Continue to ask until they give an answer
                while (!continueWordUnscrambleDecision.Equals("Y", StringComparison.OrdinalIgnoreCase) && 
                         !continueWordUnscrambleDecision.Equals("N", StringComparison.OrdinalIgnoreCase));


                continueWordUnscramble = continueWordUnscrambleDecision.Equals("Y", StringComparison.OrdinalIgnoreCase);
            } while (continueWordUnscramble);
        }

        private static void ExecuteScrambledWordsManualEntryScenario()
        {
            throw new NotImplementedException();
        }

        private static void ExecuteScrambledWordsInFileScenario()
        {
            throw new NotImplementedException();
        }
    }
}
