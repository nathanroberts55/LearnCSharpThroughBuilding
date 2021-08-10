using SimpleWebScraper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleWebScraper.Builders
{
    class ScrapeCriteriaPartBuilder
    {
        private string _regex;
        private RegexOptions _regexOption;

        // Constructor for when the builder is created, run the set defaults method
        public ScrapeCriteriaPartBuilder()
        {
            SetDefaults();
        }
        // Set the default of the scrapeCriteriaParts to empty values
        private void SetDefaults()
        {
            _regex = string.Empty;
            _regexOption = RegexOptions.None;
        }
        // Set the value of the regex. Return the 
        public ScrapeCriteriaPartBuilder WithRegex(string regex)
        {
            _regex = regex;
            return this;
        }
        // Set the value of the regex option
        public ScrapeCriteriaPartBuilder WithRegexOptions(RegexOptions regexOption)
        {
            _regexOption = regexOption;
            return this;
        }
        public ScrapeCriteriaPart Build()
        {
            // Create ScrapeCriteria Part Object to build
            ScrapeCriteriaPart scrapeCriteriaPart = new ScrapeCriteriaPart();

            // Pass the values of the regex and the regex option
            scrapeCriteriaPart.Regex = _regex;
            scrapeCriteriaPart.RegexOption = _regexOption;
            
            // Return the object
            return scrapeCriteriaPart;
        }
    }
}
