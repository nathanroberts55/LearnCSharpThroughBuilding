using System;
using System.IO;

namespace WordUnscrambler.Workers
{
    class FileReader
    {
        public string[] Read(string fileName)
        {
            // Create string array that will hold the file content
            string[] fileContent;

            try
            {
                // Attempt to assign the lines to the array
                fileContent = File.ReadAllLines(fileName);
            }
            catch (Exception ex)
            {
                // Throw expection if there is an error
                throw new Exception(ex.Message);
            }

            // Return the string array with words
            return fileContent;
        }
    }
}
